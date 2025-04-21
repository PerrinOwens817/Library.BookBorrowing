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
	}
}
