using LiteCommerce.BusinessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LiteCommerce.Admin.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: Account
        public ActionResult Login(string loginName = "", string password="")
        {
            ViewBag.LoginName = loginName;
            if(Request.HttpMethod == "POST")
            {
                var account = AccountService.Authorize(loginName, CryptHelper.Md5(password));
                if(account == null)
                {
                    ModelState.AddModelError("", "thông tin đăng nhập bị sai");
                    return View();
                }
                FormsAuthentication.SetAuthCookie(CookieHelper.AccountToCookieString(account), false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}