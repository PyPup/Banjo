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

	public class QueueConfigurationCollection : ItemConfigurationCollection<QueueConfiguration>
	{
		private TraceSource traceSource;

		public QueueConfigurationCollection()
		{
			this.traceSource = new TraceSource(MessagingDescription.TraceSourceName);
		}

		public bool RemoveQueuesNotInConfigration { get; set; }

		internal async Task ApplyToAsync(NamespaceManager namespaceManager, RetryPolicy retryPolicy)
		{
			var queues = this.GroupBy(q => q.Description.Path);

			var duplicates = queues.Where(grp => grp.Count() > 1);

			if (duplicates.Any())
			{
				throw new InvalidOperationException("Cannot create duplicate queues.");
			}

			var tasks = new List<Task>();

			foreach (var config in this.Where(item => item.CreateMode == ItemCreateMode.CreateIfNotExists))
			{
				tasks.Add(
					retryPolicy.ExecuteAsync(
						() => this.CreateOrUpdateQueueAsync(namespaceManager, config.Description)));
			}

			if (this.RemoveQueuesNotInConfigration)
			{
				var existingQueues = await namespaceManager.GetQueuesAsync();

				// Iterate over queues which are not present in the configuration, but exist on the bus.
				foreach (var queue in existingQueues.Where(desc => this.Any(item => item.Description.Path != desc.Path)))
				{
					this.traceSource.TraceInformation(TraceMessages.DeletingQueue, queue.Path);
					tasks.Add(namespaceManager.DeleteQueueAsync(queue.Path));
				}
			}

			// Wait for all the tasks to complete.
			await Task.WhenAll(tasks);
		}

		private async Task CreateOrUpdateQueueAsync(
			NamespaceManager namespaceManager,
			QueueDescription description)
		{
			if (await namespaceManager.QueueExistsAsync(description.Path))
			{
				this.traceSource.TraceInformation(TraceMessages.UpdatingQueue, description.Path);
				await namespaceManager.UpdateQueueAsync(description);
			}
			else
			{
				this.traceSource.TraceInformation(TraceMessages.CreatingQueue, description.Path);
				await namespaceManager.CreateQueueAsync(description);
			}
		}
	}
}
