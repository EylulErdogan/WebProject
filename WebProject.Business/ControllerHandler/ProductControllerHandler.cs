using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebProject.Business.Models;
using WebProject.Business.Services;
using WebProject.Entities;

namespace WebProject.Business.ControllerHandler
{
    public class ProductControllerHandler : IProductControllerHandler
    {
        IProductService _productService;
        IProductCategoryService _productCategoryService;
        IProductImageService _productImageService;

        public ProductControllerHandler(IProductService productService, IProductImageService productImageService, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productImageService = productImageService;
            _productCategoryService = productCategoryService;
        }
        
        public ProductControllerHandlerModel Get(string name)
        {
            var productDetail = _productService.GetBySeourl(name);
            var productImages = _productImageService.GetAllByProductId(productDetail.Id);
            
            ProductControllerHandlerModel model = new ProductControllerHandlerModel();
            model.Images = productImages;
            model.Product = productDetail;
            return model;                                                          
        }

        public Product GetProduct(Expression<Func<Product, bool>> filter = null)
        {
	        return _productService.Get(filter);
        }
        public Product GetProductIncluded(Expression<Func<Product, bool>> filter = null)
        {
	        return _productService.GetIncluded(filter);
        }  
       
		public IList<Product> GetAllIncluded(Expression<Func<Product, bool>> filter = null)
        {
	       return _productService.GetAllIncluded(filter);
        }
		public Product AddProduct(Product entity)
        {
	        return _productService.AddProduct(entity);
        } 
        public ProductCategory AddProductCategory(ProductCategory entity)
        {
	        return _productCategoryService.AddProductCategory(entity);
        }
        public ProductImage AddProductImage(ProductImage entity)
        {
	        return _productImageService.AddProductImage(entity);
        }
        public IList<ProductImage> GetProductImages(Expression<Func<ProductImage, bool>> filter = null)
        {
	        return _productImageService.GetProductImages(filter);
        }
		public Product UpdateProduct(Product entity)
        {
	        return _productService.UpdateProduct(entity);
        }

		public bool DeleteProduct(int id)
		{
	        return _productService.DeleteProduct(id);
		}
		public bool DeleteAllProductCategoriesByProductId(int productId)
		{
	        return _productCategoryService.DeleteAllProductCategoriesByProductId(productId);
		}
		public bool DeleteProductImage(ProductImage entity)
		{
			return _productImageService.DeleteProductImage(entity);
		}

	}

	public interface IProductControllerHandler
	{
		ProductCategory AddProductCategory(ProductCategory entity);
		ProductImage AddProductImage(ProductImage entity);
		bool DeleteProductImage(ProductImage entity);
		IList<ProductImage> GetProductImages(Expression<Func<ProductImage, bool>> filter = null);
		Product GetProduct(Expression<Func<Product, bool>> filter = null);
		Product GetProductIncluded(Expression<Func<Product, bool>> filter = null);
		Product AddProduct(Product entity);
        Product UpdateProduct(Product entity);
		bool DeleteProduct(int id);
		bool DeleteAllProductCategoriesByProductId(int productId);
        ProductControllerHandlerModel Get(string name);
        IList<Product> GetAllIncluded(Expression<Func<Product, bool>> filter = null);


	}
}
