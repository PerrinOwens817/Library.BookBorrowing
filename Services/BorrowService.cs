using Library.BookBorrowing.Models;

namespace Library.BookBorrowing.Services
{
	public class BorrowService
	{
		private List<Book> _books;
		private List<BorrowRecord> _borrowRecords;

		public BorrowService()
		{
			_books = new List<Book>
			{
				new Book { BookId = 1, Title = "The Giver", IsBorrowed = false },
				new Book { BookId = 2, Title = "The Hobbit", IsBorrowed = true }
			};
			_borrowRecords = new List<BorrowRecord>();
		}

		public bool CheckAvailability(int bookId)
		{
			var book = _books.FirstOrDefault(b => b.BookId == bookId);
			return book != null && !book.IsBorrowed;
		}

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

		public List<Book> GetAvailableBooks() => _books.Where(b => !b.IsBorrowed).ToList();
	}
}
