using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core.DataAccess;
using WebProject.Data.Abstract;
using WebProject.Entities;

namespace WebProject.Data.Concrete
{
	public class ProductImageDal : EfEntityRepostoryBase<ProductImage, WebProjectContext> , IProductImageDal
	{
		public IList<ProductImage> GetProductImages(Expression<Func<ProductImage, bool>> filter = null)
		{
			using (var context = new WebProjectContext())
			{
				return context.ProductImages.Where(filter).ToList();
			}
		}
		public bool DeleteProductImage(ProductImage entity)
		{
			using (var context = new WebProjectContext())
			{
				return this.Delete(entity);
			}
		}
	}
}
