using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMS_SASS.Models;

[Table("Courses")]
[PrimaryKey(nameof(Id))]
[Index(nameof(Code), IsUnique = true)]
public class CourseModel {
	[Key]
	public required int Id { get; set; }

	[DataType(DataType.Text)]
	[MaxLength(32)]
	public required string Name { get; set; }

	[DataType(DataType.Text)]
	[MaxLength(32)]
	public required string Code { get; set; }

	[DataType(DataType.Text)]
	[MaxLength(32)]
	public required string Subject { get; set; }

	[DataType(DataType.DateTime)]
	public required DateTime StartDate { get; set; }

	[DataType(DataType.DateTime)]
	public required DateTime EndDate { get; set; }
}
