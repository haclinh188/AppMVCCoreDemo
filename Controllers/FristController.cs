using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.AspNetCore.MVC.RazorPage.Controllers
{
    public class FristController : Controller
    {


        // Inject logger vào controller
        private readonly ILogger<FristController> logger;
        public FristController(ILogger<FristController> _log)
        {
            logger = _log;
        }
        public string Index() => "Toi la index cua frist";


        public IActionResult Readme()
        {
            var content = @"Day la demo asp net mvc core";
            return this.Content(content, "text/plain"); ;

        }


        public IActionResult Bike()
        {
            var filepath = Path.Combine(Startup.ContentPath, "Files", "bike.jpg");
            var bytes = System.IO.File.ReadAllBytes(filepath);
            return File(bytes, "image/jpg");

        }

        public IActionResult LocalRedirect()
        {
            var url = Url.Action("Privacy", "Home");
            return LocalRedirect(url);
        }

        public IActionResult ViewDemo()
        {
            return View("/Views/Demo/demo1.cshtml");
        }
    }
}