using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPMVCWEbApiSample.Controllers
{
    public class SampleController : Controller
    {
        // GET: Sample
        public ActionResult Index()
        {
            ViewData["MyDateTime"] = DateTime.Now;
            ViewBag.Name = "Sagar";
            return View();
        }
    }
}