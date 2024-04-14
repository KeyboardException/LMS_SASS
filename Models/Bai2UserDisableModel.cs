using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMS_SASS.Models;

public class Bai2UserDisableModel {
	public required UserModel User { get; set; }

	public required DisableModel Disable { get; set; }
}
