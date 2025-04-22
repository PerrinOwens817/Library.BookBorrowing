using Microsoft.AspNetCore.Mvc;
using Library.BookBorrowing.Services;

namespace Library.BookBorrowing.Controllers
{
	/// <summary>
	/// Controller responsible for handling book borrowing operations.
	/// </summary>
	public class BorrowController : Controller
	{
		private readonly BorrowService _borrowService = new();

		/// <summary>
		/// Displays a list of available books to borrow.
		/// </summary>
		/// <returns>A view displaying available books.</returns>
		public IActionResult Index()
		{
			var availableBooks = _borrowService.GetAvailableBooks();
			return View(availableBooks);
		}

		/// <summary>
		/// Handles the borrowing of a book by a user.
		/// </summary>
		/// <param name="userId">The ID for the user borrowing the book.</param>
		/// <param name="bookId">The ID of the book to borrow.</param>
		/// <returns>A view with an updated list of available books and a status message.</returns>
		[HttpPost]
		public IActionResult Borrow(int userId, int bookId)
		{
			if (userId == 0 || bookId == 0)
			{
				ViewBag.Message = "Please enter all required info.";
			}
			else
			{
				ViewBag.Message = _borrowService.BorrowBook(userId, bookId);
			}

			var books = _borrowService.GetAvailableBooks();
			return View("Index", books);
		}
	}
}
