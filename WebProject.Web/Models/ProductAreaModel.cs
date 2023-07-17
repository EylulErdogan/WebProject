using WebProject.Entities;

namespace WebProject.Web.Models
{
	public class ProductAreaModel
	{
		public IList<ProductCategory> ProductCategories { get; set; }
		public IList<Product> Products { get; set; }
		public IList<Category> Categories { get; set; }
		public IList<ProductImage> ProductImages { get; set; }
	}
}
