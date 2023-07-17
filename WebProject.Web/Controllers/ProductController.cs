using Microsoft.AspNetCore.Mvc;
using WebProject.Business.ControllerHandler;
using WebProject.Business.Services;

namespace WebProject.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductControllerHandler _productControllerHandler;

        public ProductController(IProductControllerHandler productControllerHandler)
        {
            _productControllerHandler = productControllerHandler;
        }

        public IActionResult Index(string name)
		{
			return View(_productControllerHandler.Get(name));
		}
	}
}
