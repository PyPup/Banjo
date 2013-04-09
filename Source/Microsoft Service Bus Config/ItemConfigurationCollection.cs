using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.MicrosoftServiceBus.Setup
{
	/// <summary>
	/// Provides the base collection for types of item configuration.
	/// </summary>
	/// <typeparam name="TItemConfiguration">The type of configuration contained in the collection.</typeparam>
	public abstract class ItemConfigurationCollection<TItemConfiguration> : ICollection<TItemConfiguration>
		where TItemConfiguration: ItemConfiguration
	{
		/// <summary>
		/// Initialises a new instance of the <see cref="ItemConfigurationCollection{TItemConfiguration}"/> class.
		/// </summary>
		protected ItemConfigurationCollection()
		{
			this.InnerCollection = new List<TItemConfiguration>();
		}

		/// <summary>
		/// Gets the number of elements contained in the <see cref="ItemConfigurationCollection{TItemConfiguration}"/>.
		/// </summary>
		/// <value>The number of elements in the collection.</value>
		public int Count
		{
			get
			{
				return this.InnerCollection.Count;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the collection is read-only. Always <see langword="false"/> 
		/// for instances of <see cref="ItemConfigurationCollection{TItemConfiguration}"/>.
		/// </summary>
		/// <value>Always <see langword="false"/> for instances of 
		/// <see cref="ItemConfigurationCollection{TItemConfiguration}"/>.</value>
		bool ICollection<TItemConfiguration>.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		/// <summary>
		/// Gets the inner collection of the <see cref="ItemConfigurationCollection{TItemConfiguration}"/>.
		/// </summary>
		/// <value>The inner collection of the <see cref="ItemConfigurationCollection{TItemConfiguration}"/>.</value>
		protected ICollection<TItemConfiguration> InnerCollection { get; private set; }

		public void Add(TItemConfiguration item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}

			this.InnerCollection.Add(item);
		}

		public void Clear()
		{
			this.InnerCollection.Clear();
		}

		public bool Contains(TItemConfiguration item)
		{
			if (item == null)
			{
				return false;
			}
			else
			{
				return this.InnerCollection.Contains(item);
			}
		}

		public void CopyTo(TItemConfiguration[] array, int arrayIndex)
		{
			this.InnerCollection.CopyTo(array, arrayIndex);
		}

		public bool Remove(TItemConfiguration item)
		{
			return this.InnerCollection.Remove(item);
		}

		public IEnumerator<TItemConfiguration> GetEnumerator()
		{
			return this.InnerCollection.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}
