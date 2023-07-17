using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.Abstract;
using WebProject.Data.Concrete;
using WebProject.Entities;

namespace WebProject.Business.Services
{
	// 5. Adım ServiseYazılır 
	public class CategoryService :ICategoryService
	{
		private ICategoryDal _categoryDal;

		public CategoryService(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public IList<Category> GetAllCategories()
		{
			return _categoryDal.GetAll();
		}
		public IList<Category> GetAllCategories(Expression<Func<Category, bool>> filter = null)
		{
			return _categoryDal.GetAll(filter);
		}

		public Category GetCategoryIncluded(Expression<Func<Category, bool>> filter = null)
		{
			return _categoryDal.GetCategoryIncluded(filter);
		}

		public Category AddCategory(Category entity)
		{
			return _categoryDal.Add(entity);
		}

		public Category GetCategory(Expression<Func<Category, bool>> filter = null)
		{
			return _categoryDal.Get(filter);
		}

		public Category UpdateCategory(Category entity)
		{
			return _categoryDal.Update(entity);
		}

		public bool DeleteCategory(int id)
		{
			var category = _categoryDal.Get(x => x.Id == id);
			return _categoryDal.Delete(category);
		}
	}

	public interface ICategoryService
	{
		IList<Category> GetAllCategories();
		IList<Category> GetAllCategories(Expression<Func<Category, bool>> filter = null);
		Category GetCategoryIncluded(Expression<Func<Category,bool >>filter =null);
		Category AddCategory(Category entity);
		Category GetCategory(Expression<Func<Category,bool>> filter = null);
		Category UpdateCategory(Category entity);
		bool DeleteCategory(int id);



	}
}
