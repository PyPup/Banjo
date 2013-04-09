using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.WindowsAzure.TransientFaultHandling.ServiceBus;
using Microsoft.Practices.TransientFaultHandling;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace Company.MicrosoftServiceBus.Setup
{
	/// <summary>
	/// Represents a set of configuration for a Service Bus namespace.
	/// </summary>
	public class ServiceBusConfiguration
	{
		private TraceSource traceSource;

		internal const string TraceSourceName = "Company.MicrosoftServiceBus.Setup";

		public ServiceBusConfiguration()
		{
			this.Queues = new QueueConfigurationCollection();
			this.Topics = new TopicConfigurationCollection();
			this.Subscriptions = new SubscriptionConfigurationCollection();

			this.traceSource = new TraceSource(ServiceBusConfiguration.TraceSourceName);
		}

		public QueueConfigurationCollection Queues { get; private set; }

		public TopicConfigurationCollection Topics { get; private set; }

		public SubscriptionConfigurationCollection Subscriptions { get; private set; }

		public Task ApplyToAsync(string connectionString)
		{
			return this.ApplyToAsync(connectionString, RetryStrategy.NoRetry);
		}

		public Task ApplyToAsync(string connectionString, RetryStrategy retryStrategy)
		{
			if (connectionString == null)
			{
				throw new ArgumentNullException("connectionString");
			}

			if (retryStrategy == null)
			{
				throw new ArgumentNullException("retryStrategy");
			}

			var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);

			var policy = new RetryPolicy<ServiceBusTransientErrorDetectionStrategy>(retryStrategy);

			return this.ApplyToAsync(namespaceManager, connectionString, policy);
		}

		private async Task ApplyToAsync(
			NamespaceManager namespaceManager,
			string connectionString,
			RetryPolicy retryPolicy)
		{
			await Task.WhenAll(
				this.Queues.ApplyToAsync(namespaceManager, retryPolicy),
				this.Topics.ApplyToAsync(namespaceManager, retryPolicy));

			await this.Subscriptions.ApplyToAsync(namespaceManager, retryPolicy);
		}
	}
}
