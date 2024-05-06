using Microsoft.AspNetCore.Mvc;

namespace APPR6312_Part1_1_.Controllers
{
    public class LogLandingPageController1 : Controller
    {
        public IActionResult Index()
        {
            // Redirect to the Identity login page
            return RedirectToAction("Login", "Pages/Account", new { area = "Identity" });
        }
    }
}
