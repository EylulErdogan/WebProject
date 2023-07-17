using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core.DataAccess;
using WebProject.Data.Concrete;
using WebProject.Entities;

namespace WebProject.Data.Abstract
{
	public interface IProductImageDal : IEfEntityRepositoryBase<ProductImage>
	{
		IList<ProductImage> GetProductImages(Expression<Func<ProductImage, bool>> filter = null);
		bool DeleteProductImage(ProductImage entity);
	}
}
