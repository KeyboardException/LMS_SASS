using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LMS_SASS.Models;
using LMS_SASS.Databases;
using Microsoft.EntityFrameworkCore.Internal;
using System.Globalization;

namespace LMS_SASS.Controllers;

public class Bai2Controller(DatabaseContext DB) : BaseController(DB) {

    [HttpGet]
    [Route("/bai2")]
    public IActionResult Index() {
		var users = DB.Users.ToList();

		List<Bai2UserDisableModel> list = new();

		foreach (var user in users) {
			var disable = DB.DisableModels
				.Where((d) => d.UserId == user.Id)
				.FirstOrDefault();

			if (disable == null) {
				disable = new DisableModel {
					UserId = user.Id,
					Disabled = false,
					LogTime = null
				};
			}

			list.Add(new Bai2UserDisableModel {
				User = user,
				Disable = disable
			});
		}

		return View(list);
    }

	[HttpPost]
    [Route("/bai2/{userId:int}/{disabled:bool}")]
	public IActionResult ChangeDisableState(int userId, bool disabled) {
		var disable = DB.DisableModels
			.Where((d) => d.UserId == userId)
			.FirstOrDefault();

		if (disable == null) {
			disable = new DisableModel {
				UserId = userId,
				Disabled = disabled,
				LogTime = DateTime.Now
			};

			DB.DisableModels.Add(disable);
			DB.SaveChanges();
		} else {
			disable.Disabled = disabled;
			disable.LogTime = DateTime.Now;
			DB.SaveChanges();
		}

		return Json(new {
			Message = "OK"
		});
	}
}
