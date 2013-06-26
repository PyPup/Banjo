﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyPup.ServiceBus.Messaging
{
	public interface ICommandProcessor<T>
	{
		void ProcessCommand(T command);
	}
}
