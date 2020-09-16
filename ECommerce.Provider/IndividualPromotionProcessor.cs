using ECommerce.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Provider
{
    public class IndividualPromotionProcessor : IPromotionRule, IPromotion
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

        public double TotalPromotions => individualPromotions.Count;

        public void Add(Promotion promotion)
        {
            if (promotion.Type != PromotionType.Individual)
                throw new InvalidOperationException("Invalid Promotion");

            var individualPromo = promotion as IndividualPromotion;

            if (individualPromo != null)
            {
                bool isValidPromotion = GetIsValidPromotion(individualPromo);

                if (isValidPromotion)
                    individualPromotions.Add(individualPromo);
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
            for (int i = 0; i < context.CartItems.Count; i++)
            {
                var cartItem = context.CartItems[i];
                var promotionalProduct = GetPromotionalProduct(cartItem);
                if (promotionalProduct != null)
                {
                    if (cartItem.Quantity >= promotionalProduct.Quantity)
                        return true;
                    return false;
                }
            }

            return false;
        }

        public void Remove(Promotion promotion)
        {
            if (promotion.Type != PromotionType.Individual)
                throw new InvalidOperationException("Invalid Promotion");

            var individualPromo = promotion as IndividualPromotion;

            if (individualPromo != null)
            {
                bool isValidPromotion = GetIsValidPromotion(individualPromo);

                if (!isValidPromotion)
                {
                    individualPromotions.Remove(individualPromo);
                }
            }
        }

        private bool GetIsValidPromotion(IndividualPromotion promotion)
        {
            return individualPromotions
                .Where(i => i.Product == promotion.Product && i.Quantity == promotion.Quantity)
                .FirstOrDefault() == null;
        }

        private IndividualPromotion GetPromotionalProduct(ProductItem productItem)
        {
            return individualPromotions.FirstOrDefault(p => p.Product == productItem.Item);
        }
    }
}
