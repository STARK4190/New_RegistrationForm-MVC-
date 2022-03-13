using New_RegistrationForm24Feb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
using Newtonsoft.Json;
namespace New_RegistrationForm24Feb.Controllers
{
    //  [HandleError] //controller level 
    public class HomeController : Controller
    {
        Registration_FormEntities db = new Registration_FormEntities();

        //[HandleError(View ="Error2")] //action level handle error with other Error2 attach

        public ActionResult Index() //insert values registration 
        {
            //throw new Exception();      //route to error.cshtml page(default)

            List<State> state= db.States.ToList();
            ViewBag.State1 = new SelectList(state, "State_Name", "State_Name"); 

            List<Country> Countr = db.Countries.ToList();
            ViewBag.Country1 = new SelectList(Countr, "Country_Name", "Country_Name");

            List<ProgrammingLanguage> Lang = db.ProgrammingLanguages.ToList();
            ViewBag.Lang1 = new SelectList(Lang, "Programming_Name", "Programming_Name");
           
            return View();
        }

        [HttpPost]
        public ActionResult Index(Registration rs) //insert post 
        {
            //imAge code
            string filename = Path.GetFileNameWithoutExtension(rs.ImageFile.FileName); //store filename without extension
            string exten=Path.GetExtension(rs.ImageFile.FileName);  //save extension
            filename = filename + exten;
            rs.Profile_Pic = "~/Images/"+filename;
            filename = Path.Combine(Server.MapPath("~/Images/"),filename); //teling server we have this path add filename
            rs.ImageFile.SaveAs(filename);
            db.Registrations.Add(rs);
            //image code ends

                int a = db.SaveChanges();

                if (a > 0)
                    ViewBag.Message = "<script>alert('inserted')</script>";
                else
                    ViewBag.Message = "<script>alert('not inserted')</script>";

         
            List<State> state = db.States.ToList();
            ViewBag.State1 = new SelectList(state, "State_Name", "State_Name"); 

            List<Country> Countr = db.Countries.ToList();
            ViewBag.Country1 = new SelectList(Countr, "Country_Name", "Country_Name");
            
            List<ProgrammingLanguage> Lang = db.ProgrammingLanguages.ToList();
            ViewBag.Lang1 = new SelectList(Lang, "Programming_Name", "Programming_Name");

            return View();
        }
            
        public ActionResult Show()      //shows database
        {
            var data=db.Registrations.ToList();
            return View(data);
        }

        public ActionResult Delete(int id)  //returns the row u want to del
        {
            var RegIdRow = db.Registrations.Where(model=>model.ID==id).FirstOrDefault();
            return View(RegIdRow);
        }

        [HttpPost]
        public ActionResult Delete(Registration rs) //del the return row
        {
            db.Entry(rs).State =System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            TempData["Message"] = "<script>alert('Data_Deleted')</script>";
            return RedirectToAction("Show");
            //return View();
        }

        
        public ActionResult Details(int id)     //show details
        {
            var Details = db.Registrations.Where(model => model.ID == id).FirstOrDefault();
            return View(Details);
        }

        public ActionResult Edit(int id)
        {
            var Details = db.Registrations.Where(model => model.ID == id).FirstOrDefault();
            return View(Details);
        }


        [HttpPost]
        public ActionResult Edit(Registration rs)
        {
            db.Entry(rs).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        [Authorize]     //here 
        public ActionResult Contact()
        {
            return View();
        }
    }
}