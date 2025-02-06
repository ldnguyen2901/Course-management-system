using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OODWebsite.Models;

namespace OODWebsite.Areas.NVPhongDaoTao.Controllers
{
    public class DanhSachKQDK_GDController : Controller
    {
        string strConString = "Data Source=NGUYENWOLF;Initial Catalog=CsdlPortal;Integrated Security=True";
        // GET: NVPhongDaoTao/DanhSachKQDK_GD
        DateTime nam = DateTime.Now;
        public ActionResult DanhSachKQDK_GD(FormCollection searchdata)
        {
            using (var cn = new SqlConnection(strConString))
            {
                String sql = "SELECT  HP.MaHP,HP.TenHP, LHP.TenLop, LHP.LT_TH, LHP.SiSo, COUNT(DK.MaLHP) AS N'Đã đăng ký' , M.HocKy, M.Nam\r\nFROM MOLOP AS M \r\nINNER JOIN LOPHOCPHAN AS LHP ON M.MaLHP = LHP.MaLHP \r\nINNER JOIN HOCPHAN AS HP ON M.MSHP = HP.MSHP \r\nLEFT JOIN DANGKY AS DK ON M.MaLHP = DK.MaLHP \r\nGROUP BY HP.MaHP,HP.TenHP,HP.SoTinChi,LHP.TenLop,LHP.SiSo,LHP.LT_TH,M.HocKy, M.Nam";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                List<DSLHP> model = new List<DSLHP>();
                while (rdr.Read())
                {
                    var details = new DSLHP();
                    details.MaHP = rdr["MaHP"].ToString();
                    details.TenHP = rdr["TenHP"].ToString();
                    details.TenLop = rdr["TenLop"].ToString();
                    details.SiSo = Convert.ToInt32(rdr["SiSo"].ToString());
                    details.LT_TH = rdr["LT_TH"].ToString();
                    details.ĐK = Convert.ToInt32(rdr["Đã đăng ký"].ToString());
                    details.HocKy = Convert.ToInt32(rdr["HocKy"].ToString());
                    details.Nam = Convert.ToInt32(rdr["Nam"].ToString());
                    model.Add(details);
                }
                if (searchdata["Nam"] != null)
                {
                    model = model.Where(m => m.Nam == Convert.ToInt32(searchdata["Nam"])).ToList();
                    model = model.Where(m => m.HocKy == Convert.ToInt32(searchdata["HocKy"])).ToList();
                    return View(model);
                }
                return View(model.FindAll(m => m.Nam == Convert.ToInt32(nam.Year)));
            }
        }
    }
}