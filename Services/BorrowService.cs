using Library.BookBorrowing.Data;
using Library.BookBorrowing.Models;

namespace Library.BookBorrowing.Services
{
	/// <summary>
	/// Service class that handles book borrowing logic for the library system.
	/// </summary>
	public class BorrowService
	{
		private readonly LibraryContext _context;

		/// <summary>
		/// Constructor that takes the database context.
		/// </summary>
		public BorrowService(LibraryContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Checks if the book is available to borrow.
		/// </summary>
		public bool CheckAvailability(int bookId)
		{
			var book = _context.Books.FirstOrDefault(b => b.BookId == bookId);
			return book != null && !book.IsBorrowed;
		}

		/// <summary>
		/// Handles borrowing a book for a user.
		/// </summary>
		public string BorrowBook(int userId, int bookId)
		{
			if (!CheckAvailability(bookId)) return "This book is currently unavailable.";

			var book = _context.Books.First(b => b.BookId == bookId);
			book.IsBorrowed = true;

			var record = new BorrowRecord
			{
				UserId = userId,
				BookId = bookId,
				BorrowDate = DateTime.Now,
				DueDate = DateTime.Now.AddDays(14)
			};

			_context.BorrowRecords.Add(record);
			_context.SaveChanges(); // 🔥 this is what actually writes to the DB

			return $"Book borrowed! Due on {record.DueDate:d}";
		}

		/// <summary>
		/// Gets a list of all books that are not currently borrowed.
		/// </summary>
		public List<Book> GetAvailableBooks()
		{
			return _context.Books.Where(b => !b.IsBorrowed).ToList();
		}
	}
}
