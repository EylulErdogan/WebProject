using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace WebProject.Core.DataAccess
{
    //Burası Insert Delete Update Listeleme Tek değer getirme işlemlerinin yapıldığı kısımdır. 
    public interface IEfEntityRepositoryBase<TEntity>
        where TEntity : class,IEntity,new()
    {
	    TEntity Add(TEntity entity);
        bool Delete(TEntity entity);
        //Expression sorgu  oluşturmamızı sağlar Func ise bu sorgunun hangi tablo nesnesi üzerinde kullanacağını belirtmemizi sağlar 
        TEntity Get(Expression<Func<TEntity,bool>> filter);


		IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
		TEntity Update(TEntity entity);

        bool Any(Expression<Func<TEntity, bool>> filter);
    }
}
