using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ISCrew.Models;

namespace ISCrew.Controllers
{
    public class VolunteerController : Controller
    {
        private VolunteerRepository repository;
        public VolunteerController(VolunteerRepository repo)
        {
            repository = repo;
        }
        public ViewResult List() => View(repository.VolunteerInformation);
    }
}
