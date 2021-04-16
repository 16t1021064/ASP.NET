using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiteCommerce.DataLayers;
using LiteCommerce.DomainModels;
using System.Configuration;
using LiteCommerce.DataLayers.SQLServer;

namespace LiteCommerce.Admin.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LiteCommerceDB"].ConnectionString;
            ICountryDAL dal = new CountryDAL(connectionString);
            var data = dal.List();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}