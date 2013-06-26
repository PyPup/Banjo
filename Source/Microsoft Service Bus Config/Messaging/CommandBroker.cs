using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace PyPup.ServiceBus.Messaging
{
	internal class CommandBroker<T>
	{
		private QueueClient queueClient;

		/// <summary>
		/// Gets the next command to process as an asynchronous operation.
		/// </summary>
		/// <returns>A task representing the asynchronous operation.</returns>
		/// <remarks>
		/// <para>The returned task completes when there is a command available to process.</para>
		/// </remarks>
		public Task<T> GetNextCommandAsync()
		{
			// Run task as a continuation of the previous "get next" task to ensure they are delivered in serial.
			throw new NotImplementedException();
		}
	}
}
