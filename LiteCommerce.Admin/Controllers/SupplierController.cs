using LiteCommerce.BusinessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            //int rowCount = 0;
            //int pageSize = 10;
            //var listOfSuppliers = DataService.ListSuppliers(page, 10, searchValue, out rowCount);
            //int pageCount = rowCount / pageSize;
            //if(rowCount % pageSize > 0)
            //    pageCount += 1;
            //ViewBag.Page = page;
            //ViewBag.RowCount = rowCount;
            //ViewBag.PageCount = pageCount;
            //ViewBag.SearchValue = searchValue;
            //return View(listOfSuppliers);
            int rowCount = 0;
            int pageSize = 10;
            var listOfSuppliers = DataService.ListSuppliers(page, pageSize, searchValue, out rowCount);
            Models.SupplierPaginationQueryResult model = new Models.SupplierPaginationQueryResult()
            {
                Page = page,
                PageSize = pageSize,
                SearchValue = searchValue,
                RowCount = rowCount,
                Data = listOfSuppliers,
            };
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
        public ActionResult Save()
        {
            return Redirect("Index");
        }
        public ActionResult Delete(string id)
        {
            return View();
        }
    }
}