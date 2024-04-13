using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LMS_SASS.Models;
using LMS_SASS.Databases;

namespace LMS_SASS.Controllers;

public class HomeController(DatabaseContext DB) : BaseController(DB) {

    [HttpGet]
    [Route("/")]
    public IActionResult Index() {
        return View();
    }

    [HttpGet]
    [Route("/calendar")]
    public IActionResult Calendar() {
        return View();
    }

    [HttpGet]
    [Route("/sandbox")]
    public IActionResult Sandbox() {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
