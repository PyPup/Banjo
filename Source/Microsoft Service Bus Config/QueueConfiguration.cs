using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace Company.MicrosoftServiceBus.Setup
{
	public class QueueConfiguration : ItemConfiguration
	{
		public QueueDescription Description { get; set; }
	}
}
