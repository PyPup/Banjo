using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.MicrosoftServiceBus.Setup.Configuration
{
	public abstract class ConfigurationElementCollection<TKey, TConfigurationElement>
		: ConfigurationElementCollection, IEnumerable<TConfigurationElement>
		where TConfigurationElement : ConfigurationElement
	{
		protected abstract TConfigurationElement CreateNewConfigurationElement();

		protected abstract TKey GetConfigurationElementKey(TConfigurationElement element);

		protected override ConfigurationElement CreateNewElement()
		{
			return this.CreateNewConfigurationElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}

			return this.GetConfigurationElementKey((TConfigurationElement)element);
		}

		public new IEnumerator<TConfigurationElement> GetEnumerator()
		{
			return this.Cast<TConfigurationElement>().GetEnumerator();
		}
	}
}
