using WebProject.Entities;

namespace WebProject.Web.Areas.Admin.Models
{
    public class ProductModel
    {
	    public int Id { get; set; }
	    public string Name { get; set; }
	    public decimal Price { get; set; }
	    public int? BrendId { get; set; }
	    public string SeoLink { get; set; }
	    public string ProductDescription { get; set; }
	    public int[] SelectedCategoryIds{ get; set; }
	    public string ImageUrl { get; set; }
	    public bool IsPopular{ get; set; }
	    public IList<Category>Categories { get; set; }
	    public IList<ProductImage> ProductImages { get; set; }
	    public IList<ProductCategory> ProductCategories { get; set; }
	}
}
