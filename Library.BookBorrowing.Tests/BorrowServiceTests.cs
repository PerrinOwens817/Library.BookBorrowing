using Library.BookBorrowing.Services;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Library.BookBorrowing.Data;
using Library.BookBorrowing.Models;


namespace Library.BookBorrowing.Tests
{
	/// <summary>
	/// Contains unit tests for the <see cref="BorrowService"/> class.
	/// </summary>
	public class BorrowServiceTests
	{
		/// <summary>
		/// Creates a new in-memory database context with seeded test data.
		/// </summary>
		/// <returns>A configured <see cref="LibraryContext"/> for testing.</returns>
		private LibraryContext GetInMemoryDbContext()
		{
			var options = new DbContextOptionsBuilder<LibraryContext>()
				.UseInMemoryDatabase(databaseName: "TestDb")
				.Options;

			var context = new LibraryContext(options);

			// Seed test data
			context.Books.AddRange(
				new Book { BookId = 1, Title = "Test Book 1", IsBorrowed = false },
				new Book { BookId = 2, Title = "Test Book 2", IsBorrowed = true }
			);
			context.SaveChanges();

			return context;
		}

		/// <summary>
		/// Verifies that <see cref="BorrowService.CheckAvailability"/> returns true when the book is available.
		/// </summary>
		[Fact]
		public void CheckAvailability_ShouldReturnTrue_WhenBookIsAvailable()
		{
			var context = GetInMemoryDbContext();
			var service = new BorrowService(context);

			var result = service.CheckAvailability(1);

			Assert.True(result);
		}

		/// <summary>
		/// Verifies that <see cref="BorrowService.BorrowBook"/> returns an unavailable message for a borrowed book.
		/// </summary>
		[Fact]
		public void BorrowBook_ShouldReturnUnavailableMessage_IfBookIsBorrowed()
		{
			var context = GetInMemoryDbContext();
			var service = new BorrowService(context);

			var message = service.BorrowBook(1, 2);

			Assert.Equal("This book is currently unavailable.", message);
		}

		/// <summary>
		/// Verifies that <see cref="BorrowService.BorrowBook"/> returns a due date message when the book is available.
		/// </summary>
		[Fact]
		public void BorrowBook_ShouldReturnDueDateMessage_WhenBookIsAvailable()
		{
			var context = GetInMemoryDbContext();
			var service = new BorrowService(context);

			var message = service.BorrowBook(1, 1);

			Assert.Contains("Book borrowed! Due on", message);
		}
	}
}
