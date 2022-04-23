using Jumia_MVC.Data;
using Jumia_MVC.Data.Base;
using Jumia_MVC.Models;

namespace FinalProject.MVC.Data.services.Banners
{
    public class BannerService : EntityBaseRepository<Banner>, IBannerService
    {

        public BannerService(ApplicationDBContext context) : base(context) { }
    }
}
