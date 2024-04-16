using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LMS_SASS.Models;
using LMS_SASS.Databases;
using Microsoft.EntityFrameworkCore;

namespace LMS_SASS.Controllers;

public class AdminController : BaseController
{

    private readonly DatabaseContext _context;

    public AdminController(DatabaseContext context) : base(context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("/admin/accounts")]
    public IActionResult Accounts()
    {
        var results = _context.Users.ToList();
        return View(results);
    }
    [HttpGet("/admin/getdata")]
    public async Task<IActionResult> GetData()
    {
        var results = await _context.Users.ToListAsync();
        return new JsonResult(new { Data = results, TotalItems = results.Count });
    }
    [HttpPost("/admin/create")]
    public async Task<IActionResult> Create(UserModel model)
    {
        model.Created = DateTime.Now;
        _context.Users.Add(model);
        try
        {
            await _context.SaveChangesAsync();
            return Ok(new { success = true });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return Ok(new { success = false });
        }
    }

    [HttpGet]
    [Route("/admin/courses")]
    public IActionResult Courses()
    {
        return View("Courses");
    }
    
    // Tim kiem khoa hoc
    [HttpPost]
    [Route("/course/search")]
    public IActionResult SearchCoursePost(string searchTerm)
    {
        return RedirectToAction("SearchResult", new { searchTerm = searchTerm });
    }

    [HttpGet]
    [Route("/course/searchresult")]
    public IActionResult SearchResult(string searchTerm)
    {
        var courses = !string.IsNullOrEmpty(searchTerm) ?
            DB.Courses.Where(c => c.Name.Contains(searchTerm)).
            ToList() : DB.Courses.ToList();
        return View("ResultSearch", courses);
    }
}

