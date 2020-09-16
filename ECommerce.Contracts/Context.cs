using System.Collections.Generic;

namespace ECommerce.Contracts
{
    public class Context
    {
        bool IsPromotionApplied { get; set; }
        List<ProductItem> CartItems { get; set; }

        public Context(List<ProductItem> cartItems)
        {
            CartItems = cartItems;
        }
    }
}