using LMS_SASS.Databases;
using Microsoft.AspNetCore.Mvc;

namespace LMS_SASS.Controllers;

public class Bai1Controller(DatabaseContext databaseContext) : BaseController(databaseContext) {

    [HttpGet]
    [Route("/bai1")]
    public IActionResult Index() {
		var courses = DB.Courses.ToList();
        return View(courses);
    }
}
