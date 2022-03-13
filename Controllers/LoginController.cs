using New_RegistrationForm24Feb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace New_RegistrationForm24Feb.Controllers
{
    public class LoginController : Controller
    {
        Registration_FormEntities db = new Registration_FormEntities();

        public ActionResult Index() //Regustered User login
        {
            return View();    
        }

        [HttpPost]
        public ActionResult Index(Registered_Employee re, string ReturnUrl)
        {
            if (IsValid(re) == true)   //login succesfull condition
            {
                Console.WriteLine("Login");
                FormsAuthentication.SetAuthCookie(re.Username, true); //true for temporary cookie
                Session["Username"] = re.Username.ToString();
                if (ReturnUrl != null)
                {
                    Console.WriteLine("return urlnot onulll");
                    RedirectToAction(ReturnUrl);
                }
                else
                {
                    Console.WriteLine("redirect to index home");
                    return RedirectToAction("Index", "Home");   //redirec to 
                }

            }
            else
            {
                Console.WriteLine("wrong cred");
                return View();
            }
            return null;
        }

        public bool IsValid(Registered_Employee re) //checking login user is valid 
        {
            var info = db.Registered_Employee.Where(Model => Model.Username == re.Username && Model.Password == re.Password).FirstOrDefault(); //check login credentials and assign row to it    
            return (re.Username == info.Username && re.Password == info.Password);  //if valid TRUE
        }
    }
}