using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyPup.ServiceBus.Messaging
{
	public class BrokeredMessagingService : IBrokeredMessagingService
	{
		public void RegisterCommandProcessor<T>(ICommandProcessor<T> commandProcessor)
		{
			throw new NotImplementedException();
		}

		public void RegisterCommandAsyncProcessor<T>(ICommandAsyncProcessor<T> commandProcessor)
		{
			throw new NotImplementedException();
		}
	}
}
