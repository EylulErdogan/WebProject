using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.Abstract;
using WebProject.Entities;

namespace WebProject.Business.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderDal _orderDal;
		private readonly IOrderProductsDal _orderProductsDal;

		public OrderService(IOrderDal orderDal, IOrderProductsDal orderProductsDal)
		{
			_orderDal = orderDal;
			_orderProductsDal = orderProductsDal;
		}

		public Orders Add(Orders data)
		{
			_orderDal.Add(data);
			return data;
		}

		public bool AddOrderProducts(IList<VwBasketProductList> products,int orderId)
		{
			foreach (var item in products)
			{
				_orderProductsDal.Add(new OrderProduct()
				{
					ProductId = item.ProductId,
					OrderId = orderId,
					Quantity = item.Quantity,
					Price = item.Price.Value

				});
			}
			return true;
		}
	}

	public interface IOrderService
	{
		public Orders Add(Orders data);
		public bool AddOrderProducts(IList<VwBasketProductList> products, int orderId);
	}
}
