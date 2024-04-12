using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LMS_SASS.Models;

namespace LMS_SASS.Controllers;

public class HomeController() : Controller {

    [HttpGet]
    [Route("/")]
    public IActionResult Index() {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
