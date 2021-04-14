using LiteCommerce.BusinessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            var model = HRService.Employee_List();
            return View(model);
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Edit(string id)
        {
            return View();
        }
        public ActionResult Delete(string id)
        {
            return View();
        }
        public ActionResult Save()
        {
            return View();
        }
    }
}