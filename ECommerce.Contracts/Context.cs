using System.Collections.Generic;

namespace ECommerce.Contracts
{
    public class Context
    {
        public bool IsPromotionApplied { get; set; }
        public List<ProductItem> CartItems { get; set; }

        public Context(List<ProductItem> cartItems)
        {
            CartItems = cartItems;
        }
    }
}