using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OODWebsite.Models
{
    public class DSLHP
    {
        public int MSHP { get; set; }
        public string MaHP { get; set; }
        public string TenHP { get; set; }
        public string Thu { get; set; }
        public int MaLHP { get; set; }
        public string TenLop { get; set; }
        public int SiSo { get; set; }
        public int SoTinChi { get; set; }
        public string LT_TH { get; set; }
        public string Phong { get; set; }
        public int TietBD { get; set; }
        public int TietKT { get; set; }
        public string DiaDiem { get; set; }
        public int ĐK { get; set; }
        public int HocKy { get; set; }
        public int Nam { get; set; }
        public int MaGV { get; set; }
        public string GV { get; set; }
        public string TenNV { get; set; }
        public int MaNV { get; set; }
        public int KhoaHoc { get; set; }

        public bool Dangky { get; set; }

    }

}