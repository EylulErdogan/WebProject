using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebProject.Core;
using WebProject.Core.DataAccess;
using WebProject.Data.Abstract;
using WebProject.Entities;

namespace WebProject.Data.Concrete
{
	public class ProductDal : EfEntityRepostoryBase<Product , WebProjectContext>,IProductDal
	{
		public IList<Product> GetAllIncluded(Expression<Func<Product, bool>> filter)
		{
			using (var context = new WebProjectContext())
			{
				var query = context.Products
					.Include(x => x.ProductImages)
					.Include(x => x.ProductCategories).ThenInclude(y => y.Category)
					.AsQueryable();

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
		public Product GetIncluded(Expression<Func<Product, bool>> filter)
		{
			using (var context = new WebProjectContext())
			{
				var query = context.Products
					.Include(x => x.ProductImages)
					.Include(x => x.ProductCategories).ThenInclude(y => y.Category)
					.AsQueryable();

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
