using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OODWebsite.Models
{
    public class AccSV
    {
        private PortalDBDataContext context = null;

        public AccSV()
        {
            context = new PortalDBDataContext();
        }
        public bool Login(string MSSV, string Password)
        {
            bool? res = false;
            context.sp_SV_Login_Check(MSSV, Password, ref res);

            return (res ?? false);
        }
    }
}