using New_RegistrationForm24Feb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace New_RegistrationForm24Feb.Controllers
{

    public class HomeController : Controller
    {
        Registration_FormEntities db = new Registration_FormEntities();

        public ActionResult Index() 
        {
            List<State> state= db.States.ToList();
            ViewBag.State1 = new SelectList(state, "State_ID", "State_Name"); //here problem ("as","as")

            List<Country> Countr = db.Countries.ToList();
            ViewBag.Country1 = new SelectList(Countr, "Country_ID", "Country_Name"); //here problem ("as","as")

            return View();
        }

        [HttpPost]
        public ActionResult Index(Registration rs) //insert 
        {
            //iamge code
            string filename = Path.GetFileNameWithoutExtension(rs.ImageFile.FileName); //store filename without extension
            string exten=Path.GetExtension(rs.ImageFile.FileName);  //save extension
            filename = filename + exten;
            rs.Profile_Pic = "~/Images/"+filename;
            filename = Path.Combine(Server.MapPath("~/Images/"),filename); //teling server we have this path add filename
            rs.ImageFile.SaveAs(filename);
            db.Registrations.Add(rs);
            int a=db.SaveChanges();
            if (a > 0)
                ViewBag.Message = "<script>alert('inserted')</script>";
            else
                ViewBag.Message = "<script>alert('not inserted')</script>";

            return View();
        }
            
        public ActionResult Show()      //shows database
        {
            var data=db.Registrations.ToList();
            return View(data);
        }

    }
}