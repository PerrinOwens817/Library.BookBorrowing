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
