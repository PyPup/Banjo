namespace PyPup.ServiceBus.Deployment
{
	using System.Collections.Generic;
	using Microsoft.ServiceBus.Messaging;

	public class SubscriptionConfiguration : ItemConfiguration
	{
		public SubscriptionDescription Description { get; set; }

		public ICollection<RuleDescription> Rules { get; private set; }
	}
}
