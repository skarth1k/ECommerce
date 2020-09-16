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

            return 0.0m;
        }

        public bool IsApplicable(Context context)
        {
            var cartItem = context.CartItems[0];
            var promotionalProduct = individualPromotions.FirstOrDefault(ip => ip.Product == cartItem.Item);
            if (promotionalProduct != null)
            {
                if (cartItem.Quantity >= promotionalProduct.Quantity)
                    return true;
                return false;
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

                if(!isValidPromotion)
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
    }
}
