using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebProject.Business.ControllerHandler;
using WebProject.Entities;
using WebProject.Web.Models;

namespace WebProject.Web.Controllers
{
    public class HomeController : Controller
    {
		private readonly IAuthenticationControllerHandler _authenticationControllerHandler;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IAuthenticationControllerHandler authenticationControllerHandler)
        {
	        _logger = logger;
	        _authenticationControllerHandler = authenticationControllerHandler;
        }

        public IActionResult Index(User user)
        {
	        ViewBag.FullName = user?.FullName;
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