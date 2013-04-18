namespace Company.MicrosoftServiceBus.Setup
{
	using Microsoft.ServiceBus.Messaging;

	public class QueueConfiguration : ItemConfiguration
	{
		public QueueDescription Description { get; set; }
	}
}
