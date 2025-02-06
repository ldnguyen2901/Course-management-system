using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OODWebsite.Areas.QuanLyHeThong.Controllers
{
    public class QuanLyNV_GDController : Controller
    {
        PortalDBDataContext context = new PortalDBDataContext();
        // GET: QuanLyHeThong/QuanLyNV_GD
        public ActionResult QuanLyNV_GD()
        {
            var nv = context.NVPDTs.ToList();
            return View(nv);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] NVPDT nv)
        {
            if (nv.TenNV != null && nv.GioiTinh != null && nv.email != null && nv.Matkhau != null)
            {
                context.NVPDTs.InsertOnSubmit(nv);
                context.SubmitChanges();
                return RedirectToAction(nameof(QuanLyNV_GD));
            }
            ModelState.AddModelError("", "Thông tin nhập bị thiếu");
            return View();
        }

        public ActionResult Edit(int id)
        {
            var nv = context.NVPDTs.ToList().Find(m => m.MaNV == id);
            return View(nv);
        }

     
        [HttpPost]
        public ActionResult Edit(NVPDT nv)
        {
            var data = context.NVPDTs.ToList().Find(m => m.MaNV == nv.MaNV);
            if (nv.TenNV == null || nv.GioiTinh == null || nv.email == null || nv.Matkhau == null)
            {
                ModelState.AddModelError("", "Thông tin nhập bị thiếu");
                return View(nv);
            }
            else
            {
                data.TenNV = nv.TenNV;
                data.email = nv.email;
                data.GioiTinh = nv.GioiTinh;
                data.Matkhau = nv.Matkhau;
                context.SubmitChanges();
                return RedirectToAction(nameof(QuanLyNV_GD));

            }

        }


        public ActionResult Delete(int id)
        {
            var nv = context.NVPDTs.ToList().Find(m => m.MaNV == id);
            return View(nv);
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var nv = context.NVPDTs.ToList().Find(m => m.MaNV == id);
            if (nv != null)
            {
                context.NVPDTs.DeleteOnSubmit(nv);
                context.SubmitChanges();
                return RedirectToAction(nameof(QuanLyNV_GD));
            }
            return View(nv);
        }
    }
}