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

	[Display(Name = "Tên Khóa Học")]
	[DataType(DataType.Text)]
	[MaxLength(32)]
	public required string Name { get; set; }

	[Display(Name = "Mã Khóa Học")]
	[DataType(DataType.Text)]
	[MaxLength(32)]
	public required string Code { get; set; }

	[Display(Name = "Mã Tham Gia")]
	[DataType(DataType.Text)]
	[MaxLength(8)]
	public string? InviteCode { get; set; } = null;

	[Display(Name = "Môn Học")]
	[DataType(DataType.Text)]
	[MaxLength(32)]
	public required string Subject { get; set; }

	[Display(Name = "Ngày Bắt Đầu")]
	[DataType(DataType.DateTime)]
	public required DateTime StartDate { get; set; }

	[Display(Name = "Ngày Kết Thúc")]
	[DataType(DataType.DateTime)]
	public required DateTime EndDate { get; set; }

	[StringLength(10, MinimumLength = 10, ErrorMessage = "VerifyKey phải là 10 ký tự!")]
	[RegularExpression(@"^(\d{1})([a-zA-Z0-9]{9})$", ErrorMessage = "VerifyKey phải bắt đầu bằng một chữ số!")]
	[DataType(DataType.Text)]
	[MaxLength(10)]
	public required string VerifyKey { get; set; }
}
