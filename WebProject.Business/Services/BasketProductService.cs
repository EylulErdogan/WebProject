using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.Abstract;
using WebProject.Entities;

namespace WebProject.Business.Services
{
    public class BasketProductService : IBasketProductService
    {
        private IBasketProductDal _basketProductDal;
        private IVwBasketProductListDal _vwBasketProductListDal;

        public BasketProductService(IBasketProductDal basketProductDal, IVwBasketProductListDal vwBasketProductListDal)
        {
            _basketProductDal = basketProductDal;
            _vwBasketProductListDal = vwBasketProductListDal;
        }

        public void Add(int productId, int quantity, string guidKey)
        {
            var parsed = Guid.Parse(guidKey);
            var checkProduct = _basketProductDal.Get(x =>
                 x.ProductId == productId && x.Status != false && x.BasketId == parsed);
            if (checkProduct != null)
            {
                checkProduct.Quantity += quantity;
                _basketProductDal.Update(checkProduct);
                return;
            }
            BasketProduct product = new BasketProduct();
            product.ProductId = productId;
            product.Quantity = quantity;
            product.BasketId = Guid.Parse(guidKey);
            product.AddDate = DateTime.Now;

            _basketProductDal.Add(product);
        }        
        public void Remove(int productId, string guidKey)
        {
            var parsed = Guid.Parse(guidKey);
            var checkProduct = _basketProductDal.Get(x =>
                 x.ProductId == productId && x.Status != false && x.BasketId == parsed);
            if (checkProduct != null)
            {
                _basketProductDal.Delete(checkProduct);
                return;
            }
        }

        public IList<BasketProduct> List(string guidKey)
        {
            var parsed = Guid.Parse(guidKey);
            return _basketProductDal.GetAll(x => x.BasketId == parsed && x.Status != false);
        }

        public IList<VwBasketProductList> VwBasketProductList(string guidKey)
        {
            var parsed = Guid.Parse(guidKey);
            var data=_vwBasketProductListDal.GetAll(x => x.BasketId == parsed && x.Status != false);
            return data;
        }
    }

    public interface IBasketProductService
    {
        void Add(int productId, int quantity, string guidKey);
        void Remove(int productId, string guidKey);

        IList<BasketProduct> List(string guidkey);
        IList<VwBasketProductList> VwBasketProductList(string guidKey);
    }
}
