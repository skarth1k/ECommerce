using ECommerce.Contracts;
using System.Collections.Generic;

namespace ECommerce.Provider
{
    public class ComboPromotionRule : IPromotionRule
    {
        List<ComboPromotion> comboPromotions = new List<ComboPromotion>
        {
            new ComboPromotion
            {
                Price = 30,
                Quantity = 1,
                Products = ProductHelper.GetProducts(Constants.C, Constants.D),
                Type = PromotionType.Combo
            }
        };
    }
}
