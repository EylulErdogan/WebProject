using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace WebProject.Web.ViewComponents
{
	public class SearchModalViewComponent : ViewComponent
	{
		public SearchModalViewComponent()
		{
				
		}

		public ViewViewComponentResult Invoke()
		{
			return View();
		}
	}
}
