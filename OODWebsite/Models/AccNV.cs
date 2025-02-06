using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OODWebsite.Models
{
    public class AccNV
    {
        private PortalDBDataContext context = null;

        public AccNV()
        {
            context = new PortalDBDataContext();
        }
        public bool Login(string Email, string Password)
        {
            bool? res = false;
            context.sp_NVPDT_Login_Check(Email, Password, ref res);
            //context.sp_NVPDT_Login_Check(Email, Password, ref res);

            return (res ?? false);
        }
    }
}