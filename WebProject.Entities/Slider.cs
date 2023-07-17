using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core;

namespace WebProject.Entities
{
	public class Slider :IEntity
	{
		public int Id { get; set; }
		public string ImageUrl { get; set; }
		public string Sort { get; set; }
		public string? Header1 { get; set; }
		public string? Header2 { get; set; }
		public string? ProductLink { get; set; }
		public string? Name  { get; set; }
	}
}
