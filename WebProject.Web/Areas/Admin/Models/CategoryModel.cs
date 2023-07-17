using WebProject.Entities;

namespace WebProject.Web.Areas.Admin.Models
{
	public class CategoryModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Sort { get; set; }
		public string? IconName { get; set; }
		public string? Link { get; set; }
		public int? ParentId { get; set; }
		public IList<ProductCategory> ProductCategories { get; set; }
	}
}
