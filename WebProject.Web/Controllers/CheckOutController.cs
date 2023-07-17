using Microsoft.AspNetCore.Mvc;
using WebProject.Business.ControllerHandler;
using WebProject.Web.Models;

namespace WebProject.Web.Controllers
{
    public class CheckOutController : Controller
    {
        private ICheckOutControllerHandler _checkOutControllerHandler;

        public CheckOutController(ICheckOutControllerHandler checkOutControllerHandler)
        {
            _checkOutControllerHandler = checkOutControllerHandler;
        }

        public IActionResult Index()
        {
            var basket = _checkOutControllerHandler.GetBasketProducts(Request);
            if (basket == null || basket.Count == 0)
            {
                return RedirectToAction("Index","Home");
            }

            var user = _checkOutControllerHandler.GetUser(Request);
            CheckOutModel model = new CheckOutModel();
            model.BasketProducts = basket;
            model.User = user ?? null;
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string city, string firstname, string lastname, string address, string email, string phone)
        {
	       var result = _checkOutControllerHandler.SetOrder(city, firstname, lastname, address, email, phone, Request);
	        if (result)
	        {
		        return View("OrderOk");
	        }
	        else
	        {
		        return View("OrderFailed");
	        }

        }
    }
}
