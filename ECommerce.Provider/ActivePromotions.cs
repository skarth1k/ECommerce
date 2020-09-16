using ECommerce.Contracts;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace ECommerce.Provider
{
    public class ActivePromotions
    {
        private readonly List<Promotion> promotions;

        public ActivePromotions()
        {
            promotions = new List<Promotion>
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
                },
                new ComboPromotion
                {
                    Price = 30,
                    Quantity = 1,
                    Products =  ProductHelper.GetProducts(Constants.C, Constants.D),
                    Type = PromotionType.Combo

                }
            };
        }
    }
}
