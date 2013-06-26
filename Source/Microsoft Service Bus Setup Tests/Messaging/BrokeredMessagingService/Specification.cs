namespace PyPup.ServiceBus.Tests.Messaging.BrokeredMessagingService
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using PyPup.ServiceBus.Messaging;

	public abstract class Specification : PyPup.ServiceBus.Tests.Specification
	{
		protected Specification()
		{
			this.Service = new BrokeredMessagingService();
		}

		protected BrokeredMessagingService Service { get; private set; }
	}
}
