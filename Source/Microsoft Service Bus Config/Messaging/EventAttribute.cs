using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyPup.ServiceBus.Messaging
{
	[AttributeUsage(AttributeTargets.Class)]
	public class EventAttribute : Attribute
	{
		/// <summary>
		/// Gets or sets the name of the topic instances of the event are published to.
		/// </summary>
		public string TopicName { get; set; }
	}
}
