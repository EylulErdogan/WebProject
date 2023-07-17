using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.Abstract;
using WebProject.Entities;

namespace WebProject.Business.Services
{
	public class ProductCategoryService : IProductCategoryService
	{
		private readonly IProductCategoryDal _productCategoryDal;

		public ProductCategoryService(IProductCategoryDal productCategoryDal)
		{
			_productCategoryDal = productCategoryDal;
		}

		public IList<ProductCategory> GetProductsWithCategory(int categoryId)
		{
			return _productCategoryDal.GetAll(x => x.CategoryId == categoryId);
		}

		public IList<ProductCategory> GetAll()
		{
			return _productCategoryDal.GetAll();
		}

		public ProductCategory AddProductCategory(ProductCategory entity)
		{
			return _productCategoryDal.Add(entity);
		}

		public bool DeleteAllProductCategoriesByProductId(int productId)
		{
			var entities = _productCategoryDal.GetAll(x => x.ProductId == productId);
			foreach (var entity in entities)
			{
				_productCategoryDal.Delete(entity);
			}
			return true;
		}
	}


public interface IProductCategoryService
	{
		ProductCategory AddProductCategory(ProductCategory entity);
		bool DeleteAllProductCategoriesByProductId(int productId);
		IList<ProductCategory> GetProductsWithCategory(int categoryId);
		IList<ProductCategory> GetAll();
	}
}
