using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OODWebsite.Models
{
    public class SV
    {
        public int ID { get; set; }
        public string MSSV { get; set; }
        public string MatKhau { get; set; }

        public string HoTen { get; set; }
        public string GioiTinh { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgaySinh { get; set; }

        public int KhoaHoc { get; set; }
        public string TenCTDT { get; set; }
        public int MaCTDT { get; set; }
        public string Khoa { get; set; }

        public int MaLop { get; set; }
        public string Lop { get; set;}
    }
}