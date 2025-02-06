using OODWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;


namespace OODWebsite.Areas.NVPhongDaoTao.Controllers
{
    public class DanhSachLHP_GDController : Controller
    {
        string strConString = "Data Source=NGUYENWOLF;Initial Catalog=CsdlPortal;Integrated Security=True";
        PortalDBDataContext context = new PortalDBDataContext();
        List<DSLHP> model = new List<DSLHP>();
        DateTime nam = DateTime.Now;


        // GET: NVPhongDaoTao/DanhSachLHP_GD
        public ActionResult Index(FormCollection searchdata)
        {
           
            using (var cn = new SqlConnection(strConString))
            {
                String sql = "SELECT  HP.MaHP,HP.TenHP,HP.SoTinChi,LHP.MaLHP,\r\n\t\tLHP.TenLop,LHP.SiSo,LHP.LT_TH, LHP.Thu,\r\n\t\tLHP.TietBD,LHP.TietKT,LHP.Phong,\r\n\t\tLHP.DiaDiem,M.HocKy, M.Nam,\r\n\t\tGV.HoTen\r\nFROM MOLOP AS M\r\nINNER JOIN LOPHOCPHAN AS LHP ON M.MaLHP = LHP.MaLHP \r\nINNER JOIN HOCPHAN AS HP ON M.MSHP = HP.MSHP\r\nINNER JOIN GIANGVIEN AS GV ON M.MaGV = GV.MaGV\r\nGROUP BY HP.MaHP,HP.TenHP,HP.SoTinChi,LHP.MaLHP,\r\n\t\tLHP.TenLop,LHP.SiSo,LHP.LT_TH, LHP.Thu,\r\n\t\tLHP.TietBD,LHP.TietKT,LHP.Phong,\r\n\t\tLHP.DiaDiem,M.HocKy, M.Nam,\r\n\t\tGV.HoTen\r\n";
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
                    model.Add(details);
                }
                if (searchdata["Nam"] != "")
                {
                    model = model.Where(m => m.Nam == Convert.ToInt32(searchdata["Nam"])).ToList();
                    model = model.Where(m => m.HocKy == Convert.ToInt32(searchdata["HocKy"])).ToList();
                    return View(model);
                }
                return View(model.FindAll(m => m.Nam == Convert.ToInt32(nam.Year)));
            }
        }


        // GET: NVPhongDaoTao/DanhSachLHP_GD/Create
        public ActionResult Create()
        {
            ViewBag.HP = new SelectList(context.HOCPHANs, "MSHP", "TenHP");
            ViewBag.GV = new SelectList(context.GIANGVIENs, "MaGV", "HoTen");

            return View();
         
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] LOPHOCPHAN lhp, MOLOP ml)
        {
            HttpCookie nameCookie = Request.Cookies["NV_ID"];
            string manv = nameCookie.Values["NV_ID"];
            if (ModelState.IsValid)
            {
                context.LOPHOCPHANs.InsertOnSubmit(lhp);
                context.SubmitChanges();
                using (var cn = new SqlConnection(strConString))
                {
                    String sql = "SELECT Max(MaLHP) AS MaLHP\r\nFROM LOPHOCPHAN";
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        MOLOP data = new MOLOP();
                        data.MaLHP = Convert.ToInt32(rdr["MaLHP"].ToString());
                        data.MaNV = Convert.ToInt32(manv);
                        data.MaGV = ml.MaGV;
                        data.HocKy = ml.HocKy;
                        data.Nam = Convert.ToInt32(nam.Year);
                        data.MSHP = ml.MSHP;
                        context.MOLOPs.InsertOnSubmit(data);
                        context.SubmitChanges();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.HP = new SelectList(context.HOCPHANs, "MSHP", "TenHP");
            ViewBag.GV = new SelectList(context.GIANGVIENs, "MaGV", "HoTen");
            return View();
        }

        // GET: NVPhongDaoTao/DanhSachLHP_GD/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.HP = new SelectList(context.HOCPHANs, "MSHP", "TenHP");
            ViewBag.GV = new SelectList(context.GIANGVIENs, "MaGV", "HoTen");
            using (var cn = new SqlConnection(strConString))
            {
                String sql = "SELECT  HP.MaHP,HP.TenHP, LHP.MaLHP,\r\n\t\tLHP.SiSo,LHP.TenLop,LHP.LT_TH,\r\n\t\tLHP.Thu, LHP.TietBD,LHP.TietKT,\r\n\t\tLHP.Phong,LHP.DiaDiem, M.HocKy,\r\n\t\tM.Nam\r\nFROM MOLOP AS M\r\nINNER JOIN LOPHOCPHAN AS LHP ON M.MaLHP = LHP.MaLHP \r\nINNER JOIN HOCPHAN AS HP ON M.MSHP = HP.MSHP\r\nGROUP BY HP.MaHP,HP.TenHP, LHP.MaLHP,\r\n\t\tLHP.SiSo,LHP.TenLop,LHP.LT_TH,\r\n\t\tLHP.Thu, LHP.TietBD,LHP.TietKT,\r\n\t\tLHP.Phong,LHP.DiaDiem, M.HocKy,\r\n\t\tM.Nam";
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
                    details.LT_TH = rdr["LT_TH"].ToString();
                    details.SiSo = Convert.ToInt32(rdr["SiSo"].ToString());
                    details.Phong = rdr["Phong"].ToString();
                    details.DiaDiem = rdr["DiaDiem"].ToString();
                    details.Thu = rdr["Thu"].ToString();
                    details.TietBD = Convert.ToInt32(rdr["TietBD"].ToString());
                    details.TietKT = Convert.ToInt32(rdr["TietKT"].ToString());
                    details.HocKy = Convert.ToInt32(rdr["HocKy"].ToString());
                    details.Nam = Convert.ToInt32(rdr["Nam"].ToString());
                    model.Add(details);
                }
                var lhp = model.ToList().Find(m => m.MaLHP == id);
                return View(lhp);
            }
          
        }

        // POST: NVPhongDaoTao/DanhSachLHP_GD/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "Id")] LOPHOCPHAN lhp, MOLOP ml)
        {
            var data1 = context.LOPHOCPHANs.ToList().Find(m => m.MaLHP == lhp.MaLHP);
            var data2 = context.MOLOPs.ToList().Find(m => m.MaLHP == lhp.MaLHP);

            if (ModelState.IsValid)
            {
                HttpCookie nameCookie = Request.Cookies["NV_ID"];
                string manv = nameCookie.Values["NV_ID"];

                data1.TenLop = lhp.TenLop;
                data1.SiSo = lhp.SiSo;
                data1.LT_TH = lhp.LT_TH;
                data1.Thu = lhp.Thu;
                data1.TietBD = lhp.TietBD;
                data1.TietKT = lhp.TietKT;
                data1.Phong = lhp.Phong;
                data1.DiaDiem = lhp.DiaDiem;

                ml.MaLHP = data2.MaLHP;
                ml.MSHP = data2.MSHP;
                ml.Nam = data2.Nam;
                ml.MaNV = Convert.ToInt32(manv);
                ml.HocKy = data2.HocKy;

                context.MOLOPs.DeleteOnSubmit(data2);
                context.MOLOPs.InsertOnSubmit(ml);

                context.SubmitChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.HP = new SelectList(context.HOCPHANs, "MSHP", "TenHP");
            ViewBag.GV = new SelectList(context.GIANGVIENs, "MaGV", "HoTen");
            return View();
        }

        // GET: NVPhongDaoTao/DanhSachLHP_GD/Delete/5
        public ActionResult Delete(int id)
        {
            using (var cn = new SqlConnection(strConString))
            {
                String sql = "SELECT  HP.MaHP,HP.TenHP, LHP.MaLHP,\r\n\t\tLHP.TenLop,LHP.LT_TH,\r\n\t\tLHP.Thu, LHP.TietBD,LHP.TietKT,\r\n\t\tLHP.Phong,LHP.DiaDiem, M.HocKy,\r\n\t\tM.Nam\r\nFROM MOLOP AS M\r\nINNER JOIN LOPHOCPHAN AS LHP ON M.MaLHP = LHP.MaLHP \r\nINNER JOIN HOCPHAN AS HP ON M.MSHP = HP.MSHP\r\nGROUP BY HP.MaHP,HP.TenHP, LHP.MaLHP,\r\n\t\tLHP.TenLop,LHP.LT_TH,\r\n\t\tLHP.Thu, LHP.TietBD,LHP.TietKT,\r\n\t\tLHP.Phong,LHP.DiaDiem, M.HocKy,\r\n\t\tM.Nam";
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
                    details.LT_TH = rdr["LT_TH"].ToString();
                    details.Phong = rdr["Phong"].ToString();
                    details.DiaDiem = rdr["DiaDiem"].ToString();
                    details.Thu = rdr["Thu"].ToString();
                    details.TietBD = Convert.ToInt32(rdr["TietBD"].ToString());
                    details.TietKT = Convert.ToInt32(rdr["TietKT"].ToString());    
                    model.Add(details);
                }
                var lhp = model.ToList().Find(m => m.MaLHP == id);
                return View(lhp);
            }
        }

        // POST: NVPhongDaoTao/DanhSachLHP_GD/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var lhp = context.LOPHOCPHANs.ToList().Find(m=>m.MaLHP == id);
            var ml = context.MOLOPs.ToList().Find(m => m.MaLHP == id);
            if (lhp != null)
            {
                context.LOPHOCPHANs.DeleteOnSubmit(lhp);
                context.MOLOPs.DeleteOnSubmit(ml);
                context.SubmitChanges();
                return RedirectToAction(nameof(Index));
            }
           
                return View();
            
        }
    }
}

