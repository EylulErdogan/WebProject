using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using WebProject.Business.ComponentHandler;
using WebProject.Business.ControllerHandler;
using WebProject.Business.Helpers;
using WebProject.Business.Services;
using WebProject.Data.Abstract;
using WebProject.Data.Concrete;

namespace WebProject.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			//Yeni bir interface yazýlýrsa buraya eklememiz gerekir yoksa çalýþmaz.
			// Add services to the container.
			// AddScoped bir nesneyi request geldiði anda oluþturur response verildiði anda onu öldürür 
			builder.Services.AddControllersWithViews();
			builder.Services.AddScoped<IUserDal, UserDal>();
			builder.Services.AddScoped<ICategoryDal, CategoryDal>();
			builder.Services.AddScoped<ISliderDal, SliderDal>();
			builder.Services.AddScoped<IProductDal, ProductDal>();
			builder.Services.AddScoped<IProductImageDal, ProductImageDal>();
			builder.Services.AddScoped<IProductCategoryDal, ProductCategoryDal>();
			builder.Services.AddScoped<IBasketDal, BasketDal>();
			builder.Services.AddScoped<IBasketProductDal, BasketProductDal>();
			builder.Services.AddScoped<IVwCategoryProductDal,VwCategoryProductDal>();
			builder.Services.AddScoped<ISettingDal,SettingDal>();
			builder.Services.AddScoped<IVwBasketProductListDal,VwBasketProductListDal>();
			builder.Services.AddScoped<IOrderProductsDal,OrderProductDal>();
			builder.Services.AddScoped<IOrderDal,OrderDal>();
			builder.Services.AddScoped<IUserAddressDal,UserAddressDal>();

			builder.Services.AddScoped<ILoginService, LoginService>();
			builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();
			builder.Services.AddScoped<ISliderService, SliderService>();
			builder.Services.AddScoped<IProductService, ProductService>();
			builder.Services.AddScoped<IProductImageService, ProductImageService>();
			builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
			builder.Services.AddScoped<IBasketService, BasketService>();
			builder.Services.AddScoped<IBasketProductService, BasketProductService>();
			builder.Services.AddScoped<IVwCategoryProductService, VwCategoryProductService>();
			builder.Services.AddScoped<IVwCategoryProductService, VwCategoryProductService>();
			builder.Services.AddScoped<IOrderService, OrderService>();
			builder.Services.AddScoped<ISettingService, SettingService>();


			builder.Services.AddScoped<ICookieHelper, CookieHelper>();

			builder.Services.AddScoped<IAuthenticationControllerHandler, AuthenticationControllerHandler>();
			builder.Services.AddScoped<IHeaderComponentHandler, HeaderComponentHandler>();
			builder.Services.AddScoped<IMainMenuComponentHandler, MainMenuComponentHandler>();
			builder.Services.AddScoped<IIntroSliderComponentHandler, IntroSliderComponentHandler>();
			builder.Services.AddScoped<IProductAreaComponentHandler, ProductAreaComponentHandler>();
			builder.Services.AddScoped<IProductControllerHandler, ProductControllerHandler>();
			builder.Services.AddScoped<ICategoryControllerHandler, CategoryControllerHandler>();
			builder.Services.AddScoped<IApiControllerHandler, ApiControllerHandler>();
			builder.Services.AddScoped<IProductListControllerHandler, ProductListControllerHandler>();
			builder.Services.AddScoped<ICheckOutControllerHandler, CheckOutControllerHandler>();

            var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();
			//login Url þöyle olacak
			//login 
			//  /login þeklinde gelen tüm istekleri Authentication controller içerisindeki index action üzerine yönlendirir
			app.MapControllerRoute(
				name: "Register",
				pattern: "/login/",
					defaults: new { controller = "Authentication", action = "Index" });

			app.MapControllerRoute(
				name: "ProductDetail",
				pattern: "/urun/{name}",
				defaults: new { controller = "Product", action = "Index" });

			app.MapControllerRoute(
				name: "ProductList",
				pattern: "/kategori/{name}/{page?}",
				defaults: new { controller = "ProductList", action = "Index" });

			app.MapControllerRoute(
				name: "ProductList",
				pattern: "/arama/{page?}",
				defaults: new { controller = "ProductList", action = "Search" });

			app.MapControllerRoute(
				name: "Exit",
				pattern: "/exit/",
				defaults: new { controller = "Authentication", action = "Exit" });

            app.MapControllerRoute(
                name: "CheckOut",
                pattern: "/CheckOut/",
                defaults: new { controller = "CheckOut", action = "Index" });

            //app.MapControllerRoute(
            //	name: "AdminTest",
            //	pattern:"/admin/product/test",
            //             defaults: new { controller = "Product", action = "Text" });

            app.MapControllerRoute(
				name: "Admin",
				pattern: "{area:exists}/{controller}/{action}/{id?}"
			);

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}