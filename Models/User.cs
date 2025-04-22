namespace Library.BookBorrowing.Models
{
	/// <summary>
	/// Represents a user who borrows books from the library.
	/// </summary>
	public class User
	{
		/// <summary>
		/// Gets or sets the unique ID of the user.
		/// </summary>
		public int UserId { get; set; }

		/// <summary>
		/// Gets or sets the full name of the user.
		/// </summary>
		public string FullName { get; set; } = string.Empty;
	}
}
