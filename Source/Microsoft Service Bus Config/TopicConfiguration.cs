namespace Company.MicrosoftServiceBus.Setup
{
	using Microsoft.ServiceBus.Messaging;

	public class TopicConfiguration : ItemConfiguration
	{
		public TopicDescription Description { get; set; }
	}
}
