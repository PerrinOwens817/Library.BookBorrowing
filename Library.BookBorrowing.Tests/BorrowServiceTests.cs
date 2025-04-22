using Library.BookBorrowing.Services;
using Xunit;

namespace Library.BookBorrowing.Tests
{
	/// <summary>
	/// Contains unit tests for the <see cref="BorrowService"/> class.
	/// </summary>
	public class BorrowServiceTests
	{
		/// <summary>
		/// Verifies the CheckAvailability return true for an available book.
		/// </summary>
		[Fact]
		public void CheckAvailability_ShouldReturnTrue_WhenBookIsAvailable()
		{
			var service = new BorrowService();
			var result = service.CheckAvailability(1);
			Assert.True(result);
		}

		/// <summary>
		/// Verifies that BorrowBook returns an unavailable message for a borrowed book.
		/// </summary>
		[Fact]
		public void BorrowBook_ShouldReturnUnavailableMessage_IfBookIsBorrowed()
		{
			var service = new BorrowService();
			var message = service.BorrowBook(1, 2);
			Assert.Equal("This book is currently unavailable.", message);
		}

		/// <summary>
		/// Verifies that BorrowBook returns a due date message when the book is available.
		/// </summary>
		[Fact]
		public void BorrowBook_ShouldReturnDueDateMessage_WhenBookIsAvailable()
		{
			var service = new BorrowService();
			var message = service.BorrowBook(1, 1);
			Assert.Contains("Book borrowed! Due on", message);
		}
	}
}
