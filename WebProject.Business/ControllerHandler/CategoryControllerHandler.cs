using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebProject.Business.Services;
using WebProject.Entities;

namespace WebProject.Business.ControllerHandler
{
	public class CategoryControllerHandler : ICategoryControllerHandler
	{
		private ICategoryService _categoryService;

		public CategoryControllerHandler(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public Category GetCategoryIncluded(Expression<Func<Category, bool>> filter = null)
		{
			return _categoryService.GetCategoryIncluded(filter);
		}
		public IList<Category> GetAllCategoryIncluded(Expression<Func<Category, bool>> filter = null)
		{
			return _categoryService.GetAllCategories(filter);
		}
		public IList<Category> GetCategories(Expression<Func<Category, bool>> filter = null)
		{
			return _categoryService.GetAllCategories(filter);
		}

		public Category AddCategory(Category entity)
		{
			return _categoryService.AddCategory(entity);
		}

		public Category GetCategory(Expression<Func<Category, bool>> filter = null)
		{
			return _categoryService.GetCategory(filter);
		}

		public Category UpdateCategory(Category entity)
		{
			return _categoryService.UpdateCategory(entity);
		}

		public bool DeleteCategory(int id)
		{
			return _categoryService.DeleteCategory(id);
		}
	}

	public interface ICategoryControllerHandler
	{
		Category GetCategoryIncluded(Expression<Func<Category, bool>> filter = null);
		IList<Category> GetCategories(Expression<Func<Category, bool>> filter = null);
		IList<Category> GetAllCategoryIncluded(Expression<Func<Category, bool>> filter = null);
		Category AddCategory(Category entity);
		Category GetCategory (Expression<Func<Category, bool>> filter = null);
		Category UpdateCategory(Category entity);
		bool DeleteCategory(int id);

	}


}
