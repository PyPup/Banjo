using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.MicrosoftServiceBus.Setup.Configuration
{
	public class QueueConfigurationElement : ConfigurationElement
	{
		private static class PropertyNames
		{
			public const string Path = "path";
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
	}
}
