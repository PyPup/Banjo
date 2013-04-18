namespace Company.MicrosoftServiceBus.Setup.Configuration
{
	using System.Configuration;

	public class QueueConfigurationElement : ConfigurationElement
	{
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

		private static class PropertyNames
		{
			public const string Path = "path";
		}
	}
}
