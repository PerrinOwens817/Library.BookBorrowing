using Library.BookBorrowing.Models;

namespace Library.BookBorrowing.Services
{
	/// <summary>
	/// Service class that handles book borrowing logic for the library system.
	/// </summary>
	public class BorrowService
	{
		private List<Book> _books;
		private List<BorrowRecord> _borrowRecords;

		/// <summary>
		/// Initializes a new instance of the <see cref="BorrowService"/> class with sample books.
		/// </summary>
		public BorrowService()
		{
			_books = new List<Book>
			{
				new Book { BookId = 1, Title = "The Giver", IsBorrowed = false },
				new Book { BookId = 2, Title = "The Hobbit", IsBorrowed = true }
			};
			_borrowRecords = new List<BorrowRecord>();
		}

		/// <summary>
		/// Checks if a specific book is available for borrowing.
		/// </summary>
		/// <param name="bookId">The ID of the book to check.</param>
		/// <returns>True if the book is available; otherwise, false.</returns>
		public bool CheckAvailability(int bookId)
		{
			var book = _books.FirstOrDefault(b => b.BookId == bookId);
			return book != null && !book.IsBorrowed;
		}

		/// <summary>
		/// Processes a book borrowing request for a given user and book.
		/// </summary>
		/// <param name="userId">The ID of the user borrowing the book.</param>
		/// <param name="bookId">The ID of the book to be borrowed.</param>
		/// <returns>A message indicating the borrowing status or due date.</returns>
		public string BorrowBook(int userId, int bookId)
		{
			if (!CheckAvailability(bookId)) return "This book is currently unavailable.";

			var book = _books.First(b => b.BookId == bookId);
			book.IsBorrowed = true;

			var record = new BorrowRecord
			{
				Id = _borrowRecords.Count + 1,
				UserId = userId,
				BookId = bookId,
				BorrowDate = DateTime.Now,
				DueDate = DateTime.Now.AddDays(14)
			};

			_borrowRecords.Add(record);
			return $"Book borrowed! Due on {record.DueDate:d}";
		}

		/// <summary>
		/// Retrieves a list of books that are currently available to borrow.
		/// </summary>
		/// <returns>A list of available books.</returns>
		public List<Book> GetAvailableBooks() => _books.Where(b => !b.IsBorrowed).ToList();
	}
}
