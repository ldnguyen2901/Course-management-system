using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OODWebsite.Models;

namespace OODWebsite.Areas.NVPhongDaoTao.Controllers
{
    public class DanhSachHP_GDController : Controller
    {
        PortalDBDataContext db = new PortalDBDataContext();

        // GET: NVPhongDaoTao/DanhSachHP_GD
        public ActionResult DanhSachHP_GD()
        {
            var model = db.HOCPHANs.ToList();
            return View(model);
            
        }
        public ActionResult Create()
        {
            ViewBag.Khoa = new SelectList(db.KHOAs, "MaSoKhoa", "TenKhoa");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] HOCPHAN hp)
        {
            if (ModelState.IsValid)
            {
                db.HOCPHANs.InsertOnSubmit(hp);
                db.SubmitChanges();
                return RedirectToAction(nameof(DanhSachHP_GD));
            }
            ViewBag.Khoa = new SelectList(db.KHOAs, "MaSoKhoa", "TenKhoa");
            return View(hp);
        }

        public ActionResult Edit(int id)
        {
            var hp = db.HOCPHANs.ToList().Find(m => m.MSHP == id);
            return View(hp);
        }


        [HttpPost]
        public ActionResult Edit(HOCPHAN hp)
        {
            var data = db.HOCPHANs.ToList().Find(m => m.MSHP == hp.MSHP);
            if (ModelState.IsValid)
            {
                data.TenHP = hp.TenHP;
                data.SoTinChi = hp.SoTinChi;
                data.MaSoKhoa = hp.MaSoKhoa;
                data.TuyenQuyet = hp.TuyenQuyet;
                db.SubmitChanges();
                return RedirectToAction(nameof(DanhSachHP_GD));
            }
            ViewBag.Khoa = new SelectList(db.KHOAs, "MaSoKhoa", "TenKhoa");
            return View(hp);
        }


        public ActionResult Delete(int id)
        {
            var hp = db.HOCPHANs.ToList().Find(m => m.MSHP == id);
            return View(hp);
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var hp = db.HOCPHANs.ToList().Find(m => m.MSHP == id);
            if (hp != null)
            {
                db.HOCPHANs.DeleteOnSubmit(hp);
                db.SubmitChanges();
                return RedirectToAction(nameof(DanhSachHP_GD));
            }
            return View(hp);
        }
    }
}
