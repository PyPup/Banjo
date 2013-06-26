using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyPup.ServiceBus.Messaging
{
	/// <summary>
	/// Indicates that a property contains the session ID of a given message.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class SessionIdAttribute : Attribute
	{
	}
}
