using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace WebProject.Web.ViewComponents
{
	public class OffCanvasMobileMenuViewComponent : ViewComponent
	{
		public OffCanvasMobileMenuViewComponent()
		{
			
		}

		public ViewViewComponentResult Invoke()
		{
			return View();
		}

	}
}
