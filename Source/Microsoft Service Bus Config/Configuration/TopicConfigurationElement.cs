namespace Company.MicrosoftServiceBus.Setup.Configuration
{
	using System.Configuration;

	public class TopicConfigurationElement : ConfigurationElement
	{
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

		private static class PropertyNames
		{
			public const string Path = "path";

			public const string Create = "create";

			public const string Subscriptions = "subscriptions";
		}
	}
}
