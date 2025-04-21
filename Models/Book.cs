namespace Library.BookBorrowing.Models
{
	public class Book
	{
		public int BookId { get; set; }
		public string Title { get; set; } = string.Empty;
		public bool IsBorrowed { get; set; }
	}
}
