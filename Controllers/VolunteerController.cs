using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdministrationMng;
using AdministrationMng.Models;


namespace AdministrationMng.Controllers
{
    public class VolunteerController : Controller
    {
        private Database1Entities5 db = new Database1Entities5();

       

        // GET: Volunteer
        public ActionResult Index()
        {
            if (Session["Username"] != null)
            {
              
                var volunteers = db.Volunteers.Include(v => v.VImage).Include(v => v.Avaliability);
                return View(volunteers.ToList());
               
            }
            else
            {

                return RedirectToAction("Index", "Home");

            }
            
        }

        public ActionResult EditRedirect()
        {
            if (Session["Username"] != null)
            {

                ViewBag.Message = "EditV";
                var volunteer= db.Volunteers;
                volunteer.ToList();


                return View("Index", volunteer);

            }
            else
            {

                return RedirectToAction("Index", "Home");

            }

        }

        public ActionResult OEditRedirect()
        {
            if (Session["Username"] != null)
            {
                ViewBag.Message = "Edit";
                var opportunity = db.Opportunities;
                opportunity.ToList();
                

                return View("../Home/ManageOp",opportunity);

            }
            else
            {

                return RedirectToAction("Index", "Home");

            }

        }

        public ActionResult ODeleteRedirect() { 
            if (Session["Username"] != null)
            {
                ViewBag.Message = "Delete";
                var opportunity = db.Opportunities;
                opportunity.ToList();


                return View("../Home/ManageOp", opportunity);

            }
            else
            {

                return RedirectToAction("Index", "Home");

            }

        }

        public ActionResult Result()
        {
            if (Session["Username"] != null)
            {
                var volunteers = db.Volunteers.Include(v => v.VImage).Include(v => v.Avaliability);
                return View(volunteers.ToList());

            }
            else
            {

                return RedirectToAction("Index", "Home");


            }

        }

        public ActionResult Search(string searchBy, string search)
        {
            if (Session["Username"] != null)
            {
               
                if (searchBy == "VFname")
                {
                    return View(db.Volunteers.Where(x => x.VFname.StartsWith(search) || search == null).ToList());
                }
                else
                {
                    return View(db.Volunteers.Where(x => x.VLname.StartsWith(search) || search == null).ToList()); 
                   
                }
               

            }
            else
            {

                return RedirectToAction("Index", "Home");


            }
           
        }

       
        
        
        //Search Begin Method Opportunities   ---------------------------------------Done----Display and Function---------------------------------------------------------------------------
        public ActionResult OSearch(string searchBy, string search)
        {
            if (Session["Username"] != null)
            {
                if (searchBy == "Date")
                {
                    DateTime result;
                    
                    if ((!DateTime.TryParse(search, out result)))
                    {
                        ViewBag.Message = "Invalid date format, the format should be DD/MM/YYYY.";
                        return View(db.Opportunities.ToList());
                    }
                    else
                    { DateTime parsedDate = DateTime.Parse(search);
                        return View(db.Opportunities.Where(x => x.Date == parsedDate || search == null).ToList());}
            }
            if (searchBy == "Center")
            {return View(db.Opportunities.Where(x => x.Center.StartsWith(search) || search == null).ToList()); }
            else
            {return View(db.Opportunities.Where(x => x.OName.StartsWith(search) || search == null).ToList());}
        }
            else
            {return RedirectToAction("Index", "Home");}}

        //End Search Opportunities---------------------------------------------------Done--Display, and Function-------------------------------------------------------------------

            //Filter Opportunities-------------------------------------------DOne--------------------------------------------------------------------------------------------------
        public ActionResult OMethodFilter(string Filter)
        {
            if (Session["Username"] != null)
            {if (Filter == "Center")
                    {
                        return RedirectToAction("OMethodFilter2", "Volunteer");
                    }

                    if (Filter == "Recent")
                    {
                    ViewBag.Message = "Filtered by Most Recent(60 days)";
                    DateTime T = DateTime.Now;
                        DateTime MaxDay = T.AddDays(60);
                        DateTime MinDay = T.AddDays(-60);
                        
                        var list = from r in db.Opportunities
                                   orderby r.Date

                                   where r.Date > MinDay && r.Date < MaxDay 
                                   select r;
                        return View(list);
                    }
                    else
                        return View(db.Opportunities.ToList()); }
            else
            { return RedirectToAction("Index", "Home"); }

            }

        public ActionResult OMethodFilter2(string var)
        {
            if (Session["Username"] != null)
            {
                ViewBag.Center = (from r in db.Opportunities
                                  select r.Center).Distinct();

                var list = from r in db.Opportunities
                           orderby r.Center
                           where r.Center == var || var == null || var == ""
                          
                           select r;
return View(list);
            }
            else
            {

                return RedirectToAction("Index", "Home"); } }
        //Filter Opportunities-------------------------------------------DOne--------------------------------------------------------------------------------------------------



















        public ActionResult MethodFilter(string Volunteerstatus)
         {
            if (Session["Username"] != null)
            {
                using (Database1Entities5 dc = new Database1Entities5())
                {

                    if (Volunteerstatus == "Approved")
                    {
                        var volunteers = from r in db.Volunteers
                                         orderby r.VFname
                                         where r.Status == Volunteerstatus || Volunteerstatus == null || Volunteerstatus == ""
                                         select r;
                        return View(volunteers);
                    }
                    if (Volunteerstatus == "Pending Approval")
                    {
                        var volunteers = from r in db.Volunteers
                                         orderby r.VFname
                                         where r.Status == Volunteerstatus || Volunteerstatus == null || Volunteerstatus == ""
                                         select r;
                        return View(volunteers);
                    }
                    if (Volunteerstatus == "Disapproved")
                    {
                        var volunteers = from r in db.Volunteers
                                         orderby r.VFname
                                         where r.Status == Volunteerstatus || Volunteerstatus == null || Volunteerstatus == ""
                                         select r;
                        return View(volunteers);
                    }
                    if (Volunteerstatus == "All")
                    {
                        return View(dc.Volunteers.Include(v => v.VImage).Include(v => v.Avaliability).ToList());

                        
                    }
                    if (Volunteerstatus == "Inactive")
                    {
                        var volunteers = from r in db.Volunteers
                                         orderby r.VFname
                                         where r.Status == Volunteerstatus || Volunteerstatus == null || Volunteerstatus == ""
                                         select r;
                        return View(volunteers);


                    }
                    if (Volunteerstatus == "both")
                    {
                        var t = "Approved";
                        var p = "Pending Approval";

                        var volunteers = from r in db.Volunteers
                                         orderby r.VFname
                                         where r.Status == t || Volunteerstatus == null || Volunteerstatus == ""
                                         || r.Status == p || Volunteerstatus == null || Volunteerstatus == ""
                                         select r;
                        return View(volunteers);
                    }
                    else
                    
                    return View(db.Volunteers.Include(v => v.VImage).Include(v => v.Avaliability).ToList());

                }
              

            }
            else
            {

                return RedirectToAction("Index", "Home");


            }

        }

       



        public ActionResult MatchField()
        { 
            

            if (Session["Username"] != null)
            {
                
                List<object> myModel = new List<object>();
                myModel.Add(db.Volunteers.ToList());
                myModel.Add(db.Opportunities.ToList());
                
                return View(myModel);
            }
            
            else
            { return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult OMatchRedirect()
        {
            if (Session["Username"] != null)
            {
                ViewBag.Message = "OMatch";
                List<object> myModel = new List<object>();
                myModel.Add(db.Volunteers.ToList());
                myModel.Add(db.Opportunities.ToList());


                return View("../Volunteer/MatchField",myModel);

            }
            else
            {

                return RedirectToAction("Index", "Home");

            }

        }
        public ActionResult VMatchRedirect()
        {
            if (Session["Username"] != null)
            {
                ViewBag.Message = "VMatch";
                List<object> myModel = new List<object>();
                myModel.Add(db.Volunteers.ToList());
                myModel.Add(db.Opportunities.ToList());


                return View("../Volunteer/MatchField", myModel);

            }
            else
            {

                return RedirectToAction("Index", "Home");

            }

        }
        public ActionResult MatchRedirect()
        {
            if (Session["Username"] != null)
            {
                ViewBag.Message = "VMatchField";
                List<object> myModel = new List<object>();
                myModel.Add(db.Volunteers.ToList());
                myModel.Add(db.Opportunities.ToList());


                return View("../Volunteer/MatchField", myModel);

            }
            else
            {

                return RedirectToAction("Index", "Home");

            }

        }

        // GET: Volunteer/Details/5
        public ActionResult DetailsMatchV(string Fid, string Lid)
        {
            if (Fid == null || Lid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            Volunteer volunteer = db.Volunteers.Find(Fid, Lid);
            
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            List<object> myModel = new List<object>();

           string c= volunteer.Center;
            
             var list = from r in db.Volunteers
                        where (r.VLname == Lid && r.VFname == Fid) 
                        select r;


            var list2 = from r in db.Opportunities
                        orderby r.OName
                        where r.Center == c || c == null || c == ""
                        select r;

            myModel.Add(list.ToList());
            myModel.Add(list2.ToList());


            return View(myModel);
        }



        // GET: Volunteer/Details/5
        public ActionResult DetailsMatchU(string Name)
        {
            if (Name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Opportunity opportunity = db.Opportunities.Find(Name);

            if (opportunity == null)
            {
                return HttpNotFound();
            }
            List<object> myModel = new List<object>();

            string c = opportunity.Center;

            var list = from r in db.Opportunities
                       where (r.OName == Name)
                       select r;


            var list2 = from r in db.Volunteers
                        orderby r.VFname
                        where r.Center == c || c == null || c == ""
                        select r;

            myModel.Add(list.ToList());
            myModel.Add(list2.ToList());


            return View(myModel);
        }
        // GET: Volunteer/Details/5
        public ActionResult Details(string Fid, string Lid)
        {
            if (Fid == null || Lid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(Fid, Lid);
        


            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // GET: Volunteer/Create
        public ActionResult Create()
        {
            ViewBag.VFname = new SelectList(db.VImages, "VFname", "VFname");
            ViewBag.VFname = new SelectList(db.Avaliabilities, "VFname", "VFname");
            return View();
        }

        // POST: Volunteer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VFname,VLname,VUsername,VPassword,VEdu,Center,VSkills,VAddress,VWorkPhone,VHomePhone,VCellPhone,VEmail,VCurrentLicense,VDL,VSS,ECFname,ECLname,ECHomePhone,ECWorkPhone,ECEmail,ECAddress,Status")] Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                db.Volunteers.Add(volunteer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VFname = new SelectList(db.VImages, "VFname", "VFname", volunteer.VFname);
            ViewBag.VFname = new SelectList(db.Avaliabilities, "VFname", "VFname", volunteer.VFname);
            return View(volunteer);
        }

        // GET: Volunteer/Edit/5
        public ActionResult Edit(string Fid, string Lid)
        {
            if (Fid== null || Lid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(Fid, Lid);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            ViewBag.VFname = new SelectList(db.VImages, "VFname", "VFname", volunteer.VFname);
            ViewBag.VFname = new SelectList(db.Avaliabilities, "VFname", "VFname", volunteer.VFname);
            return View(volunteer);
        }

        // POST: Volunteer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VFname,VLname,VUsername,VPassword,VEdu,Center,VSkills,VAddress,VWorkPhone,VHomePhone,VCellPhone,VEmail,VCurrentLicense,VDL,VSS,ECFname,ECLname,ECHomePhone,ECWorkPhone,ECEmail,ECAddress,Status")] Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volunteer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VFname = new SelectList(db.VImages, "VFname", "VFname", volunteer.VFname);
            ViewBag.VFname = new SelectList(db.Avaliabilities, "VFname", "VFname", volunteer.VFname);
            return View(volunteer);
        }

        // GET: Volunteer/Delete/5
        public ActionResult Delete(string Fid, string Lid)
        {
            if (Fid == null || Lid ==null )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(Fid, Lid);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // POST: Volunteer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Volunteer volunteer = db.Volunteers.Find(id);
            db.Volunteers.Remove(volunteer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }







//Create Opportunity Controls--------------------------------------Fxn----------------------------------------------------------------
        public ActionResult CreateOp()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {

                return RedirectToAction("Index", "Home");

            }
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOp([Bind(Include = "OName,Date,Center")] Opportunity opportunity)
        {

            if (Session["Username"] != null)
            {
                var CurrentName = opportunity.OName;
                Opportunity conflict = db.Opportunities.Find(CurrentName);

                if (conflict != null)
                {
                    ViewBag.Message = "Please enter a Unique Value" +CurrentName;

                    return View("CreateOp");
                }
                if (ModelState.IsValid)
                {
                    db.Opportunities.Add(opportunity);
                    db.SaveChanges();
                    return RedirectToAction("ManageOp", "Home");
                }
                return View(opportunity);
            }
            else
            {

                return RedirectToAction("Index", "Home");

            }
            
        }
        //Create Opportunity--------------------------------------Fxn----------------------------------------------------------------

        //Edit Opportunity--------------------------------------Fxn----------------------------------------------------------------
        public ActionResult EditOpportunity(string Name)
        {
                if (Name == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }


               Opportunity opportunity = db.Opportunities.Find(Name);

                if (opportunity == null)
                {
                    return HttpNotFound();
                }
          var value = opportunity.Date;
            DateTime Here = value.Date;
             
           
            ViewBag.Message = "The Original Date was Designated for " + Here;
                return View(opportunity);
            }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOpportunity([Bind(Include = "OName,Date,Center")] Opportunity op)
        {
            if (Session["Username"] != null)
            {

            if (ModelState.IsValid)
            {
                db.Entry(op).State = EntityState.Modified;

                   db.SaveChanges();
                   return RedirectToAction("ManageOp", "Home");}
            
            return View(op);


            }
            else
            {

                return RedirectToAction("Index", "Home");

            }
        }


        //Edit Opportunity--------------------------------------Fxn----------------------------------------------------------------

        // GET: Volunteer/Delete/5
        public ActionResult DeleteOpportunity(string Name)
        {
            if (Name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opportunity opportunities = db.Opportunities.Find(Name);
            if (opportunities == null)
            {
                return HttpNotFound();
            }
            return View(opportunities);
        }

        // POST: Volunteer/Delete/5
        [HttpPost, ActionName("DeleteOpportunity")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOpportunityConfirm(string Name)
        {
          Opportunity opportunity = db.Opportunities.Find(Name);
            db.Opportunities.Remove(opportunity);
            db.SaveChanges();
            return RedirectToAction("ManageOp", "Home");
        }

        // GET: Volunteer/Details/5
        public ActionResult DetailO(string Name)
        {
            if (Name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opportunity opportunity = db.Opportunities.Find(Name);
            if (opportunity == null)
            {
                return HttpNotFound();
            }
            return View(opportunity);
        }
    }





}
