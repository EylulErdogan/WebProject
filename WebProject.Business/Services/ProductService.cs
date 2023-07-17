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
	public class ProductService : IProductService
	{
		private IProductDal _productDal;

		public ProductService(IProductDal productDal)
		{
			_productDal = productDal;
		}
		
		public IList<Product> GetAll()
		{
			return _productDal.GetAll();
		}
		public IList<Product> GetAll(Expression<Func<Product, bool>> filter)
		{
			return _productDal.GetAll(filter);
		}
		public IList<Product> GetAllIncluded(Expression<Func<Product, bool>> filter)
		{
			return _productDal.GetAllIncluded(filter);
		}

		public Product AddProduct(Product product)
		{
			return _productDal.Add(product);
		}
		public Product UpdateProduct(Product product)
		{
			return _productDal.Update(product);
		}
		public Product GetBySeourl(string seoUrl)
		{
			return _productDal.Get(x => x.SeoLink == seoUrl);
		}

        public Product GetById(int productId)
        {
            return _productDal.Get(x => x.Id == productId);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
		{
			return _productDal.Get(filter);
		}
		public Product GetIncluded(Expression<Func<Product, bool>> filter)
		{
			return _productDal.GetIncluded(filter);
		}

		public bool DeleteProduct(int id)
		{
			var product = _productDal.Get(x => x.Id == id);
			return _productDal.Delete(product);
		}

	}

	public interface IProductService
	{
		Product Get(Expression<Func<Product, bool>> filter);
		Product GetIncluded(Expression<Func<Product, bool>> filter);
		Product AddProduct(Product product);
		Product UpdateProduct(Product product);
		bool DeleteProduct(int id);
		IList<Product> GetAll();
		IList<Product> GetAll(Expression<Func<Product, bool>> filter);
		IList<Product> GetAllIncluded(Expression<Func<Product, bool>> filter);
		Product GetBySeourl(string seoUrl);
        Product GetById(int productId);


    }

}
