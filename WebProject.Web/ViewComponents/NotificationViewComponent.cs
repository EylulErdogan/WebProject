using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace WebProject.Web.ViewComponents
{
	public class NotificationViewComponent : ViewComponent
	{
		public NotificationViewComponent()
		{
				
		}

		public ViewViewComponentResult Invoke()
		{
			return View();
		}
	}
}
