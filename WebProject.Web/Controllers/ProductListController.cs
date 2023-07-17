using Microsoft.AspNetCore.Mvc;
using WebProject.Business.ControllerHandler;
using WebProject.Web.Models;

namespace WebProject.Web.Controllers
{
	public class ProductListController : Controller
	{
		private IProductListControllerHandler _productListControllerHandler;

		public ProductListController(IProductListControllerHandler productListControllerHandler)
		{
			_productListControllerHandler = productListControllerHandler;
		}

		public IActionResult Index(string name , int? page =0)
		{
			var data = _productListControllerHandler.GetProducts(name, page.Value);
			ProductListViewModel productListViewModel = new ProductListViewModel();
			productListViewModel.Products = data;
			productListViewModel.PageCount = _productListControllerHandler.CalculatePage(name);
			productListViewModel.CurrentPage = page.Value;
			productListViewModel.CurrentCategory = name;
			return View(productListViewModel);
		}
		public IActionResult Search(int? page = 0)
		{
			var query = HttpContext.Request.Query["search"].ToString();
			var data = _productListControllerHandler.SearchProduct(query, page.Value);
			ProductListViewModel productListViewModel = new ProductListViewModel();
			productListViewModel.Products = data;
			productListViewModel.PageCount = _productListControllerHandler.CalculatePageSearch(query);
			productListViewModel.CurrentPage = page.Value;
			productListViewModel.CurrentCategory = query;
			return View(productListViewModel);
		}
		[HttpPost]
		public IActionResult SearchRedirect(string search)
		{
			return Redirect("/arama/?search=" + search);
		}
	}
}
