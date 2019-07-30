using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ISCrew.Models;

namespace ISCrew.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View("Login");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Volunteer and oppurtunity page.";

            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public ViewResult AddVolunteer()
        {
            return View("AddVolunteer");
        }
        [HttpPost]
        public ViewResult AddVolunteer(VolunteerInfo volunteerInfo)
        {
            VolunteerRepository.AddInfo(volunteerInfo);
            return View(volunteerInfo);
        }
    }
}
