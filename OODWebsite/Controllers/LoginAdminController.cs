using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OODWebsite.Models;

namespace OODWebsite.Controllers
{
    public class LoginAdminController : Controller
    {
        PortalDBDataContext db = new PortalDBDataContext();
        // GET: LoginAdmin
        [HttpGet]
        public ActionResult LoginAdmin()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAdmin(LoginNV model)
        {
            var result = new AccNV().Login(model.Email, model.Password);
            //var result = new AccNV().Login(model.Email, model.Password);
            var id = db.NVPDTs.ToList().Find(m=>m.email== model.Email);
      
            if (result && ModelState.IsValid)
            {
                HttpCookie nameCookie = new HttpCookie("NV_ID");

                //Set the Cookie value.
                nameCookie.Values["NV_ID"] = id.MaNV.ToString();

                //Set the Expiry date.
                nameCookie.Expires = DateTime.Now.AddDays(1);

                //Add the Cookie to Browser.
                Response.Cookies.Add(nameCookie);
                return RedirectToAction("QuanLySV_GD", "QuanLySV_GD", new { Area = "NVPhongDaoTao" });
            }
            else if (model.Email != null && model.Password != null && model.Email.ToLower().Equals("admin") && model.Password.Equals("123"))
            {
                return RedirectToAction("QuanLyNV_GD", "QuanLyNV_GD", new { Area = "QuanLyHeThong" });
            }
            ModelState.AddModelError("", "Tài khoản không đúng");
            return View();
        }
    }
}