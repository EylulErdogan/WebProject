using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core.DataAccess;
using WebProject.Entities;

namespace WebProject.Data.Abstract
{
	// 2. Adım tablo eklendikten sonra dal interfacesi oluşturulur daha sonra  concrate dal eklenir
	public interface ICategoryDal : IEfEntityRepositoryBase<Category>
	{
		public IList<Category> GetAllCategoryIncluded(Expression<Func<Category, bool>> filter=null);
		public Category GetCategoryIncluded(Expression<Func<Category, bool>> filter = null);
	}
}
