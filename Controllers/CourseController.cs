using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LMS_SASS.Models;
using LMS_SASS.Databases;

namespace LMS_SASS.Controllers;

public class CourseController(DatabaseContext DB) : BaseController(DB) {

    [HttpGet]
    [Route("/course/create")]
    public IActionResult CreateCourseView() {
        return View("Create");
    }

    [HttpGet]
    [Route("/course/selfEnroll")]
    public IActionResult SelfEnrollCourseView() {
        return View("SelfEnroll");
    }
}
