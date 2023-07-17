using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebProject.Business.ComponentHandler;

namespace WebProject.Web.ViewComponents
{
	public class MainMenuViewComponent :ViewComponent
	{
		private IMainMenuComponentHandler _mainMenuComponentHandler;
		public MainMenuViewComponent(IMainMenuComponentHandler mainMenuComponentHandler)
		{
			_mainMenuComponentHandler = mainMenuComponentHandler;
		}

		public ViewViewComponentResult Invoke()
		{
			var result = _mainMenuComponentHandler.GetCategories();
			return View(result);
		}
	}
}
