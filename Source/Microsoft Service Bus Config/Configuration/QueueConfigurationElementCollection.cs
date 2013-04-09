using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.MicrosoftServiceBus.Setup.Configuration
{
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
