using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.MicrosoftServiceBus.Setup.Configuration
{
	public class TopicConfigurationElement : ConfigurationElement
	{
		private static class PropertyNames
		{
			public const string Path = "path";

			public const string Create = "create";

			public const string Subscriptions = "subscriptions";
		}

		public TopicConfigurationElement()
		{
		}

		[ConfigurationProperty(PropertyNames.Path, IsKey = true, IsRequired = true)]
		public string Path
		{
			get
			{
				return (string)this[PropertyNames.Path];
			}

			set
			{
				this[PropertyNames.Path] = value;
			}
		}

		[ConfigurationProperty(PropertyNames.Create, IsRequired = false, DefaultValue = true)]
		public bool Create
		{
			get
			{
				return (bool)this[PropertyNames.Create];
			}

			set
			{
				this[PropertyNames.Create] = value;
			}
		}

		[ConfigurationProperty(PropertyNames.Subscriptions, IsRequired = false)]
		public SubscriptionConfigurationElementCollection Subscriptions
		{
			get
			{
				return (SubscriptionConfigurationElementCollection)this[PropertyNames.Subscriptions];
			}

			set
			{
				this[PropertyNames.Subscriptions] = value;
			}
		}
	}
}
