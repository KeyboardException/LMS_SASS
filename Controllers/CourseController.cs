using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LMS_SASS.Models;
using LMS_SASS.Databases;

namespace LMS_SASS.Controllers;

public class CourseController(DatabaseContext databaseContext) : BaseController(databaseContext) {

    [HttpGet]
    [Route("/course/{Id:int}")]
    public IActionResult ViewCourse(int Id) {
        var course = DB.Courses.Find(Id);

        if (course == null)
            return NotFound();

        return View("View", course);
    }

    [HttpGet]
    [Route("/course/create")]
    public IActionResult CreateCourseView() {
        ViewBag.Action = "create";
        return View("Create");
    }

    [HttpPost]
    [Route("/course/create")]
    public IActionResult CreateCourse(CourseModel course) {
        if (!ModelState.IsValid)
            return CreateCourseView();

        if (course.StartDate > course.EndDate) {
            ModelState.AddModelError("StartDate", "Ngày Bắt Đầu không thể sau Ngày Kết Thúc");
            ModelState.AddModelError("EndDate", "Ngày Bắt Đầu không thể sau Ngày Kết Thúc");
            return CreateCourseView();
        }

        var courseExist = DB.Courses.Any((c) => c.Code == course.Code);

        if (courseExist) {
            ModelState.AddModelError("Code", "Đã có khóa học với mã này rồi!");
            return CreateCourseView();
        }

        course.InviteCode = Utils.RandomString(7);
        DB.Courses.Add(course);
        DB.SaveChanges();

        return RedirectToAction("ViewCourse", new { Id = course.Id });
    }

    [HttpGet]
    [Route("/course/{Id:int}/edit")]
    public IActionResult EditCourseView(int Id) {
        var course = DB.Courses.Find(Id);

        if (course == null)
            return NotFound();

        ViewBag.Action = "edit";
        return View("Edit", course);
    }

    [HttpPost]
    [Route("/course/{Id:int}/edit")]
    public IActionResult EditCourse(CourseModel newCourse, int Id) {
        if (!ModelState.IsValid)
            return CreateCourseView();

        if (newCourse.StartDate > newCourse.EndDate) {
            ModelState.AddModelError("StartDate", "Ngày Bắt Đầu không thể sau Ngày Kết Thúc");
            ModelState.AddModelError("EndDate", "Ngày Bắt Đầu không thể sau Ngày Kết Thúc");
            return CreateCourseView();
        }

        DB.SaveChanges();

        return RedirectToAction("ViewCourse", new { Id = newCourse.Id });
    }

    [HttpGet]
    [Route("/course/selfEnroll")]
    public IActionResult SelfEnrollCourseView() {
        return View("SelfEnroll");
    }
}
