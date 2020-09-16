using ECommerce.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ECommerce.Provider
{
    public class ComboPromotionProcessor : IPromotionRule, IPromotion
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

        public double TotalPromotions => comboPromotions.Count;

        public void Add(Promotion promotion)
        {
            if (promotion.Type != PromotionType.Combo)
                throw new InvalidOperationException("Invalid Promotion");

            var comboPromo = promotion as ComboPromotion;

            if (comboPromo != null)
            {
                bool isValidPromotion = GetIsValidPromotion(comboPromo);

                if (isValidPromotion)
                    comboPromotions.Add(comboPromo);
            }
        }

        public void Remove(Promotion promotion)
        {
            throw new NotImplementedException();
        }

        private bool GetIsValidPromotion(ComboPromotion promotion)
        {
            var result = comboPromotions
                .FirstOrDefault(i => new ComboComparer().Compare(i, promotion) == 0);

            return result == null;
        }



        class ComboComparer : IComparer<ComboPromotion>
        {
            public int Compare([AllowNull] ComboPromotion x, [AllowNull] ComboPromotion y)
            {
                if (x.Products.Count != y.Products.Count)
                    return -1;

                if (x.Products.Count == y.Products.Count && x.Quantity == y.Quantity)
                    return 0;

                return 1;
            }
        }
    }
}
