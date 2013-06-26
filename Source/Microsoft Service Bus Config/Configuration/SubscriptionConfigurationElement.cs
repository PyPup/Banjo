namespace PyPup.ServiceBus.Deployment.Configuration
{
	using System.Configuration;

	public class SubscriptionConfigurationElement : ConfigurationElement
	{
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

		private static class PropertyNames
		{
			public const string Name = "name";
		}
	}
}
