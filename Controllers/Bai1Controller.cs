using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LMS_SASS.Models;
using LMS_SASS.Databases;
using Microsoft.EntityFrameworkCore.Internal;
using System.Globalization;

namespace LMS_SASS.Controllers;

public class Bai1Controller(DatabaseContext DB) : BaseController(DB) {

    [HttpGet]
    [Route("/bai1")]
    public IActionResult Index(string? search) {
		List<CourseModel> courses;

		if (string.IsNullOrEmpty(search)) {
			courses = DB.Courses.ToList();
		} else {
			courses = DB.Courses
				.Where((c) => c.Name.IndexOf(search) != -1)
				.ToList();
		}

		var list = new List<Bai1CourseUserModel>();

		foreach (var course in courses) {
			var query = from u in DB.Set<UserModel>()
						join cu in DB.Set<CourseUserModel>()
							on u.Id equals cu.UserId
						where cu.CourseId == course.Id
						select u;

			var users = query.ToList();

			foreach (var user in users) {
				var item = new Bai1CourseUserModel {
					Username = user.Username,
					CourseName = course.Name
				};

				list.Add(item);
			}
		}

		ViewBag.Search = search;
        return View("Index", list);
    }
}
