using System.ComponentModel.DataAnnotations;

namespace LMS_SASS.Models;

public class Bai1CourseUserModel {
	public required string Username { get; set; }

	public required string CourseName { get; set; }
}