using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebProject.Entities;

namespace WebProject.Web.Areas.Admin.ViewComponents
{
	public class AdminProductAreaViewComponent : ViewComponent
	{
		public AdminProductAreaViewComponent()
		{

		}

		public ViewViewComponentResult Invoke(Product product)
		{
			return View(product);
		}
	}
}
