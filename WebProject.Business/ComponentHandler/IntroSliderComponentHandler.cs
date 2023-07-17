using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Business.Services;
using WebProject.Entities;

namespace WebProject.Business.ComponentHandler
{
	public class IntroSliderComponentHandler :IIntroSliderComponentHandler
	{
		private ISliderService _sliderService;

		public IntroSliderComponentHandler(ISliderService sliderService)
		{
			_sliderService = sliderService;
		}

		public IList<Slider> GetSlider()
		{
			return _sliderService.GetAll("home");
		}
	}

	public interface IIntroSliderComponentHandler
	{
		IList<Slider> GetSlider();
	}
}
