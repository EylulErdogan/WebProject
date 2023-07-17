using Microsoft.AspNetCore.Mvc;

namespace WebProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Login()
		{
			return View();
		}
	}
}
