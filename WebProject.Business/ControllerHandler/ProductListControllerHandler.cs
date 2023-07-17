using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Business.Services;
using WebProject.Entities;

namespace WebProject.Business.ControllerHandler
{
	public class ProductListControllerHandler : IProductListControllerHandler
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
		private readonly IProductCategoryService _productCategoryService;
		private readonly IProductImageService _productImageService;
		private readonly IVwCategoryProductService _vwCategoryProductService;

		public ProductListControllerHandler(ICategoryService categoryService, IProductService productService, IProductCategoryService productCategoryService, IProductImageService productImageService, IVwCategoryProductService vwCategoryProductService)
		{
			_categoryService = categoryService;
			_productService = productService;
			_productCategoryService = productCategoryService;
			_productImageService = productImageService;
			_vwCategoryProductService = vwCategoryProductService;
		}

		public IList<VwCategoryProduct> GetProducts(string seoName, int page)
		{
			var data = _vwCategoryProductService.List(seoName,page);
			return data;
		}

		public int CalculatePage(string seoName)
		{
			return _vwCategoryProductService.CalculatePage(seoName);
		}

		public int CalculatePageSearch(string query)
		{
			return _vwCategoryProductService.CalculatePageSearch(query);
		}


		public IList<VwCategoryProduct> SearchProduct(string query, int page)
		{
			var data = _vwCategoryProductService.Search(query, page);
			return data; 
		}
	}
	public interface IProductListControllerHandler
	{
		public IList<VwCategoryProduct> GetProducts(string seoName,int page);
		public int CalculatePage(string seoName);
		public int CalculatePageSearch(string query);
		public IList<VwCategoryProduct> SearchProduct(string query, int page);
	}
}
