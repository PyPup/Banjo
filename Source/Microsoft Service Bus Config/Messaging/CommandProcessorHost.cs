using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace PyPup.ServiceBus.Messaging
{
	internal class CommandProcessorHost<T>
	{
		private ICommandProcessor<T> commandProcessor;
	}
}
