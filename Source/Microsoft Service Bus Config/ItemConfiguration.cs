namespace Company.MicrosoftServiceBus.Setup
{
	/// <summary>
	/// Defines the members common to configuration of all items.
	/// </summary>
	public abstract class ItemConfiguration
	{
		/// <summary>
		/// Gets or sets the mode of creation to use when applying the item's configuration 
		/// to a service bus instance.
		/// </summary>
		/// <value>One of the <see cref="ItemCreateMode"/> values specifying the creation mode to use.</value>
		public ItemCreateMode CreateMode { get; set; }
	}
}
