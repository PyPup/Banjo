using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyPup.ServiceBus.Messaging
{
	/// <summary>
	/// Defines a service which assists in brokered messaging.
	/// </summary>
	public interface IBrokeredMessagingService
	{
		/// <summary>
		/// Registers a command processor instance with the messaging service to handle commands
		/// of a specific type.
		/// </summary>
		/// <typeparam name="T">The type of command accepted by the processor.</typeparam>
		/// <param name="commandProcessor">A processor instance to register.</param>
		void RegisterCommandProcessor<T>(ICommandProcessor<T> commandProcessor);

		/// <summary>
		/// Registers a command processor instance which processes commands as an asynchronous operation
		/// with the messaging service to handle commands of a specific type.
		/// </summary>
		/// <typeparam name="T">The type of command accepted by the processor.</typeparam>
		/// <param name="commandProcessor">A processor instance to register.</param>
		void RegisterCommandAsyncProcessor<T>(ICommandAsyncProcessor<T> commandProcessor);
	}
}
