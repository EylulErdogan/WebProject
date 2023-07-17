using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core;

namespace WebProject.Entities
{
	public class ProductCategory :  IEntity
	{
		[Key]
		public int ProductId { get; set; }
		public int CategoryId { get; set; }
		public int? Sort { get; set; }
		public Product Product { get; set; }
		public Category Category { get; set; }
	}
}
