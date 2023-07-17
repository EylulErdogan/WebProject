using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core;

namespace WebProject.Entities
{
	public class Product : IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int? BrendId { get; set; }
		public string SeoLink { get; set; }
		public string ProductDescription { get; set; }

		public IList<ProductImage> ProductImages { get; set; }
		public IList<ProductCategory> ProductCategories{ get; set; }

	}
}
