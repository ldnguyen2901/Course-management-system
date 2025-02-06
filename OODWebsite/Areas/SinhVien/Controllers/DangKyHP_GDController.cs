using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using OODWebsite.Models;

namespace OODWebsite.Areas.SinhVien.Controllers
{
    public class DangKyHP_GDController : Controller
    {
        PortalDBDataContext db = new PortalDBDataContext();
        string strConString = "Data Source=NGUYENWOLF;Initial Catalog=CsdlPortal;Integrated Security=True";
        DateTime nam = DateTime.Now;
        int hkhientai = 2;


        public ActionResult DangKyHP_GD()
        {
            dynamic dy = new ExpandoObject();
            dy.DSLHP = getlhps();
            dy.DSDK = getdks();
            return View(dy);
        }


        public List<DSLHP> getlhps()
        {
            HttpCookie nameCookie = Request.Cookies["SV_ID"];
            string masv = nameCookie.Values["SV_ID"];
            List<DSLHP> model = new List<DSLHP>();
            List<DSLHP> data = new List<DSLHP>();
            List<DSLHP> data2 = new List<DSLHP>();

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
                    details.ĐK = Convert.ToInt32(rdr["Đã đăng ký"].ToString());
                    data.Add(details);
                }
                data2 = data.ToList().FindAll(m => m.Nam == Convert.ToInt32(nam.Year));
                model = data2.ToList().FindAll(m=>m.HocKy == hkhientai);
                var sv = db.SINHVIENs.ToList().Find(m => m.MSSV == masv);
                return model.FindAll(m=>m.KhoaHoc >= sv.KhoaHoc);
            }
        }

        public List<DSDK> getdks()
        {
            HttpCookie nameCookie = Request.Cookies["SV_ID"];
            string masv = nameCookie.Values["SV_ID"];
            List<DSDK> model = new List<DSDK>();
            List<DSDK> data = new List<DSDK>();
            List<DSDK> data2 = new List<DSDK>();
            using (var cn = new SqlConnection(strConString))
            {
                String sql = "SELECT DK.Id,HP.MaHP, HP.TenHP, HP.SoTinChi, LHP.TenLop, LHP.SiSo, LHP.Thu, LHP.TietBD, LHP.TietKT , SV.MSSV, ML.HocKy, ML.Nam\r\nFROM DANGKY AS DK\r\nINNER JOIN SINHVIEN AS SV ON DK.Id = SV.Id\r\nINNER JOIN LOPHOCPHAN AS LHP ON DK.MaLHP = LHP.MaLHP\r\nINNER JOIN MOLOP AS ML ON LHP.MaLHP = ML.MaLHP\r\nINNER JOIN HOCPHAN AS HP ON ML.MSHP = HP.MSHP\r\nGROUP BY  DK.Id,HP.MaHP, HP.TenHP, HP.SoTinChi, LHP.TenLop, LHP.SiSo, LHP.Thu, LHP.TietBD, LHP.TietKT, SV.MSSV, ML.HocKy, ML.Nam";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var details = new DSDK();
                    details.MaHP = rdr["MaHP"].ToString();
                    details.TenHP = rdr["TenHP"].ToString();
                    details.TenLop = rdr["TenLop"].ToString();
                    details.SiSo = Convert.ToInt32(rdr["SiSo"].ToString());
                    details.SoTinChi = Convert.ToInt32(rdr["SoTinChi"].ToString());
                    details.Thu = rdr["Thu"].ToString();
                    details.MSSV = rdr["MSSV"].ToString();
                    details.TietBD = Convert.ToInt32(rdr["TietBD"].ToString());
                    details.TietKT = Convert.ToInt32(rdr["TietKT"].ToString());
                    details.HocKy = Convert.ToInt32(rdr["HocKy"].ToString());
                    details.Nam = Convert.ToInt32(rdr["Nam"].ToString());
                    data.Add(details);
                }

                data2 = data.ToList().FindAll(m => m.Nam == Convert.ToInt32(nam.Year));
                model = data2.ToList().FindAll(m => m.HocKy == hkhientai);
                return model.FindAll(m => m.MSSV == masv);
            }

        }

        [HttpPost]
        public ActionResult DangKyHP_GD(DANGKY dk)
        {
            HttpCookie nameCookie = Request.Cookies["SV_ID"];
            string masv = nameCookie.Values["SV_ID"];
            var sv = db.SINHVIENs.ToList().Find(m=>m.MSSV == masv);
            if(dk != null)
            {
                dk.Id = sv.Id;
                db.DANGKies.InsertOnSubmit(dk);
                db.SubmitChanges();

            }
            dynamic dy = new ExpandoObject();
            dy.DSLHP = getlhps();
            dy.DSDK = getdks();
            return View(dy);
        }
    }
}