using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebProject.Business.ComponentHandler;
using WebProject.Business.ControllerHandler;
using WebProject.Web.Models;

namespace WebProject.Web.ViewComponents
{
	public class ProductAreaViewComponent : ViewComponent
	{
		private IProductAreaComponentHandler _productAreaComponentHandler;
		public ProductAreaViewComponent(IProductAreaComponentHandler productAreaComponentHandler)
		{
			_productAreaComponentHandler = productAreaComponentHandler;
		}

		public ViewViewComponentResult Invoke()
		{
			ProductAreaModel model = new ProductAreaModel();
			model.Categories = _productAreaComponentHandler.GetCategories().Where(x => x.ParentId == 0).ToList();
			model.ProductCategories = _productAreaComponentHandler.GetProductCategories();
			model.Products = _productAreaComponentHandler.GetProducts();
			model.ProductImages = _productAreaComponentHandler.GetProductImages();

			return View(model);
		}
	}
}
