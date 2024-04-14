using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LMS_SASS.Controllers;
using LMS_SASS.Databases;
using LMS_SASS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LMS_SASS.Controllers
{
  public class ActivityController(DatabaseContext databaseContext) : BaseController(databaseContext)
  {
    public IActionResult Index()
    {
      return View();
    }

    [HttpGet]
    [Route("/course/{courseId:int}/activity/meeting/create")]
    public IActionResult CreateMeetingView(int courseId)
    {
      ViewBag.Action = "create";
      ViewBag.CourseId = courseId;
      return View("CreateMeeting");
    }
    [HttpPost]
    [Route("/activity/meeting/create")]
    public IActionResult CreateMeeting(ActivityQuizViewModel model)
    {
      if (model.Activity.StartDate >= DateTime.UtcNow && model.Activity.EndDate > model.Activity.StartDate)
      {
        MeetingModel meeting = new MeetingModel
        {
          Id = model.Meeting.Id,
          url = model.Meeting.url
        };
        DB.Meeting.Add(meeting);
        DB.SaveChanges();
        int meetingId = meeting.Id;

        ActivityModel activity = new ActivityModel
        {
          Id = model.Activity.Id,
          CourseId = model.Activity.CourseId,
          Created = DateTime.UtcNow,
          Course = model.Activity.Course,
          Name = model.Activity.Name,
          Type = ActivityModel.TYPE_MEETING,
          InstanceId = meetingId,
          StartDate = model.Activity.StartDate,
          EndDate = model.Activity.EndDate,
        };

        DB.Activities.Add(activity);
        DB.SaveChanges();
        return RedirectToAction( "ViewCourse","Course", new { Id = model.Activity.CourseId});
      }
      return RedirectToAction("CreateMeetingView", new {courseId= model.Activity.CourseId});
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View("Error!");
    }
  }
}