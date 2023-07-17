using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebProject.Business.ComponentHandler;
using WebProject.Business.Helpers;

namespace WebProject.Web.ViewComponents
{
	public class HeaderViewComponent : ViewComponent
	{
		private IHeaderComponentHandler _headerComponentHandler;

		public HeaderViewComponent(IHeaderComponentHandler headerComponentHandler)
		{
			_headerComponentHandler = headerComponentHandler;
		}

		public ViewViewComponentResult Invoke()
		{
			var result = _headerComponentHandler.GetUserData(null,Request);
			if (result != null)
			{
				if (string.IsNullOrEmpty(result.LoginGuidKey))
				{
					return View();
				}
				if (result.IsAdmin)
				{
					ViewBag.FullName = result.FullName;
					HttpContext.Response.Redirect("/admin/home/index");
				}
			}
			return View();
		}

	}
}

