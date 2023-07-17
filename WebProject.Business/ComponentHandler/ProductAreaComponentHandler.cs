using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebProject.Business.Services;
using WebProject.Entities;

namespace WebProject.Business.ComponentHandler
{
	public class ProductAreaComponentHandler : IProductAreaComponentHandler
	{
		private ICategoryService _categoryService;
		private IProductCategoryService _productCategoryService;
		private IProductService _productService;
		private IProductImageService _productImageService;

		public ProductAreaComponentHandler(ICategoryService categoryService, IProductCategoryService productCategoryService, IProductService productService, IProductImageService productImageService)
		{
			_categoryService = categoryService;
			_productCategoryService = productCategoryService;
			_productService = productService;
			_productImageService = productImageService;
		}

		public IList<Product> GetProducts()
		{
			return _productService.GetAll();
		}

		public IList<Category> GetCategories()
		{
			return _categoryService.GetAllCategories();
		}

		public IList<ProductCategory> GetProductCategories()
		{
			return _productCategoryService.GetAll();
		}

		public IList<ProductImage> GetProductImages()
		{
			return _productImageService.GetAll();
		}
	}

	public interface IProductAreaComponentHandler
	{
		IList<Product> GetProducts();
		IList<Category> GetCategories();
		IList<ProductCategory> GetProductCategories();
		IList<ProductImage> GetProductImages();
	}
}
