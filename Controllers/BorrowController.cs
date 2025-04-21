using Microsoft.AspNetCore.Mvc;
using Library.BookBorrowing.Models;
using Library.BookBorrowing.Services;

namespace Library.BookBorrowing.Controllers
{
	public class BorrowController : Controller
	{
		private readonly BorrowService _borrowService = new();

		public IActionResult Index()
		{
			var availableBooks = _borrowService.GetAvailableBooks();
			return View(availableBooks);
		}

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
