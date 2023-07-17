using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebProject.Entities;

namespace WebProject.Web.Areas.Admin.ViewComponents
{
	public class AdminCategoryAreaViewComponent : ViewComponent
	{
		public AdminCategoryAreaViewComponent()
		{

		}
		public ViewViewComponentResult Invoke(Category category)
		{
			return View(category);
		}
	}

}
