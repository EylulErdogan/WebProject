using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebProject.Web.Models;

namespace WebProject.Web.ViewComponents
{
	public class RegisterAreaViewComponent : ViewComponent
	{
		public RegisterAreaViewComponent()
		{
			
		}

		public ViewViewComponentResult Invoke(RegisterViewModel model)
		{
			return View(model);
		}
	}
}
