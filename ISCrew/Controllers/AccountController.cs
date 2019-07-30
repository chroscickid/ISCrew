using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ISCrew.Models.ViewModels;
using ISCrew.Models;

namespace ISCrew.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
      //  private UserManager<AppUser> userManager;
        //private SignInManager<AppUser> signInManager;
    }
}
