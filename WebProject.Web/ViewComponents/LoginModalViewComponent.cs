using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebProject.Web.Models;

namespace WebProject.Web.ViewComponents
{
	public class LoginModalViewComponent : ViewComponent
	{
		public LoginModalViewComponent()
		{
			
		}

		public ViewViewComponentResult Invoke(LoginViewModel model)
		{
			return View(model);
		}
	}
}
