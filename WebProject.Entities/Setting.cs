using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core;

namespace WebProject.Entities
{
	public class Setting : IEntity
	{
		public string Id { get; set; }
		public string? SettingValue { get; set; }
	}
}
