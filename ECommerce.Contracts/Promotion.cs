using System.Collections.Generic;

namespace ECommerce.Contracts
{
    public class Promotion
    {
        public PromotionType Type { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class IndividualPromotion : Promotion
    {
        public Product Product { get; set; }
    }

    public class ComboPromotion : Promotion
    {
        public ComboPromotion()
        {
            Products = new List<Product>();
        }
        public List<Product> Products { get; set; }
    }
}
