using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace WebProject.Web.ViewComponents
{
	public class FooterAreaViewComponent : ViewComponent
	{
		public FooterAreaViewComponent()
		{
			
		}

		public ViewViewComponentResult Invoke()
		{
			return View();
		}
	}
}
