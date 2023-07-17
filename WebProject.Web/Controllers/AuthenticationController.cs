using Microsoft.AspNetCore.Mvc;
using WebProject.Business.ControllerHandler;
using WebProject.Business.Helpers;
using WebProject.Entities;
using WebProject.Web.Models;

namespace WebProject.Web.Controllers
{
	public class AuthenticationController : Controller
	{
		private readonly IAuthenticationControllerHandler _authenticationControllerHandler;

		public AuthenticationController(IAuthenticationControllerHandler authenticationControllerHandler)
		{
			_authenticationControllerHandler = authenticationControllerHandler;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				//response nesnesine sadece controller içerisindeki action içerisinden erişilebilir
				var user = _authenticationControllerHandler.UserLogin(model.Email, model.Password, Response);
				if (user != null)
				{
					if (user.IsAdmin)
					{
						return Redirect("/admin/home/index");
					}
					return RedirectToAction("Index", "Home", user);
				}
				return RedirectToAction("Index", "Home");

			}
			else
			{
				return View(model); // kullannıcı hatalı işlem yaparsa aynen girdiği datalar geri gönderilir yani e mail adresini tekrar girmesine gerek kalmaz.
			}

		}
		[HttpPost]
		public IActionResult Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				var modelUser = new User()
				{
					Email = model.Email,
					Password = model.Password,
					FullName = model.FullName,
					IsAdmin = false,
					RegisterDate = DateTime.Now,
					Status = true
				};
				//response nesnesine sadece controller içerisindeki action içerisinden erişilebilir
				var user = _authenticationControllerHandler.Register(modelUser, Response);
				if (user != null)
				{
					if (user.IsAdmin)
					{
						return Redirect("/admin/home/index");

					}
					return RedirectToAction("Index", "Home", user);
				}
				return RedirectToAction("Index", "Home");
			}
			else
			{
				return View(model); // kullannıcı hatalı işlem yaparsa aynen girdiği datalar geri gönderilir yani e mail adresini tekrar girmesine gerek kalmaz.
			}

		}

		public IActionResult Exit()
		{
			bool result = _authenticationControllerHandler.Exit(Request);
			if (result)
			{
				return RedirectToAction("Index", "Home");
			}
			else
			{
				return RedirectToAction("Error", "Home");
			}
			return View();
		}
	}
}
