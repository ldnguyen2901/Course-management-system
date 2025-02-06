using OODWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace OODWebsite.Areas.NVPhongDaoTao.Controllers
{
    public class QuanLySV_GDController : Controller
    {
        PortalDBDataContext context = new PortalDBDataContext(); //kết nối data
        string strConString = "Data Source=NGUYENWOLF;Initial Catalog=CsdlPortal;Integrated Security=True";
        List<SV> model = new List<SV>();

        // GET: NVPhongDaoTao/QuanLySV_GD
        public ActionResult QuanLySV_GD(FormCollection searchdata)
        {
            using (var cn = new SqlConnection(strConString))
            {
                String sql = "SELECT SV.Id, SV.MSSV, SV.HoTen, SV.GioiTinh, SV.NgaySinh, SV.MatKhau, L.TenLop, CT.TenCTDT, SV.KhoaHoc, SV.MaCTDT, SV.MaLop\r\nFROM SINHVIEN AS SV\r\nINNER JOIN LOP AS L ON SV.MaLop = L.MaLop\r\nINNER JOIN CTDAOTAO AS CT ON SV.MaCTDT = CT.MaCTDT";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var details = new SV();
                    details.ID = Convert.ToInt32(rdr["Id"].ToString());
                    details.MSSV = rdr["MSSV"].ToString();
                    details.HoTen = rdr["HoTen"].ToString();
                    details.GioiTinh = rdr["GioiTinh"].ToString();
                    details.NgaySinh = Convert.ToDateTime(rdr["NgaySinh"].ToString());
                    details.MatKhau = rdr["MatKhau"].ToString();
                    details.TenCTDT = rdr["TenCTDT"].ToString();
                    details.KhoaHoc = Convert.ToInt32(rdr["KhoaHoc"].ToString());
                    details.Lop = rdr["TenLop"].ToString();
                    details.MaCTDT = Convert.ToInt32(rdr["MaCTDT"].ToString());
                    details.MaLop = Convert.ToInt32(rdr["MaLop"].ToString());
                    model.Add(details);
                }
                if (searchdata["MSSV"] != null)
                    model = model.Where(m => m.MSSV.Contains(searchdata["MSSV"])).ToList();

                return View(model);
            }
        }
        public ActionResult Create()
        {
            ViewBag.TenCTDT = new SelectList(context.CTDAOTAOs, "MaCTDT", "TenCTDT");
            ViewBag.Lop = new SelectList(context.LOPs, "MaLop", "TenLop");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] SINHVIEN sv)
        {
            if (ModelState.IsValid)
            {
                context.SINHVIENs.InsertOnSubmit(sv);
                context.SubmitChanges();
                return RedirectToAction(nameof(QuanLySV_GD));
            }
            ViewBag.TenCTDT = new SelectList(context.CTDAOTAOs, "MaCTDT", "TenCTDT");
            ViewBag.Lop = new SelectList(context.LOPs, "MaLop", "TenLop");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var sv = context.SINHVIENs.ToList().Find(m => m.Id == id);

            return View(sv);
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var sv = context.SINHVIENs.ToList().Find(m => m.Id == id);
            if (sv != null)
            {
                context.SINHVIENs.DeleteOnSubmit(sv);
                context.SubmitChanges();
                return RedirectToAction(nameof(QuanLySV_GD));
            }
            return View(sv);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.TenCTDT = new SelectList(context.CTDAOTAOs, "MaCTDT", "TenCTDT");
            ViewBag.Lop = new SelectList(context.LOPs, "MaLop", "TenLop");
            var sv = context.SINHVIENs.ToList().Find(m => m.Id == id);
            return View(sv);
        }


        [HttpPost]
        public ActionResult Edit(SINHVIEN sv)
        {
            var data = context.SINHVIENs.ToList().Find(m => m.Id == sv.Id);
            if (ModelState.IsValid)
            {
                data.MSSV = sv.MSSV;
                data.HoTen = sv.HoTen;
                data.GioiTinh = sv.GioiTinh;
                data.NgaySinh = sv.NgaySinh;
                data.MatKhau = sv.MatKhau;
                data.KhoaHoc = sv.KhoaHoc;
                data.MaCTDT = sv.MaCTDT;
                data.MaLop = sv.MaLop;
                context.SubmitChanges();
                return RedirectToAction(nameof(QuanLySV_GD));
            }
            ViewBag.TenCTDT = new SelectList(context.CTDAOTAOs, "MaCTDT", "TenCTDT");
            ViewBag.Lop = new SelectList(context.LOPs, "MaLop", "TenLop");
            return View(sv);
        }
    }
}