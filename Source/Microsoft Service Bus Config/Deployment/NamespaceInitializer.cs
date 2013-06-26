namespace PyPup.ServiceBus.Deployment
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Microsoft.ServiceBus.Messaging;

	public class NamespaceInitializer
	{
		internal const string TraceSourceName = "PyPup.MicrosoftServiceBus.Deployment";

		private TraceSource traceSource;

		public NamespaceInitializer()
		{
			this.traceSource = new TraceSource(NamespaceInitializer.TraceSourceName);
		}
	}
}
