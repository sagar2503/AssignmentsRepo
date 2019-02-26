using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPMVCWebAppSample.Models;

namespace ASPMVCWebAppSample.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeViewModel EmployeeVM = new EmployeeViewModel()
            {
                Id = 1,
                Name = "Sagar",
                City = "Pune",
                Gender = "Male"

            };
            
            return View();
        }

        public ViewResult Details()
        {

            EmployeeViewModel EmployeeVM = new EmployeeViewModel()
            {
                Id = 1,
                Name = "Sagar",
                City = "Pune",
                Gender = "Male"

            };
            return View(EmployeeVM);
        }
    }
}