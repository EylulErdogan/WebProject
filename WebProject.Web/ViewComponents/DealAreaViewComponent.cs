using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace WebProject.Web.ViewComponents
{
	public class DealAreaViewComponent : ViewComponent
	{
		public DealAreaViewComponent()
		{
			
		}

		public ViewViewComponentResult Invoke()
		{
			return View();
		}
	}
}
