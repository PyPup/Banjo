namespace PyPup.ServiceBus.Deployment
{
	using Microsoft.ServiceBus.Messaging;

	public class TopicConfiguration : ItemConfiguration
	{
		public TopicDescription Description { get; set; }
	}
}
