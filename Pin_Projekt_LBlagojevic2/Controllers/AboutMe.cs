using Microsoft.AspNetCore.Mvc;

namespace Pin_Projekt_LBlagojevic2.Controllers
{
    public class AboutMe : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
