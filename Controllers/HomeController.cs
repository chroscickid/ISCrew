using AdministrationMng.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdministrationMng.Controllers
{
    public class HomeController : Controller
    {


        private Database1Entities5 db = new Database1Entities5();


        //This Displays results Of Opportunities page----------------------------------------------Done Display Fxn---------------------------------------------------------------
        public ActionResult ManageOp()
        {
            {// this action is for ManagesOp
                if (Session["Username"] != null)
                {
                    ViewBag.Message = "FirstScreen";
                    var opportunity = db.Opportunities;
                    return View(opportunity.ToList());
                }
                else
                {

                    return RedirectToAction("Index", "Home");

                }
            }
           
        }

        //End Method Opportunites ---------------------------------------------------Done Display Fxn---------------------------------------------------------------


        //Abandon the session called by logout----------------------------------------------Done Display Fxn---------------------------------------------------------------
        public ActionResult Logout()
        {
            Session.Abandon();
            ViewBag.Message = "You have successfully Logged out";

            return View("~/Views/Home/Index.cshtml");
        }
        //end method logout ------------------------------------------------Done Display Fxn---------------------------------------------------------------

        //Displays the Login ------------------------------------------------Done Display Fxn-----------------------------------------------------------
        public ViewResult Index()
        {

            return View();
        }
        //Done index first view opened --------------------------------------------Done Display Fxn-----------------------------------------------------------

        //This is submit and allow login--------------------------------------------Done Display Fxn ----------------------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Table u)
        {
            // this action is for handle post (login)
            if (ModelState.IsValid) // this is check validity
            {
                using (Database1Entities5 dc = new Database1Entities5())
                {
                    var v = dc.Tables.Where(a => a.Username.Equals(u.Username) && a.Password.Equals(u.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["Username"] = v.Username.ToString();
                        Session["Password"] = v.Password.ToString();
                        return RedirectToAction("About");
                    }
                }
            }

            ViewBag.Message = "Your Username or Password could not be found";
            return View(u);
        }//Login end method--------------------------------------------------------------Done display Fxn------------------------------------------------------------------

        //this is decision point if want to know Volunteer or Opportunity Info-------------------------------------------Done---Display Fxn---------------------------------------
        public ActionResult About()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {return RedirectToAction("Index","Home");}
        }
        //this is decision point if want to know Volunteer or Opportunity Info-------------------------------------------Done---Display Fxn---------------------------------------
    }
}