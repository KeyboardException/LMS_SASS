using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LMS_SASS.Controllers;
using LMS_SASS.Databases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LMS_SASS.Controllers
{
    public class ActivityController(DatabaseContext databaseContext) : BaseController(databaseContext)
    {
      public IActionResult Index(){
            return View();
      }

      [HttpGet]
      [Route("/activity/meeting/create")]
      public IActionResult CreateMeetingView() {
          ViewBag.Action = "create";
          return View("CreateMeeting");
      }
      [HttpPost]
      [Route("/activity/meeting/create")]        
      public IActionResult CreateMeeting()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}