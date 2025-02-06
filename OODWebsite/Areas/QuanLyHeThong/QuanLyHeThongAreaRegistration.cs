using System.Web.Mvc;

namespace OODWebsite.Areas.QuanLyHeThong
{
    public class QuanLyHeThongAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "QuanLyHeThong";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "QuanLyHeThong_default",
                "QuanLyHeThong/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}