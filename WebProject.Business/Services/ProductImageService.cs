using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.Abstract;
using WebProject.Entities;

namespace WebProject.Business.Services
{
	public class ProductImageService : IProductImageService
	{
		private IProductImageDal _productImageDal;

		public ProductImageService(IProductImageDal productImageDal)
		{
			_productImageDal = productImageDal;
		}

		public ProductImage AddProductImage(ProductImage entity)
		{
			return _productImageDal.Add(entity);
		}
		public IList<ProductImage> GetAllByProductId(int productId)
		{
			return _productImageDal.GetAll(x => x.ProductId == productId).OrderBy(o=>o.Sort).ToList();
		}

		public ProductImage GetById(int productId)
		{
			return _productImageDal.Get(x => x.ProductId == productId);
		}

		public IList<ProductImage> GetAll()
		{
			return _productImageDal.GetAll();
		}
		public IList<ProductImage> GetProductImages(Expression<Func<ProductImage, bool>> filter = null)
		{
			return _productImageDal.GetProductImages(filter);
		}
		public bool DeleteProductImage(ProductImage entity)
		{
			return _productImageDal.DeleteProductImage(entity);
		}
	}

	public interface IProductImageService
	{
		ProductImage AddProductImage(ProductImage entity);
		IList<ProductImage> GetAllByProductId(int productId);
		ProductImage GetById(int productId);
		IList<ProductImage> GetAll();
		IList<ProductImage> GetProductImages(Expression<Func<ProductImage, bool>> filter = null);
		bool DeleteProductImage(ProductImage entity);

	}

}