using System.Web.Mvc;

namespace OODWebsite.Areas.NVPhongDaoTao
{
    public class NVPhongDaoTaoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "NVPhongDaoTao";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "NVPhongDaoTao_default",
                "NVPhongDaoTao/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}