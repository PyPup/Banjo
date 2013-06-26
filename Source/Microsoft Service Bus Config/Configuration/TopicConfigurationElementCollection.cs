namespace PyPup.ServiceBus.Deployment.Configuration
{
	using System;
	using System.Configuration;

	[ConfigurationCollection(typeof(TopicConfigurationElement), AddItemName = "topic")]
	public class TopicConfigurationElementCollection : ConfigurationElementCollection<string, TopicConfigurationElement>
	{
		protected override TopicConfigurationElement CreateNewConfigurationElement()
		{
			return new TopicConfigurationElement();
		}

		protected override string GetConfigurationElementKey(TopicConfigurationElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}

			return element.Path;
		}
	}
}
