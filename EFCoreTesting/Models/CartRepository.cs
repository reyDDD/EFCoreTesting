using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public interface ICartRepository
    {
        IEnumerable<Cart> ReturnCart();
        void AddToCart(Cart cart);
    }

    public class CartRepositoryInMemory : ICartRepository
    {
        private Context connect;
        public CartRepositoryInMemory(Context connect)
        {
            this.connect = connect;
        }

        public IEnumerable<Cart> ReturnCart()
        {
            return connect.Carts;
        }

        public void AddToCart(Cart cart)
        {
            connect.Carts.Add(cart);
            connect.SaveChanges();
        }
    }
}
