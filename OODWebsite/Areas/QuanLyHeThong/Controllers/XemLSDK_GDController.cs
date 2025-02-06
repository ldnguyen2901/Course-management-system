using OODWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OODWebsite.Areas.QuanLyHeThong.Controllers
{
    public class XemLSDK_GDController : Controller
    {
        string strConString = "Data Source=NGUYENWOLF;Initial Catalog=CsdlPortal;Integrated Security=True";
        PortalDBDataContext db = new PortalDBDataContext();
        DateTime nam = DateTime.Now;
        // GET: QuanLyHeThong/XemLSDK_GD
        public ActionResult XemLSDK_GD(FormCollection searchdata)
        {
            using (var cn = new SqlConnection(strConString))
            {
                String sql = "SELECT  HP.MaHP, HP.TenHP, SV.MSSV, SV.HoTen, LHP.TenLop, MP.HocKy, MP.Nam\r\nFROM SINHVIEN AS SV\r\nINNER JOIN DANGKY AS DK ON SV.Id = DK.Id\r\nINNER JOIN LOPHOCPHAN AS LHP ON DK.MaLHP = LHP.MaLHP\r\nINNER JOIN MOLOP AS MP ON LHP.MaLHP = MP.MaLHP\r\nINNER JOIN HOCPHAN AS HP ON MP.MSHP = HP.MSHP\r\nGROUP BY HP.MaHP, HP.TenHP, SV.MSSV, SV.HoTen, LHP.TenLop, MP.HocKy, MP.Nam\r\nORDER BY HP.MaHP";
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
                    details.HocKy = Convert.ToInt32(rdr["HocKy"].ToString());
                    details.Nam = Convert.ToInt32(rdr["Nam"].ToString());
                    model.Add(details);
                }
                if (searchdata["Nam"] != "")
                {
                    model = model.Where(m => m.Nam == Convert.ToInt32(searchdata["Nam"])).ToList();
                    model = model.Where(m => m.HocKy == Convert.ToInt32(searchdata["HocKy"])).ToList();
                    return View(model);
                }
                return View();
            }
        }

    }
}