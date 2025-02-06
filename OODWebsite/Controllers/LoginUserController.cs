using OODWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace OODWebsite.Controllers
{
    public class LoginUserController : Controller
    {
        PortalDBDataContext db = new PortalDBDataContext();
        // GET: LoginUser
        [HttpGet]
        public ActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginUser(SV sv)
        {
            var result = new AccSV().Login(sv.MSSV, sv.MatKhau);
            var id = db.SINHVIENs.ToList().Find(m => m.MSSV == sv.MSSV);

            if (result && ModelState.IsValid)
            {
                HttpCookie nameCookie = new HttpCookie("SV_ID");

                //Set the Cookie value.
                nameCookie.Values["SV_ID"] = id.MSSV;

                //Set the Expiry date.
                nameCookie.Expires = DateTime.Now.AddDays(1);

                //Add the Cookie to Browser.
                Response.Cookies.Add(nameCookie);
                return RedirectToAction("ThongTinSV_GD", "ThongTinSV_GD", new { Area = "SinhVien" });
            }
            ModelState.AddModelError("", "Tài khoản không đúng");
            return View();
        }
    }
}