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
    public class DanhSachMo_GDController : Controller
    {

        PortalDBDataContext db = new PortalDBDataContext();
        List<DSLHP> model = new List<DSLHP>();
        DateTime nam = DateTime.Now;
        // GET: SinhVien/DanhSachMo_GD
        string strConString = "Data Source=NGUYENWOLF;Initial Catalog=CsdlPortal;Integrated Security=True";
        public ActionResult DanhSachMo_GD(FormCollection searchdata)
        {
            HttpCookie nameCookie = Request.Cookies["SV_ID"];
            string masv = nameCookie.Values["SV_ID"];

            using (var cn = new SqlConnection(strConString))
            {
                String sql = "SELECT  HP.MaHP,HP.TenHP,HP.SoTinChi,LHP.MaLHP,LHP.TenLop,\r\n\t\tLHP.SiSo,LHP.LT_TH, LHP.Thu,LHP.TietBD,LHP.TietKT,\r\n\t\tLHP.Phong,LHP.DiaDiem,M.HocKy, LHP.KhoaHoc, \r\n\t\tM.Nam,GV.HoTen,COUNT(DK.MaLHP) AS N'Đã đăng ký' \r\nFROM MOLOP AS M\r\nINNER JOIN LOPHOCPHAN AS LHP ON M.MaLHP = LHP.MaLHP \r\nINNER JOIN HOCPHAN AS HP ON M.MSHP = HP.MSHP\r\nINNER JOIN GIANGVIEN AS GV ON M.MaGV = GV.MaGV\r\nLEFT JOIN DANGKY AS DK ON M.MaLHP = DK.MaLHP\r\nGROUP BY HP.MaHP,HP.TenHP,HP.SoTinChi,LHP.MaLHP,LHP.TenLop,\r\n\t\tLHP.SiSo,LHP.LT_TH, LHP.Thu,LHP.TietBD,LHP.TietKT,\r\n\t\tLHP.Phong,LHP.DiaDiem,M.HocKy, LHP.KhoaHoc, \r\n\t\tM.Nam,GV.HoTen";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var details = new DSLHP();
                    details.MaHP = rdr["MaHP"].ToString();
                    details.TenHP = rdr["TenHP"].ToString();
                    details.MaLHP = Convert.ToInt32(rdr["MaLHP"].ToString());
                    details.TenLop = rdr["TenLop"].ToString();
                    details.SiSo = Convert.ToInt32(rdr["SiSo"].ToString());
                    details.SoTinChi = Convert.ToInt32(rdr["SoTinChi"].ToString());
                    details.LT_TH = rdr["LT_TH"].ToString();
                    details.Phong = rdr["Phong"].ToString();
                    details.DiaDiem = rdr["DiaDiem"].ToString();
                    details.Thu = rdr["Thu"].ToString();
                    details.TietBD = Convert.ToInt32(rdr["TietBD"].ToString());
                    details.TietKT = Convert.ToInt32(rdr["TietKT"].ToString());
                    details.HocKy = Convert.ToInt32(rdr["HocKy"].ToString());
                    details.Nam = Convert.ToInt32(rdr["Nam"].ToString());
                    details.GV = rdr["HoTen"].ToString();
                    details.KhoaHoc = Convert.ToInt32(rdr["KhoaHoc"].ToString());
                    model.Add(details);
                }
                if (searchdata["Nam"] != "")
                {
                    model = model.Where(m => m.Nam == Convert.ToInt32(searchdata["Nam"])).ToList();
                    model = model.Where(m => m.HocKy == Convert.ToInt32(searchdata["HocKy"])).ToList();
                    var sv = db.SINHVIENs.ToList().Find(m => m.MSSV == masv);
                    return View(model.FindAll(m => m.KhoaHoc >= sv.KhoaHoc));
                }

                return View();
            }

        }

    }
}
