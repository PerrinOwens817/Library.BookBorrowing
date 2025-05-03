using Microsoft.EntityFrameworkCore;
using Library.BookBorrowing.Models;
using Library.BookBorrowing.Services;
using Library.BookBorrowing.Data;

namespace Library.BookBorrowing
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Register the database context
			builder.Services.AddDbContext<LibraryContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryConnection")));

			// Register custom services
			builder.Services.AddScoped<BorrowService>();

			// Add MVC support
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// SEEDING STARTS HERE
			using (var scope = app.Services.CreateScope())
			{
				var context = scope.ServiceProvider.GetRequiredService<LibraryContext>();
				context.Database.EnsureDeleted(); // resets the DB
				context.Database.Migrate();      // rebuilds schema

				context.Books.AddRange(
					new Book { Title = "The Giver", IsBorrowed = false },
					new Book { Title = "The Hobbit", IsBorrowed = false },
					new Book { Title = "To Kill a Mockingbird", IsBorrowed = false }
				);
				context.SaveChanges();
			}
			// SEEDING ENDS HERE


			// Configure the HTTP request pipeline
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
