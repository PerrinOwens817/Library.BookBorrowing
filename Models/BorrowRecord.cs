namespace Library.BookBorrowing.Models
{
	/// <summary>
	/// Represents a record of a book borrowing transaction.
	/// </summary>
	public class BorrowRecord
	{
		/// <summary>
		/// Gets or sets the unique ID of the borrowing record.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the ID of the borrowed book.
		/// </summary>
		public int BookId { get; set; }

		/// <summary>
		/// Gets or sets the ID of the user who borrowed the book.
		/// </summary>
		public int UserId { get; set; }

		/// <summary>
		/// Gets or sets the date when the book was borrowed.
		/// </summary>
		public DateTime BorrowDate { get; set; }

		/// <summary>
		/// Gets or sets the due date by which the book should be returned.
		/// </summary>
		public DateTime DueDate { get; set; }
	}
}
