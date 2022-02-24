using New_RegistrationForm24Feb.Models;
using System;
using System.Collections.Generic;
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
            ViewBag.State1 = new SelectList(state,"State_ID","State_Name"); //here problem ("as","as")

            List<Country> Countr = db.Countries.ToList();
            ViewBag.Country1 = new SelectList(Countr, "Country_ID", "Country_Name"); //here problem ("as","as")

            return View();
        }

        [HttpPost]
        public ActionResult Index(Registration rs) //insert 
        {
              db.Registrations.Add(rs);
              ViewBag.Msg = "<script>alert('done')</script>";
              return View();
        }

    }
}