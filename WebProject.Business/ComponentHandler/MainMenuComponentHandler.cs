using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Business.Services;
using WebProject.Entities;

namespace WebProject.Business.ComponentHandler
{
	public class MainMenuComponentHandler :IMainMenuComponentHandler
	{
		private readonly ICategoryService _categoryService;
		
		public MainMenuComponentHandler(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public IList<Category> GetCategories()
		{
			return _categoryService.GetAllCategories();
		}
	}

	public interface IMainMenuComponentHandler
	{
		IList<Category> GetCategories();

	}
}
