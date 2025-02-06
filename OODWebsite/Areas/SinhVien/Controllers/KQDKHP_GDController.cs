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
    public class KQDKHP_GDController : Controller
    {
        // GET: SinhVien/KQDKHP_GD
        public ActionResult KQDKHP_GD(FormCollection searchdata)
        {
            PortalDBDataContext db = new PortalDBDataContext();
            DateTime nam = DateTime.Now;
            // GET: SinhVien/DanhSachMo_GD
            string strConString = "Data Source=NGUYENWOLF;Initial Catalog=CsdlPortal;Integrated Security=True";
            HttpCookie nameCookie = Request.Cookies["SV_ID"];
            string masv = nameCookie.Values["SV_ID"];

            using (var cn = new SqlConnection(strConString))
            {
                String sql = "SELECT  HP.MaHP, HP.TenHP, SV.MSSV, SV.HoTen, LHP.TenLop, ML.Nam, ML.HocKy , LHP.LT_TH, LHP.Thu, LHP.TietBD, LHP.TietKT, LHP.Phong \r\nFROM SINHVIEN AS SV\r\nINNER JOIN DANGKY AS DK ON SV.Id = DK.Id\r\nINNER JOIN LOPHOCPHAN AS LHP ON DK.MaLHP = LHP.MaLHP\r\nINNER JOIN MOLOP AS ML ON LHP.MaLHP = ML.MaLHP\r\nINNER JOIN HOCPHAN AS HP ON ML.MSHP = HP.MSHP\r\nGROUP BY   HP.MaHP, HP.TenHP, SV.MSSV, SV.HoTen, LHP.TenLop, ML.Nam, ML.HocKy , LHP.LT_TH, LHP.Thu, LHP.TietBD, LHP.TietKT, LHP.Phong  ";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                List<LSDK> model = new List<LSDK>();
                while (rdr.Read())
                {
                    var details = new LSDK();
                    details.MSSV = rdr["MSSV"].ToString();
                    details.HoTen = rdr["HoTen"].ToString();
                    details.TenLop = rdr["TenLop"].ToString();
                    details.MaHP = rdr["MaHP"].ToString();
                    details.TenHP = rdr["TenHP"].ToString();
                    details.LT_TH = rdr["LT_TH"].ToString();
                    details.Phong = rdr["Phong"].ToString();
                    details.Thu = rdr["Thu"].ToString();
                    details.TietBD = Convert.ToInt32(rdr["TietBD"].ToString());
                    details.TietKT = Convert.ToInt32(rdr["TietKT"].ToString());
                    details.HocKy = Convert.ToInt32(rdr["HocKy"].ToString());
                    details.Nam = Convert.ToInt32(rdr["Nam"].ToString());
                    model.Add(details);
                }

                if (searchdata["Nam"] != "")
                {
                    model = model.Where(m => m.Nam == Convert.ToInt32(searchdata["Nam"])).ToList();
                    model = model.Where(m => m.HocKy == Convert.ToInt32(searchdata["HocKy"])).ToList();
                    var sv = db.SINHVIENs.ToList().Find(m => m.MSSV == masv);
                    return View(model.FindAll(m => m.MSSV == sv.MSSV));
                }

                return View();
            }
        
        }
    }
}