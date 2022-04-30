

namespace Jumia_MVC.Data.services
{
    public class BannerService : EntityBaseRepository<Banner>, IBannerService
    {

        public BannerService(ApplicationDBContext context) : base(context) { }
    }
}
