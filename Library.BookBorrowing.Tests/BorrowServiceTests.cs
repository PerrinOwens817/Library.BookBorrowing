using Library.BookBorrowing.Services;
using Xunit;

namespace Library.BookBorrowing.Tests
{
	public class BorrowServiceTests
	{
		[Fact]
		public void CheckAvailability_ShouldReturnTrue_WhenBookIsAvailable()
		{
			var service = new BorrowService();
			var result = service.CheckAvailability(1);
			Assert.True(result);
		}

		[Fact]
		public void BorrowBook_ShouldReturnUnavailableMessage_WhenBookIsAlreadyBorrowed()
		{
			var service = new BorrowService();
			var message = service.BorrowBook(1, 2);
			Assert.Equal("This book is currently unavailable.", message);
		}

		[Fact]
		public void BorrowBook_ShouldReturnDueDateMessage_WhenBookIsAvailable()
		{
			var service = new BorrowService();
			var message = service.BorrowBook(1, 1);
			Assert.Contains("Book borrowed! Due on", message);
		}
	}
}
