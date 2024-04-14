using FluentNHibernate.Conventions.AcceptanceCriteria;
using LMS_SASS.Databases;
using LMS_SASS.Interfaces;
using LMS_SASS.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMS_SASS.Controllers
{
    public class ProfileController(DatabaseContext DB, ISessionService session) : BaseController(DB)
    {
 

        [HttpGet("/user/{id}")]
        public IActionResult Index(int id)
        {
            
            var user = DB.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return View(user);
            }
        }
    }
}
