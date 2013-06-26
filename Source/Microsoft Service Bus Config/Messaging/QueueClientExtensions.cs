namespace PyPup.ServiceBus.Messaging
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Microsoft.ServiceBus.Messaging;

	/// <summary>
	/// Provides extensions for the <see cref="QueueClient"/> class.
	/// </summary>
	internal static class QueueClientExtensions
	{
		public static Task<MessageSession> AcceptMessageSessionAsync(
			this QueueClient client,
			string sessionId)
		{
			return Task<MessageSession>.Factory.FromAsync<string>(
				client.BeginAcceptMessageSession,
				client.EndAcceptMessageSession,
				sessionId,
				null);
		}

		public static Task<BrokeredMessage> ReceiveAsync(
			this QueueClient client)
		{
			return Task<BrokeredMessage>.Factory.FromAsync(
				client.BeginReceive,
				client.EndReceive,
				null);
		}
	}
}
