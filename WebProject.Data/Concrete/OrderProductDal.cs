using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core.DataAccess;
using WebProject.Data.Abstract;
using WebProject.Entities;

namespace WebProject.Data.Concrete
{
    public class OrderProductDal : EfEntityRepostoryBase<OrderProduct, WebProjectContext>,IOrderProductsDal
    {
    }
}
