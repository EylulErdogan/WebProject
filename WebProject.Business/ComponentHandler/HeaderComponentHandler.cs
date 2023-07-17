using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebProject.Business.Helpers;
using WebProject.Business.Services;
using WebProject.Entities;

namespace WebProject.Business.ComponentHandler
{

	public class HeaderComponentHandler : IHeaderComponentHandler
	{
		private readonly ICookieHelper _cookieHelper;
		private readonly IUserService _userService;

		public HeaderComponentHandler(ICookieHelper cookieHelper, IUserService userService)
		{
			_cookieHelper = cookieHelper;
			_userService = userService;
		}

		public User GetUserData(string guidKey, HttpRequest request)
		{
			// Bug: cookie silindi ise null
			var cookie = _cookieHelper.Read(CookieTypes.User, request);
			if (Equals(cookie == null))
			{
				return null;
			}
			var user = _userService.GetUserDataWithGuidKey(cookie);
			return user;
		}
	}

	public interface IHeaderComponentHandler
	{
		User GetUserData(string guidKey, HttpRequest request);
	}
}
