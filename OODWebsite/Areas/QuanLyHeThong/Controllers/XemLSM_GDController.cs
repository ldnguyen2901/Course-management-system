using OODWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OODWebsite.Areas.QuanLyHeThong.Controllers
{
    public class XemLSM_GDController : Controller
    {
        string strConString = "Data Source=NGUYENWOLF;Initial Catalog=CsdlPortal;Integrated Security=True";

        PortalDBDataContext db = new PortalDBDataContext();
        DateTime nam = DateTime.Now;
        // GET: QuanLyHeThong/XemLSM
        public ActionResult XemLSM_GD(FormCollection searchdata)
        {
            using (var cn = new SqlConnection(strConString))
            {
                String sql = "SELECT  M.MaNV, NV.TenNV, \r\nLHP.TenLop, HP.MaHP,HP.TenHP, M.HocKy, M.Nam\r\nFROM MOLOP AS M\r\nINNER JOIN NVPDT AS NV ON M.MaNV = NV.MaNV\r\nINNER JOIN LOPHOCPHAN AS LHP ON M.MaLHP = LHP.MaLHP \r\nINNER JOIN HOCPHAN AS HP ON M.MSHP = HP.MSHP\r\nGROUP BY M.MaNV, NV.TenNV, \r\nLHP.TenLop, HP.MaHP,HP.TenHP, M.HocKy, M.Nam";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                List<LSM> model = new List<LSM>();
                while (rdr.Read())
                {
                    var details = new LSM();
                    details.MaNV = Convert.ToInt32(rdr["MaNV"].ToString());
                    details.TenNV = rdr["TenNV"].ToString();
                    details.TenHP = rdr["TenHP"].ToString();
                    details.TenLop = rdr["TenLop"].ToString();
                    details.MaHP = rdr["MaHP"].ToString();
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