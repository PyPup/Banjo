using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyPup.ServiceBus.Messaging
{
	[AttributeUsage(AttributeTargets.Class)]
	public class CommandAttribute : Attribute
	{
		/// <summary>
		/// Gets or sets the name of the queue instances of the command should be sent to
		/// and received from.
		/// </summary>
		public string QueueName { get; set; }
	}
}
