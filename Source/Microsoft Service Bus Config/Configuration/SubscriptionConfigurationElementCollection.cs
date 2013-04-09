using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.MicrosoftServiceBus.Setup.Configuration
{
	[ConfigurationCollection(typeof(SubscriptionConfigurationElement), AddItemName = "subscription")]
	public class SubscriptionConfigurationElementCollection 
		: ConfigurationElementCollection<string, SubscriptionConfigurationElement>
	{
		protected override SubscriptionConfigurationElement CreateNewConfigurationElement()
		{
			return new SubscriptionConfigurationElement();
		}

		protected override string GetConfigurationElementKey(SubscriptionConfigurationElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}

			return element.Name;
		}
	}
}
