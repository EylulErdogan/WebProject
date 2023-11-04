using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebProject.Core.DataAccess;
using WebProject.Data.Abstract;
using WebProject.Entities;

namespace WebProject.Data.Concrete
{
	//3. Adım tablo eklendi sonra Contex e dbset eklenir
	public class CategoryDal : EfEntityRepostoryBase<Category, WebProjectContext>, ICategoryDal
	{
		public IList<Category> GetAllCategoryIncluded(Expression<Func<Category, bool>> filter)
		{
			using (var context = new WebProjectContext())
			{
				var query = context.Categories
					.Include(x => x.ProductCategories);


				if (filter == null)
				{
					return query.ToList();
				}
				else
				{
					return query.Where(filter).ToList();
				}

			}
		}

		public Category GetCategoryIncluded(Expression<Func<Category, bool>> filter = null)
		{
			using (var context = new WebProjectContext())
			{
				var query = context.Categories
					.Include(x => x.ProductCategories);

				if (filter == null)
				{
					return query.FirstOrDefault();
				}
				else
				{
					return query.Where(filter).FirstOrDefault();
				}

			}
		}
	}
}
