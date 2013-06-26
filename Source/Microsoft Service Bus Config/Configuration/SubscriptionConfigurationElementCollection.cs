﻿namespace PyPup.ServiceBus.Deployment.Configuration
{
	using System;
	using System.Configuration;

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
