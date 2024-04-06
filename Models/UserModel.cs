using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMS_SASS.Models;

[Table("Users")]
[PrimaryKey(nameof(Id))]
[Index(nameof(Username), IsUnique = true)]
public class UserModel {
	[Key]
	public required int Id { get; set; }

	[DataType(DataType.Text)]
	[MaxLength(32)]
	public required string Username { get; set; }

	[DataType(DataType.Text)]
	[MaxLength(32)]
	public required string Name { get; set; }

	[DataType(DataType.Password)]
	[MaxLength(128)]
	public required string Password { get; set; }

	[DataType(DataType.DateTime)]
	public required DateTime DOB { get; set; }

	[DataType(DataType.PhoneNumber)]
	[MaxLength(14)]
	public required string Phone { get; set; }

	[DataType(DataType.EmailAddress)]
	[MaxLength(32)]
	public required string Email { get; set; }

	[DataType(DataType.Text)]
	[MaxLength(128)]
	public required string Address { get; set; }

	[DataType(DataType.Text)]
	[MaxLength(8)]
	public required string Role { get; set; }

	[DataType(DataType.DateTime)]
	public required DateTime Created { get; set; }
}
