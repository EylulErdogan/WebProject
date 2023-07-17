using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace WebProject.Web.ViewComponents
{
	public class TestimonialAreaViewComponent : ViewComponent
	{
		public TestimonialAreaViewComponent()
		{
			
		}

		public ViewViewComponentResult Invoke()
		{
			return View();
		}
	}
}
