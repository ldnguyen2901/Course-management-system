using OODWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace OODWebsite.Areas.SinhVien.Controllers
{
    public class ThongTinSV_GDController : Controller
    {
        PortalDBDataContext db = new PortalDBDataContext();
        string strConString = "Data Source=NGUYENWOLF;Initial Catalog=CsdlPortal;Integrated Security=True";

        // GET: SinhVien/ThongTinSV_GD
        public ActionResult ThongTinSV_GD()
        {
            using (var cn = new SqlConnection(strConString))
            {
                String sql = "SELECT SV.MSSV, SV.HoTen, SV.GioiTinh,\r\n\t\tSV.NgaySinh, SV.MatKhau, SV.KhoaHoc,\r\n\t\tCT.TenCTDT, K.TenKhoa, SV.Id\r\nFROM SINHVIEN AS SV\r\nINNER JOIN CTDAOTAO AS CT ON SV.MaCTDT = CT.MaCTDT\r\nINNER JOIN LOP AS L ON SV.MaLop = L.MaLop\r\nINNER JOIN KHOA AS K ON L.MaSoKhoa = K.MaSoKhoa";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                List<SV> model = new List<SV>();
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
                    details.Khoa = rdr["TenKhoa"].ToString();
                    model.Add(details);
                }

                HttpCookie nameCookie = Request.Cookies["SV_ID"];
                string mssv = nameCookie.Values["SV_ID"];
                var sv = model.Find(m=>m.MSSV == mssv);
                return View(sv);
            }
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string MatKhauHienTai, string MatKhauMoi, string MatKhauMoi2)
        {
            HttpCookie nameCookie = Request.Cookies["SV_ID"];
            string mssv = nameCookie.Values["SV_ID"];
            var sv = db.SINHVIENs.ToList().Find(m => m.MSSV == mssv);
            if(sv.MatKhau != MatKhauHienTai && MatKhauHienTai!= "")
            {
                ModelState.AddModelError("", "Mật khẩu hiện tại không đúng");
                return View();
            }
            else if(MatKhauMoi == "" || MatKhauHienTai == "")
            {
                ModelState.AddModelError("", "Thiếu thông tin");
                return View();
            }
            else if(MatKhauMoi == MatKhauHienTai)
            {
                ModelState.AddModelError("", "Mật khẩu mới giống với mật khẩu cũ");
                return View();
            }
            else if(MatKhauMoi != MatKhauMoi2)
            {
                ModelState.AddModelError("", "Nhập lại mật khẩu mới không đúng");
                return View();
            }
            sv.MatKhau = MatKhauMoi;
            db.SubmitChanges();
            return RedirectToAction(nameof(ThongTinSV_GD));
        }
    }
}