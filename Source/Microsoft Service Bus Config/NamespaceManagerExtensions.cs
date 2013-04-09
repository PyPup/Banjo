using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Practices.TransientFaultHandling;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace Company.MicrosoftServiceBus.Setup
{
	internal static class NamespaceManagerExtensions
	{
		public static Task<bool> QueueExistsAsync(this NamespaceManager namespaceManager, string path)
		{
			return Task<bool>.Factory.FromAsync<string>(
				namespaceManager.BeginQueueExists,
				namespaceManager.EndQueueExists,
				path,
				null);
		}

		public static Task<QueueDescription> CreateQueueAsync(this NamespaceManager namespaceManager, QueueDescription description)
		{
			return Task<QueueDescription>.Factory.FromAsync<QueueDescription>(
				namespaceManager.BeginCreateQueue,
				namespaceManager.EndCreateQueue,
				description,
				null);
		}

		public static Task<QueueDescription> UpdateQueueAsync(this NamespaceManager namespaceManager, QueueDescription description)
		{
			return Task<QueueDescription>.Factory.FromAsync<QueueDescription>(
				namespaceManager.BeginUpdateQueue,
				namespaceManager.EndUpdateQueue,
				description,
				null);
		}

		public static Task<bool> TopicExistsAsync(this NamespaceManager namespaceManager, string path)
		{
			return Task<bool>.Factory.FromAsync<string>(
				namespaceManager.BeginTopicExists,
				namespaceManager.EndTopicExists,
				path,
				null);
		}

		public static Task<TopicDescription> CreateTopicAsync(this NamespaceManager namespaceManager, TopicDescription description)
		{
			return Task<TopicDescription>.Factory.FromAsync<TopicDescription>(
				namespaceManager.BeginCreateTopic,
				namespaceManager.EndCreateTopic,
				description,
				null);
		}

		public static Task<TopicDescription> UpdateTopicAsync(this NamespaceManager namespaceManager, TopicDescription description)
		{
			return Task<TopicDescription>.Factory.FromAsync<TopicDescription>(
				namespaceManager.BeginUpdateTopic,
				namespaceManager.EndUpdateTopic,
				description,
				null);
		}

		public static Task<bool> SubscriptionExistsAsync(this NamespaceManager namespaceManager, string topicPath, string name)
		{
			return Task<bool>.Factory.FromAsync<string, string>(
				namespaceManager.BeginSubscriptionExists,
				namespaceManager.EndSubscriptionExists,
				topicPath,
				name,
				null);
		}

		public static Task<SubscriptionDescription> CreateSubscriptionAsync(
			this NamespaceManager namespaceManager,
			SubscriptionDescription description)
		{
			return Task<SubscriptionDescription>.Factory.FromAsync<SubscriptionDescription>(
				namespaceManager.BeginCreateSubscription,
				namespaceManager.EndCreateSubscription,
				description,
				null);
		}

		public static Task<SubscriptionDescription> UpdateSubscriptionAsync(
			this NamespaceManager namespaceManager,
			SubscriptionDescription description)
		{
			return Task<SubscriptionDescription>.Factory.FromAsync<SubscriptionDescription>(
				namespaceManager.BeginUpdateSubscription,
				namespaceManager.EndUpdateSubscription,
				description,
				null);
		}

		public static Task<IEnumerable<QueueDescription>> GetQueuesAsync(
			this NamespaceManager namespaceManager)
		{
			return Task<IEnumerable<QueueDescription>>.Factory.FromAsync(
				namespaceManager.BeginGetQueues,
				namespaceManager.EndGetQueues,
				null);
		}

		public static Task DeleteQueueAsync(
			this NamespaceManager namespaceManager,
			string path)
		{
			return Task.Factory.FromAsync(
				namespaceManager.BeginDeleteQueue,
				namespaceManager.EndDeleteQueue,
				path,
				null);
		}

		public static Task<IEnumerable<TopicDescription>> GetTopicsAsync(
			this NamespaceManager namespaceManager)
		{
			return Task<IEnumerable<TopicDescription>>.Factory.FromAsync(
				namespaceManager.BeginGetTopics,
				namespaceManager.EndGetTopics,
				null);
		}

		public static Task DeleteTopicAsync(
			this NamespaceManager namespaceManager,
			string path)
		{
			return Task.Factory.FromAsync(
				namespaceManager.BeginDeleteTopic,
				namespaceManager.EndDeleteTopic,
				path,
				null);
		}

		public static Task<IEnumerable<SubscriptionDescription>> GetSubscriptionsAsync(
			this NamespaceManager namespaceManager,
			string path)
		{
			return Task<IEnumerable<SubscriptionDescription>>.Factory.FromAsync(
				namespaceManager.BeginGetSubscriptions,
				namespaceManager.EndGetSubscriptions,
				path,
				null);
		}

		public static Task DeleteSubscriptionAsync(
			this NamespaceManager namespaceManager,
			string topicPath,
			string name)
		{
			return Task.Factory.FromAsync(
				namespaceManager.BeginDeleteSubscription,
				namespaceManager.EndDeleteSubscription,
				topicPath,
				name,
				null);
		}
	}
}
