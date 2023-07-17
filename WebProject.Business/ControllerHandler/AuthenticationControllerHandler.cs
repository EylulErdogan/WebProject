using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebProject.Business.Helpers;
using WebProject.Business.Models;
using WebProject.Business.Services;
using WebProject.Entities;

namespace WebProject.Business.ControllerHandler
{
	public class AuthenticationControllerHandler : IAuthenticationControllerHandler
	{
		private readonly ILoginService _loginService;
		private readonly ICookieHelper _cookieHelper;
		private readonly IUserService _userService;

		public AuthenticationControllerHandler(ILoginService loginService, ICookieHelper cookieHelper, IUserService userService)
		{
			_loginService = loginService;
			_cookieHelper = cookieHelper;
			_userService = userService;
		}
		// Bunu dışarıdan kullanmayacağız sadeve cu class içinde kullanacağız
		private User Login(string email, string password)
		{
			User result = _loginService.Login(email, password);
			if (result == null)
			{
				return null;
			}

			return result;
		}

		public User UserLogin(string email, string password, HttpResponse httpResponse)
		{
			password = StringHelper.ToMd5(password).ToLower();
			var loginResult = Login(email, password);

			if (loginResult is not null)
			{
				var key = _userService.ChangeGuidKey(loginResult);
				_cookieHelper.Create(CookieTypes.User, key, DateTime.Now.AddYears(1), httpResponse);
			}
			return loginResult;
		}

		public User Register(User user, HttpResponse httpResponse)
		{
			user.Password = StringHelper.ToMd5(user.Password).ToLower();
			var userResult = _loginService.Register(user);
			if (userResult is not null)
			{
				var loginResult = Login(user.Email, user.Password);
				if (loginResult is not null)
				{
					var key = _userService.ChangeGuidKey(loginResult);
					_cookieHelper.Create(CookieTypes.User, key, DateTime.Now.AddYears(1), httpResponse);
				}
				return loginResult;
			}

			return null;
		}

		public User GetUserDataWithEmailAndPassword(string email, string password)
		{
			return _userService.GetUserDataWithEmailAndPassword(email, password);
		}
		public User GetUserDataWithGuidKey(string guid)
		{
			return _userService.GetUserDataWithGuidKey(guid);
		}

		public bool Exit(HttpRequest httpRequest)
		{
			try
			{
				var cookie = _cookieHelper.Read(CookieTypes.User, httpRequest);
				if (cookie == null)
				{
					return false;
				}
				_userService.ResetUserGuidKey(cookie);
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}
	}

	public interface IAuthenticationControllerHandler
	{
		// Login methodu interface içerisinde yer almaz sebebi ise login methodu private yani sadece class içerisinde erişilebilirdir Interface içerisine eklenen method imzaları sadece dışarıdan erişilebilen methodlar içindir 
		public User Register(User user, HttpResponse httpResponse);
		public User UserLogin(string email, string password, HttpResponse httpResponse);
		public User GetUserDataWithEmailAndPassword(string email, string password);
		public User GetUserDataWithGuidKey(string guid);
		public bool Exit(HttpRequest httpRequest);

	}
}
