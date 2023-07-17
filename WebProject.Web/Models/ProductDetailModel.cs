using WebProject.Entities;

namespace WebProject.Web.Models
{
    public class ProductDetailModel
    {
        private Product Product { get; set; }
        IList<ProductImage> Images { get; set; }
    }
}
