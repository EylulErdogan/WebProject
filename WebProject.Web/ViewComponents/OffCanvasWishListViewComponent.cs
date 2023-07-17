using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace WebProject.Web.ViewComponents
{
	public class OffCanvasWishListViewComponent : ViewComponent
	{
		public OffCanvasWishListViewComponent()
		{
			
		}

		public ViewViewComponentResult Invoke()
		{
			return View();
		}
	}
}
