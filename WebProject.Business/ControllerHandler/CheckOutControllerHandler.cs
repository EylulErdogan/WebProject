using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebProject.Business.Helpers;
using WebProject.Business.Services;
using WebProject.Entities;

namespace WebProject.Business.ControllerHandler
{
	public class CheckOutControllerHandler : ICheckOutControllerHandler
	{
		private IUserService _userService;
		private IBasketService _basketService;
		private ICookieHelper _cookieHelper;
		private IBasketProductService _basketProductService;
		private IOrderService _orderService;

		public CheckOutControllerHandler(IUserService userService, IBasketService basketService, ICookieHelper cookieHelper, IBasketProductService basketProductService, IOrderService orderService)
		{
			_userService = userService;
			_basketService = basketService;
			_cookieHelper = cookieHelper;
			_basketProductService = basketProductService;
			_orderService = orderService;
		}

		public User GetUser(HttpRequest request)
		{
			var cookie = _cookieHelper.Read(CookieTypes.Basket, request);
			if (cookie != null)
			{
				var user = _userService.GetUserDataWithGuidKey(cookie);
				return user;
			}
			else
			{
				return null;
			}
		}

		public IList<VwBasketProductList> GetBasketProducts(HttpRequest request)
		{
			var guidKey = _cookieHelper.Read(CookieTypes.Basket, request);
			return _basketProductService.VwBasketProductList(guidKey);
		}

		public bool SetOrder(string city, string firstname, string lastname, string address, string email, string phone,HttpRequest request)
		{
			var order = _orderService.Add(new Orders()
			{
				Address = address,
				Email = email,
				Phone = phone,
				CreateDate = DateTime.Now,
				FirstName = firstname,
				LastName = lastname,
				PaymentType = 1,
				UserId = null
			});
			var guid = _cookieHelper.Read(CookieTypes.Basket, request);
			var basketProducts = _basketProductService.VwBasketProductList(guid);
			_orderService.AddOrderProducts(basketProducts, order.Id);
			return true;
		}
	}

	public interface ICheckOutControllerHandler
	{
		User GetUser(HttpRequest request);
		IList<VwBasketProductList> GetBasketProducts(HttpRequest request);

		bool SetOrder(string city, string firstname, string lastname, string address, string email,string phone, HttpRequest request);
	}
}
