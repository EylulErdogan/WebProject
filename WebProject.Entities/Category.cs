using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core;

namespace WebProject.Entities
{
	public class Category : IEntity
	{
		//Yeni Tablo geldiğinde ilk entity oluşturulur 
		public int Id { get; set; }
		public string Name { get; set; }
		public int Sort { get; set; }
		public string? IconName { get; set; }
		public string? Link { get; set; }
		public int? ParentId { get; set; }
		public IList<ProductCategory> ProductCategories { get; set; }
		public string? SeoLink { get; set; }


	}
}
