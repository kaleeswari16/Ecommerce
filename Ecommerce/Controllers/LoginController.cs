using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Ecommerce.Controllers
{
    public class LoginController : Controller
    {

       
        public IActionResult Login_Page()
        {
           
            return View();
        }
        public IActionResult Insert(Login log)
        {
            Logindb db = new Logindb();
            db.saverecord(log);

            return View("Login_Page");
        }
       
        public IActionResult List()
        {
            Logindb log = new Logindb();
            var obj=log.logins();
            return View(obj);
        }
        public IActionResult Invoice()
        {

            return View();
        }
        public IActionResult Invoices()
        {
            Logindb log = new Logindb();
            var obj = log.logins();
            return View(obj);
           
        }
    }
}
