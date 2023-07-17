using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using WebProject.Core;

namespace WebProject.Entities
{
	public class ProductImage : IEntity
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public string ImageUrl { get; set; }
		public string FileName { get; set; }
		public int Sort { get; set; }
		public bool IsCover { get; set; }
	}
}
