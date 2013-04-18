namespace Company.MicrosoftServiceBus.Setup
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.Practices.TransientFaultHandling;
	using Microsoft.ServiceBus;

	public class SubscriptionConfigurationCollection : ItemConfigurationCollection<SubscriptionConfiguration>
	{
		private TraceSource traceSource;

		public SubscriptionConfigurationCollection()
		{
			this.traceSource = new TraceSource(ServiceBusConfiguration.TraceSourceName);
		}

		public bool RemoveSubscriptionsNotInConfiguration { get; set; }

		internal bool RequiresSubscriptionClient
		{
			get
			{
				return this.Any(sub => sub.Rules.Any());
			}
		}

		internal Task ApplyToAsync(
			NamespaceManager namespaceManager,
			RetryPolicy retryPolicy)
		{
			var groups = this.GroupBy(q => new { q.Description.TopicPath, q.Description.Name });

			var duplicates = groups.Where(grp => grp.Count() > 1);

			if (duplicates.Any())
			{
				throw new InvalidOperationException("Cannot create duplicate subscriptions.");
			}

			var tasks = new List<Task>();

			foreach (var config in this.Where(item => item.CreateMode == ItemCreateMode.CreateIfNotExists))
			{
				tasks.Add(
					retryPolicy.ExecuteAsync(
						() => this.CreateOrUpdateSubscriptionAsync(namespaceManager, config)));
			}

			tasks.Add(this.DeleteSubscriptions(namespaceManager));

			// Wait for all the tasks to complete.
			return Task.WhenAll(tasks);
		}

		private async Task DeleteSubscriptions(NamespaceManager namespaceManager)
		{
			if (this.RemoveSubscriptionsNotInConfiguration)
			{
				var tasks = new List<Task>();
				var existingTopics = await namespaceManager.GetTopicsAsync();

				foreach (var topic in existingTopics)
				{
					var existingSubscriptions = await namespaceManager.GetSubscriptionsAsync(topic.Path);

					// Iterate over subscriptions which are not present in the configuration, but exist on the bus.
					foreach (var sub in existingSubscriptions.Where(
						desc => this.Any(item => !(item.Description.TopicPath == topic.Path && item.Description.Name != desc.Name))))
					{
						this.traceSource.TraceInformation(TraceMessages.DeletingSubscription, sub.TopicPath, sub.Name);
						tasks.Add(namespaceManager.DeleteSubscriptionAsync(sub.TopicPath, sub.Name));
					}
				}

				await Task.WhenAll(tasks);
			}
		}

		private async Task CreateOrUpdateSubscriptionAsync(
			NamespaceManager namespaceManager,
			SubscriptionConfiguration configuration)
		{
			if (configuration.Rules.Count > 1)
			{
				throw new NotSupportedException("Multiple rules per subscription is not supported.");
			}
			else
			{
				var description = configuration.Description;

				if (await namespaceManager.SubscriptionExistsAsync(description.TopicPath, description.Name))
				{
					this.traceSource.TraceInformation(TraceMessages.UpdatingSubscription, description.TopicPath, description.Name);
					await namespaceManager.UpdateSubscriptionAsync(description);
				}
				else
				{
					this.traceSource.TraceInformation(TraceMessages.CreatingSubscription, description.TopicPath, description.Name);
					await namespaceManager.CreateSubscriptionAsync(description);
				}
			}
		}
	}
}
