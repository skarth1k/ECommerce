using ECommerce.Contracts;
using System;
using System.Collections.Generic;

namespace ECommerce.Provider
{
    public class IndividualPromotionRule : IPromotionRule
    {
        List<IndividualPromotion> individualPromotions = new List<IndividualPromotion>
        {
            new IndividualPromotion
            {
                Price = 130,
                Quantity = 3,
                Product = ProductHelper.Get(Constants.A),
                Type = PromotionType.Individual
            },

            new IndividualPromotion
            {
                Price = 45,
                Quantity = 2,
                Product = ProductHelper.Get(Constants.B),
                Type = PromotionType.Individual
            }
        };
    }
}
