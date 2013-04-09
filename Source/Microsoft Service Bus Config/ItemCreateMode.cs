using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.MicrosoftServiceBus.Setup
{
	/// <summary>
	/// Specifies the method to use to create a given item in the Service Bus.
	/// </summary>
	public enum ItemCreateMode
	{
		/// <summary>
		/// The item will be created if it does not exist or updated to match the current configuration.
		/// </summary>
		CreateOrUpdate,

		/// <summary>
		/// The item will not be created.
		/// </summary>
		None
	}
}
