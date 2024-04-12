using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LMS_SASS.Models;

namespace LMS_SASS.Controllers;

public class LoginController : Controller {
    [HttpGet]
    [Route("/login")]
    public IActionResult LoginPage() {
        return View("Index");
    }

	[HttpPost]
	[Route("/login")]
	public IActionResult PerformLogin(LoginFormCredentialModel data) {
		return RedirectToAction("Index", "Home");
	}
}