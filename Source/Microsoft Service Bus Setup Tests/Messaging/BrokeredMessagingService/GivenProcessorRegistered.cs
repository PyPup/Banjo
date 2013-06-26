namespace PyPup.ServiceBus.Tests.Messaging.BrokeredMessagingService
{
	using System;
	using System.Collections.Generic;
	using System.Configuration;
	using System.Linq;
	using System.Text;
	using Microsoft.ServiceBus;
	using Moq;
	using NUnit.Framework;
	using PyPup.ServiceBus.Messaging;

	public abstract class GivenProcessorRegistered : Specification
	{
		protected Mock<ICommandProcessor<TestMessage>> MockCommandProcessor { get; private set; }

		protected NamespaceManager NamespaceManager { get; private set; }

		protected override void Given()
		{
			this.MockCommandProcessor = new Mock<ICommandProcessor<TestMessage>>();

			this.Service.RegisterCommandProcessor(this.MockCommandProcessor.Object);

			this.NamespaceManager = NamespaceManager.CreateFromConnectionString(
				ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"]);
		}

		public class WhenCommandAddedToQueue : GivenProcessorRegistered
		{
			protected override void When()
			{
				// Create queue for test.

				// Push message onto queue.
			}

			[Test]
			public void ThenQueueInitalizerExecuted()
			{
				throw new NotImplementedException();
			}

			[Test]
			public void ThenQueueShouldBeEmpty()
			{
				throw new NotImplementedException();
			}

			[Test]
			public void ThenCommandShouldBePassedToProcessor()
			{
				throw new NotImplementedException();
			}
		}
	}
}
