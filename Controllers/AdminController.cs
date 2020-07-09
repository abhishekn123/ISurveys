using Microsoft.AspNetCore.Mvc;

namespace IvySurvey.Controllers
{
    public class AdminController:Controller
    {
        public IActionResult AdminScreen()
        {
            return View();
        }
    }
}