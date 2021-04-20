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
            string connectionstring = ConfigurationManager.ConnectionStrings["litecommercedb"].ConnectionString;
            ICityDAL dal = new CityDAL(connectionstring);
            var data = dal.List();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Pagination(int page, int pageSize,String searchValue)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["LiteCommerceDB"].ConnectionString;
            //ISupplierDAL dal = new SupplierDAL(connectionString);
            //var data = dal.List(page, pageSize, searchValue);
            //return Json(data, JsonRequestBehavior.AllowGet);
            string connectionString = ConfigurationManager.ConnectionStrings["LiteCommerceDB"].ConnectionString;
            ICategoryDAL dal = new CategoryDAL(connectionString);
            var data = dal.List(page, pageSize, searchValue);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        // test URL: hTTP://localhost:/Test/Pagination?page=2&pageSize=10&SearchValue=
    }
}