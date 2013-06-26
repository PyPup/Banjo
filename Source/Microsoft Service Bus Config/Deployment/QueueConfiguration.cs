namespace PyPup.ServiceBus.Deployment
{
	using Microsoft.ServiceBus.Messaging;

	public class QueueConfiguration : ItemConfiguration
	{
		public QueueDescription Description { get; set; }
	}
}
