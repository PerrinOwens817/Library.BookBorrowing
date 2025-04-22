namespace Library.BookBorrowing.Models
{
	/// <summary>
	/// Represents a book in the library system.
	/// </summary>
	public class Book
	{
		/// <summary>
		/// Gets or sets the unique ID of the book.
		/// </summary>
		public int BookId { get; set; }

		/// <summary>
		/// Gets or sets the title of the book.
		/// </summary>
		public string Title { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets a value indicating whether the book is currently borrowed.
		/// </summary>
		public bool IsBorrowed { get; set; }
	}
}
