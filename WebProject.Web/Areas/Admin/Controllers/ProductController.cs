using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.FileProviders;
using WebProject.Business.ControllerHandler;
using WebProject.Business.Services;
using WebProject.Entities;
using WebProject.Web.Areas.Admin.Models;

namespace WebProject.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private IProductControllerHandler _productControllerHandler;
		private ICategoryControllerHandler _categoryControllerHandler;
		private IWebHostEnvironment _env;
		private string imageRootUrl;


		public ProductController(IProductControllerHandler productControllerHandler, ICategoryControllerHandler categoryControllerHandler, IWebHostEnvironment env)
        {
            _productControllerHandler = productControllerHandler;
            _categoryControllerHandler = categoryControllerHandler;
            _env = env;
            imageRootUrl = Path.Combine(Path.Combine(_env.WebRootPath, "assets"), "images");
        }

		//      public IActionResult Index()
		//      {

		//	return View();
		//}

		public IActionResult Index()
		{
			var products = _productControllerHandler.GetAllIncluded();
			return View(products);
		}

		public IActionResult AddProduct()
		{
			var productModel = new ProductModel();
			productModel.Categories = _categoryControllerHandler.GetCategories();
			return View(productModel);
		}
		[HttpPost]
		public IActionResult AddProduct(ProductModel model)
		{
			var files = Request.Form.Files;

			var product = new Product
			{
				Name = model.Name,
				Price = model.Price,
				ProductDescription = model.ProductDescription,
				SeoLink = model.SeoLink,
			};
			
			

			product = _productControllerHandler.AddProduct(product);
			if (product.Id > 0)
			{
				foreach (var CategoryId in model.SelectedCategoryIds)
				{
					_productControllerHandler.AddProductCategory(new ProductCategory
					{ CategoryId = CategoryId, ProductId = product.Id });
				}

				for (int i = 0; i < files.Count; i++)
				{
					var file = files[i];
					var productImage = new ProductImage
					{
						ImageUrl = "/assets/images/product-image/" + file.FileName,
						FileName = file.FileName,
						ProductId = product.Id,
						IsCover = i == 0
					};
					_productControllerHandler.AddProductImage(productImage);

					var fileUrl = Path.Combine(Path.Combine(imageRootUrl, "product-image"), file.FileName);
					if (!System.IO.File.Exists(fileUrl))
					{
						using (Stream fileStream = new FileStream(fileUrl, FileMode.Create))
						{
							file.CopyTo(fileStream);
						}
					}
				}
			}
			return Redirect(" /admin/product/index");
		}

		[HttpGet("UpdateProduct/{id}")]
		public IActionResult UpdateProduct(int id)
		{
			var product = _productControllerHandler.GetProductIncluded(x => x.Id == id);
			var productModel = new ProductModel
			{
				Name = product.Name,
				Price = product.Price,
				ProductDescription = product.ProductDescription,
				SeoLink = product.SeoLink,
				BrendId = product.BrendId,
				Id = product.Id,
				ProductImages = product.ProductImages,
				ProductCategories = product.ProductCategories,
			};
			productModel.Categories = _categoryControllerHandler.GetCategories().Where(x=>x.ParentId == 0).ToList();
			productModel.SelectedCategoryIds = productModel.ProductCategories.Select(x => x.CategoryId).ToArray();
			return View(productModel);
		}

		[HttpPost("UpdateProduct/{id}")]
		public IActionResult UpdateProduct(ProductModel model)
		{
			var productModel = new Product
			{
				Id = model.Id,
				Name = model.Name,
				Price = model.Price,
				ProductDescription = model.ProductDescription,
				SeoLink = model.SeoLink,
				BrendId = model.BrendId,
				ProductImages = model.ProductImages,
				ProductCategories = model.ProductCategories,
				
			};
			_productControllerHandler.UpdateProduct(productModel);

			_productControllerHandler.DeleteAllProductCategoriesByProductId(model.Id);
			foreach (var CategoryId in model.SelectedCategoryIds)
			{
				_productControllerHandler.AddProductCategory(new ProductCategory
				{ CategoryId = CategoryId, ProductId = productModel.Id });
			}
			return Redirect("/admin/product/index");
		}

		[HttpGet("DeleteProduct/{id}")]
		public IActionResult DeleteProduct(int id)
		{
			//önce product categories silinecek
			_productControllerHandler.DeleteAllProductCategoriesByProductId(id);

			var productImages = _productControllerHandler.GetProductImages(x => x.ProductId == id);
			foreach (var productImage in productImages)
			{
				//sonra Product Images tablosundaki url içindeki gerçek foto silinecek
				var fileUrl = Path.Combine(Path.Combine(imageRootUrl, "product-image"), productImage.FileName);

				System.IO.File.Delete(fileUrl);
			//sonra Product Images silinecek
				_productControllerHandler.DeleteProductImage(productImage);
			}
			//sonra product silinecek


			_productControllerHandler.DeleteProduct(id);


			return Redirect("/admin/product/index");
		}
	}
}
