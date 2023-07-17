using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace WebProject.Web.ViewComponents
{
	public class BrandAreaViewComponent :ViewComponent
	{
		public BrandAreaViewComponent()
		{
			
		}

		public ViewViewComponentResult Invoke()
		{
			return View();
		}
	}
}
