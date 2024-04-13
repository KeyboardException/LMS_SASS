using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using LMS_SASS.Databases;

namespace LMS_SASS.Controllers;

public class BaseController(DatabaseContext DB) : Controller {
	public override void OnActionExecuting(ActionExecutingContext context) {
		// Assuming you've already set the username in your session upon login
		var userId = HttpContext.Session.GetInt32("UserId");
		var valid = true;

		if (userId == null) {
			valid = false;
		} else {
			var user = DB.Users.Find(userId);

			if (user == null) {
				valid = false;
			} else {
				ViewBag.User = user;
			}
		}

		if (!valid) {
			context.Result = new RedirectToActionResult("LoginPage", "Login", null);
			HttpContext.Session.Clear();
		}

		base.OnActionExecuting(context);
	}
}
