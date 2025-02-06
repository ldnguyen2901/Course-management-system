using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OODWebsite.Models
{
    public class NVPDT
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }

    }
}