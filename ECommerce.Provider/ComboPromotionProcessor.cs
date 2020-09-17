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

        public decimal ApplyPromotions(Context context)
        {
            decimal discountPrice = 0.0M, normalPricing = 0.0M, priceAfterDiscounts = 0.0M;

            for (int i = 0; i < context.CartItems.Count; i++)
            {
                var cartItem = context.CartItems[i];
                var promotionalProduct = GetPromotionalProduct(cartItem);

                if (promotionalProduct != null)
                {
                    var cartQuantity = cartItem.Quantity;

                    discountPrice = cartQuantity / promotionalProduct.Quantity;
                    normalPricing = cartQuantity % promotionalProduct.Quantity;

                    priceAfterDiscounts += (discountPrice * promotionalProduct.Price) + (normalPricing * cartItem.Item.Price);
                }
            }

            return priceAfterDiscounts;
        }

        public bool IsApplicable(Context context)
        {
            throw new NotImplementedException();
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

        private ComboPromotion GetPromotionalProduct(ProductItem productItem)
        {
            //TODO: Implement the logic to find the promotional products
            return comboPromotions[0];
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
