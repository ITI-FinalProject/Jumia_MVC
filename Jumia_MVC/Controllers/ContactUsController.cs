using Jumia_MVC.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.UI.Services;
namespace Jumia_MVC.Controllers
{
    public class ContactUsController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
