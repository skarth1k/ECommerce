using ECommerce.Contracts;
using System.Collections.Generic;

namespace ECommerce.Provider
{
    public class PromotionProcessor : IPromotionProcessor
    {
        private List<IPromotionRule> promotionRules;
        public PromotionProcessor(List<IPromotionRule> promotionRules)
        {
            this.promotionRules = promotionRules;
        }

        public decimal ApplyPromotions(Context context)
        {
            foreach (var rule in promotionRules)
            {
                if (rule.IsApplicable(context))
                {
                    if (!context.IsPromotionApplied)
                    {
                        var priceAfterDiscount = rule.ApplyPromotions(context);
                        return priceAfterDiscount;
                    }
                }
            }

            return 0.0m;
        }
    }
}
