namespace Company.MicrosoftServiceBus.Setup
{
	/// <summary>
	/// Specifies the method to use to create a given item in the Service Bus.
	/// </summary>
	public enum ItemCreateMode
	{
		/// <summary>
		/// The item will be created if it does not exist. If an item already exists with the same identifier,
		/// a warning is reported.
		/// </summary>
		CreateIfNotExists,

		/// <summary>
		/// The item will always be created. If an item already exists with the same identifier,
		/// the existing item is deleted before creating the new item.
		/// </summary>
		CreateAlways,

		/// <summary>
		/// The item will not be created.
		/// </summary>
		None
	}
}
