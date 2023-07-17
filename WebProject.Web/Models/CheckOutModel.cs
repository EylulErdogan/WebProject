using WebProject.Entities;

namespace WebProject.Web.Models
{
    public class CheckOutModel
    {
        public IList<VwBasketProductList> BasketProducts { get; set; }
        public UserAddress UserAddress { get; set; }
        public User User { get; set; }
    }
}
