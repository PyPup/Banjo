using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.MicrosoftServiceBus.Setup.Configuration
{
	public class SubscriptionConfigurationElement : ConfigurationElement
	{
		private static class PropertyNames
		{
			public const string Name = "name";
		}

		[ConfigurationProperty(PropertyNames.Name, IsKey = true, IsRequired = true)]
		public string Name
		{
			get
			{
				return (string)this[PropertyNames.Name];
			}

			set
			{
				this[PropertyNames.Name] = value;
			}
		}
	}
}
