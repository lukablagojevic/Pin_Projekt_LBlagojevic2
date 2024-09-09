using Microsoft.AspNetCore.Mvc;

public class YoutubeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}