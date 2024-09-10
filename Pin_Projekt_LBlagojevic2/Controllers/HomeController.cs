using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pin_Projekt_LBlagojevic2.Models;

namespace Pin_Projekt_LBlagojevic2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TwitchService _twitchService;

        public HomeController(ILogger<HomeController> logger, TwitchService twitchService)
        {
            _logger = logger;
            _twitchService = twitchService;
        }

        public async Task<IActionResult> Index()
        {
            var isLive = await _twitchService.IsStreamLiveAsync("arthapsic");


            ViewData["IsTwitchLive"] = isLive;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
