//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor v4.2.5.1
//     Source:                    https://github.com/msawczyn/EFDesigner
//     Visual Studio Marketplace: https://marketplace.visualstudio.com/items?itemName=michaelsawczyn.EFDesigner
//     Documentation:             https://msawczyn.github.io/EFDesigner/
//     License (MIT):             https://github.com/msawczyn/EFDesigner/blob/master/LICENSE
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EfCore
{
	/// <summary>
	/// 書籍
	/// </summary>
	[System.ComponentModel.Description("書籍")]
	public partial class Book
	{
		partial void Init();

		/// <summary>
		/// Default constructor
		/// </summary>
		public Book()
		{
			Authors = new System.Collections.ObjectModel.Collection<global::EfCore.Author>();

			Init();
		}

		/// <summary>
		/// Public constructor with required data
		/// </summary>
		/// <param name="isbn">ISBN</param>
		/// <param name="publisherid">Foreign key for Publisher.Book &lt;--&gt; Book.Publisher. </param>
		/// <param name="publisher"></param>
		public Book(string isbn, long publisherid, global::EfCore.Publisher publisher)
		{
			if (string.IsNullOrEmpty(isbn)) throw new ArgumentNullException(nameof(isbn));
			this.ISBN = isbn;

			this.PublisherId = publisherid;

			if (publisher == null) throw new ArgumentNullException(nameof(publisher));
			this.Publisher = publisher;
			publisher.Books.Add(this);

			Authors = new System.Collections.ObjectModel.Collection<global::EfCore.Author>();
			Init();
		}

		/// <summary>
		/// Static create function (for use in LINQ queries, etc.)
		/// </summary>
		/// <param name="isbn">ISBN</param>
		/// <param name="publisherid">Foreign key for Publisher.Book &lt;--&gt; Book.Publisher. </param>
		/// <param name="publisher"></param>
		public static Book Create(string isbn, long publisherid, global::EfCore.Publisher publisher)
		{
			return new Book(isbn, publisherid, publisher);
		}

		/*************************************************************************
		 * Properties
		 *************************************************************************/

		/// <summary>
		/// Identity, Indexed, Required
		/// Unique identifier
		/// </summary>
		[Key]
		[Required]
		[System.ComponentModel.Description("Unique identifier")]
		public long Id { get; set; }

		/// <summary>
		/// Indexed, Required, Max length = 50
		/// ISBN
		/// </summary>
		[Required]
		[MaxLength(50)]
		[StringLength(50)]
		[System.ComponentModel.DataAnnotations.Display(Name="ISBN")]
		[System.ComponentModel.Description("ISBN")]
		public string ISBN { get; set; }

		/// <summary>
		/// Max length = 100
		/// 名稱
		/// </summary>
		[MaxLength(100)]
		[StringLength(100)]
		[System.ComponentModel.DataAnnotations.Display(Name="名稱")]
		[System.ComponentModel.Description("名稱")]
		public string Name { get; set; }

		/// <summary>
		/// 售價
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display(Name="售價")]
		[System.ComponentModel.Description("售價")]
		[Column(TypeName="decimal(12,2)")]
		public decimal? Price { get; set; }

		/// <summary>
		/// Indexed, Required
		/// Foreign key for Publisher.Book &lt;--&gt; Book.Publisher. 
		/// </summary>
		[Required]
		[System.ComponentModel.Description("Foreign key for Publisher.Book <--> Book.Publisher. ")]
		public long PublisherId { get; set; }

		/// <summary>
		/// 類型
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display(Name="類型")]
		[System.ComponentModel.Description("類型")]
		public global::EfCore.BookType? Type { get; set; }

		/*************************************************************************
		 * Navigation properties
		 *************************************************************************/

		public virtual ICollection<global::EfCore.Author> Authors { get; private set; }

		/// <summary>
		/// Required
		/// </summary>
		public virtual global::EfCore.Publisher Publisher { get; set; }

	}
}

