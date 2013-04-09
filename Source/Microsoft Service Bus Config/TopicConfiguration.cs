using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace Company.MicrosoftServiceBus.Setup
{
	public class TopicConfiguration : ItemConfiguration
	{
		public TopicDescription Description { get; set; }
	}
}
