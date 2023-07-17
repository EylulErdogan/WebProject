using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebProject.Business.ComponentHandler;

namespace WebProject.Web.ViewComponents
{
	public class IntroSliderViewComponent : ViewComponent
	{
		private IIntroSliderComponentHandler _ıntroSliderComponentHandler;
		public IntroSliderViewComponent(IIntroSliderComponentHandler ıntroSliderComponentHandler)
		{
			_ıntroSliderComponentHandler = ıntroSliderComponentHandler;
		}

		public ViewViewComponentResult Invoke()
		{
			var result = _ıntroSliderComponentHandler.GetSlider();
			return View(result.OrderBy(x=>x.Sort).ToList());
		}
	}
}
