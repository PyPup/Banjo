namespace PyPup.ServiceBus.Tests
{
	using NUnit.Framework;

	public abstract class Specification
	{
		[SetUp]
		public void Execute()
		{
			this.Given();
			this.When();
		}

		protected abstract void Given();

		protected abstract void When();
	}
}
