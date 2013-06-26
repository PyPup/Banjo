namespace PyPup.ServiceBus.Deployment.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Configuration;
	using System.Linq;

	public abstract class ConfigurationElementCollection<TKey, TConfigurationElement>
		: ConfigurationElementCollection, IEnumerable<TConfigurationElement>
		where TConfigurationElement : ConfigurationElement
	{
		public new IEnumerator<TConfigurationElement> GetEnumerator()
		{
			return this.Cast<TConfigurationElement>().GetEnumerator();
		}

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
	}
}
