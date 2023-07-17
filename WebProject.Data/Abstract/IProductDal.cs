using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core.DataAccess;
using WebProject.Entities;

namespace WebProject.Data.Abstract
{
	public interface IProductDal : IEfEntityRepositoryBase<Product>
	{
		Product GetIncluded(Expression<Func<Product, bool>> filter);
		IList<Product> GetAllIncluded(Expression<Func<Product, bool>> filter);
	}

}
