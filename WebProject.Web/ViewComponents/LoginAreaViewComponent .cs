using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebProject.Web.Models;

namespace WebProject.Web.ViewComponents
{
	public class LoginAreaViewComponent : ViewComponent
	{
		public LoginAreaViewComponent()
		{
			
		}

		public ViewViewComponentResult Invoke(LoginViewModel model)
		{
			return View(model);
		}
	}
}
