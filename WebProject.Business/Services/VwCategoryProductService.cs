using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.Abstract;
using WebProject.Entities;

namespace WebProject.Business.Services
{
	public class VwCategoryProductService : IVwCategoryProductService
	{
		private IVwCategoryProductDal _vwCategoryProductDal;
		ISettingService _settingService;

		public VwCategoryProductService(IVwCategoryProductDal vwCategoryProductDal, ISettingService settingService)
		{
			_vwCategoryProductDal = vwCategoryProductDal;
			_settingService = settingService;
		}

		public IList<VwCategoryProduct> List(string catSeoName, int page)
		{
			var maxCategoryProduct = _settingService.GetSetting("max-category-product").SettingValue.ToInt32();
			var products= _vwCategoryProductDal.GetAll(x=> x.SeoLinkCat == catSeoName);

			var result = products.Skip((page*maxCategoryProduct)-maxCategoryProduct).Take(maxCategoryProduct).ToList();
			return result;
		}

		public int CalculatePage(string catSeoName)
		{
			var products = _vwCategoryProductDal.GetAll(x => x.SeoLinkCat == catSeoName);
			int pageProductCount = products.Count;
			var maxCategoryProducts = _settingService.GetSetting("max-category-product").SettingValue.ToInt32();

			var pageCount = 0;
			var mod = pageProductCount% maxCategoryProducts;
			if (mod ==0)
			{
				return pageProductCount / maxCategoryProducts;
			}
			else
			{
				var lastProduct = pageProductCount % maxCategoryProducts;
				return((pageProductCount-lastProduct)/ maxCategoryProducts) + 1;
			}
		}

		public int CalculatePageSearch(string query)
		{
			var products = _vwCategoryProductDal.GetAll(x => x.Name.ToUpper().Contains(query.ToUpper()) || x.ProductDescription.ToUpper().Contains(query.ToUpper()));
			int pageProductCount = products.Count;
			var maxCategoryProducts = _settingService.GetSetting("max-category-product").SettingValue.ToInt32();

			var pageCount = 0;
			var mod = pageProductCount % maxCategoryProducts;
			if (mod == 0)
			{
				return pageProductCount / maxCategoryProducts;
			}
			else
			{
				var lastProduct = pageProductCount % maxCategoryProducts;
				return ((pageProductCount - lastProduct) / maxCategoryProducts) + 1;
			}
		}

		public IList<VwCategoryProduct> Search(string query, int page = 1)
		{
			var maxCategoryProduct = _settingService.GetSetting("max-category-product").SettingValue.ToInt32();
			var products =
				_vwCategoryProductDal.GetAll(x => x.Name.Contains(query) || x.ProductDescription.Contains(query));

			var result = products.Skip((page * maxCategoryProduct) - maxCategoryProduct).Take(maxCategoryProduct).ToList();
			return result;
		}
	}

	public interface IVwCategoryProductService
	{
		public IList<VwCategoryProduct> List(string catSeoName ,int page=1);
		public int CalculatePage(string catSeoName);
		public int CalculatePageSearch(string query);
		public IList<VwCategoryProduct> Search(string query, int page =1);
	

	}
}
