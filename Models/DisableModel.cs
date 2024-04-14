using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMS_SASS.Models;

[Table("tblDisable")]
[PrimaryKey(nameof(Id))]
public class DisableModel {
	[Key]
	public int Id { get; set; }

	public required int UserId { get; set; }

	public required bool Disabled { get; set; } = false;

	public DateTime? LogTime { get; set; } = null;
}