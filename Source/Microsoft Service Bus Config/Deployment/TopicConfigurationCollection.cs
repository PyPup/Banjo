namespace PyPup.ServiceBus.Deployment
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.Practices.TransientFaultHandling;
	using Microsoft.ServiceBus;
	using Microsoft.ServiceBus.Messaging;

	public class TopicConfigurationCollection : ItemConfigurationCollection<TopicConfiguration>
	{
		private TraceSource traceSource;

		public TopicConfigurationCollection()
		{
			this.traceSource = new TraceSource(MessagingDescription.TraceSourceName);
		}

		public bool RemoveTopicsNotInConfiguration { get; set; }

		internal async Task ApplyToAsync(NamespaceManager namespaceManager, RetryPolicy retryPolicy)
		{
			var groups = this.GroupBy(q => q.Description.Path);

			var duplicates = groups.Where(grp => grp.Count() > 1);

			if (duplicates.Any())
			{
				throw new InvalidOperationException("Cannot create duplicate topics.");
			}

			var tasks = new List<Task>();

			foreach (var config in this.Where(item => item.CreateMode == ItemCreateMode.CreateIfNotExists))
			{
				tasks.Add(
					retryPolicy.ExecuteAsync(
						() => this.CreateOrUpdateTopicAsync(namespaceManager, config.Description)));
			}

			if (this.RemoveTopicsNotInConfiguration)
			{
				var existingTopics = await namespaceManager.GetTopicsAsync();

				// Iterate over topics which are not present in the configuration, but exist on the bus.
				foreach (var topic in existingTopics.Where(desc => this.Any(item => item.Description.Path != desc.Path)))
				{
					this.traceSource.TraceInformation(TraceMessages.DeletingTopic, topic.Path);
					tasks.Add(namespaceManager.DeleteTopicAsync(topic.Path));
				}
			}

			// Wait for all the tasks to complete.
			await Task.WhenAll(tasks);
		}

		private async Task CreateOrUpdateTopicAsync(
			NamespaceManager namespaceManager,
			TopicDescription description)
		{
			if (await namespaceManager.TopicExistsAsync(description.Path))
			{
				this.traceSource.TraceInformation(TraceMessages.UpdatingTopic, description.Path);
				await namespaceManager.UpdateTopicAsync(description);
			}
			else
			{
				this.traceSource.TraceInformation(TraceMessages.CreatingTopic, description.Path);
				await namespaceManager.CreateTopicAsync(description);
			}
		}
	}
}
