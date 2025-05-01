using Library.BookBorrowing.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Library.BookBorrowing.Data
{
	public class LibraryContext : DbContext
	{
		public LibraryContext(DbContextOptions<LibraryContext> options)
		: base(options)
		{
		}

		public DbSet<Book> Books { get; set; }
		public DbSet<BorrowRecord> BorrowRecords { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
