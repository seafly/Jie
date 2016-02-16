using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;
using StudyMVC.Models;

namespace StudyMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string returnUrl)
        {
            IApplicationContext context = ContextRegistry.GetContext();
            IObjectFactory factory = (IObjectFactory)context;
            Person person = factory.GetObject("Person") as Person;

            string mm = person.Save();
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}