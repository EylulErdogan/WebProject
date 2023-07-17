using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core;

namespace WebProject.Entities
{
	public class Basket : IEntity
	{
		public Guid Id { get; set; }
		public int UserId { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime? OrderDate { get; set; }
		public int? OrderId { get; set; }
		public bool? Status { get; set; }
	}
}
