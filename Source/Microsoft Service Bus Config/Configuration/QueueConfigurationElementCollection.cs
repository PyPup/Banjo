namespace Company.MicrosoftServiceBus.Setup.Configuration
{
	using System;
	using System.Configuration;

	[ConfigurationCollection(typeof(QueueConfigurationElement), AddItemName = "queue")]
	public class QueueConfigurationElementCollection : ConfigurationElementCollection<string, QueueConfigurationElement>
	{
		protected override QueueConfigurationElement CreateNewConfigurationElement()
		{
			return new QueueConfigurationElement();
		}

		protected override string GetConfigurationElementKey(QueueConfigurationElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}

			return element.Path;
		}
	}
}
