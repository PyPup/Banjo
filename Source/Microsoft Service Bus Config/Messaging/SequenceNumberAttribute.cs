using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyPup.ServiceBus.Messaging
{
	/// <summary>
	/// Indicates that a property contains the sequence number of a message.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class SequenceNumberAttribute : Attribute
	{
	}
}
