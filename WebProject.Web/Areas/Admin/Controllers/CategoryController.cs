using System.Collections.Immutable;
using Microsoft.AspNetCore.Mvc;
using WebProject.Business.ControllerHandler;
using WebProject.Entities;
using WebProject.Web.Areas.Admin.Models;

namespace WebProject.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		private ICategoryControllerHandler _categoryControllerHandler;


		public CategoryController(ICategoryControllerHandler categoryControllerHandler)
		{
			_categoryControllerHandler = categoryControllerHandler;
		}

		public IActionResult Index()
		{
			var category = _categoryControllerHandler.GetAllCategoryIncluded();
			return View(category);
		}

		public IActionResult AddCategory()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddCategory(Category model)
		{
			_categoryControllerHandler.AddCategory(model);
			return Redirect("/admin/category/index");
		}


		[HttpGet ("UpdateCategory/{id}")]
		public IActionResult UpdateCategory(int id)
		{
			var category = _categoryControllerHandler.GetCategoryIncluded(x => x.Id == id);
			CategoryModel categoryModel = new CategoryModel
			{
				Id = category.Id,
				Name = category.Name,
				Sort = category.Sort,
				ProductCategories = category.ProductCategories,
				ParentId = category.ParentId,
				Link = category.Link,
				IconName = category.IconName,

			};
			return View(categoryModel);
		}

		[HttpPost("UpdateCategory/{id}")]
		public IActionResult UpdateCategory(Category model)
		{
			_categoryControllerHandler.UpdateCategory(model);
			return Redirect("/admin/category/index");
		}

		[HttpGet("DeleteCategory/{id}")]
		public IActionResult DeleteCategory(int id)
		{
			_categoryControllerHandler.DeleteCategory(id);
			return Redirect("/admin/category/index");
		}
	}
}
