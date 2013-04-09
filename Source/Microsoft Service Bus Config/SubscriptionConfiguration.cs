using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace Company.MicrosoftServiceBus.Setup
{
	public class SubscriptionConfiguration : ItemConfiguration
	{
		public SubscriptionDescription Description { get; set; }

		public ICollection<RuleDescription> Rules { get; private set; }
	}
}
