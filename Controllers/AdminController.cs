using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LMS_SASS.Models;
using LMS_SASS.Databases;

namespace LMS_SASS.Controllers;

public class AdminController(DatabaseContext DB) : BaseController(DB) {

    [HttpGet]
    [Route("/admin/accounts")]
    public IActionResult Accounts() {
        return View("Accounts");
    }

	[HttpGet]
    [Route("/admin/courses")]
    public IActionResult Courses() {
        return View("Courses");
    }
}
