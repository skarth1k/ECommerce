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

        public void ApplyPromotions(Context context)
        {
            if (!context.IsPromotionApplied)
            {
                foreach (var rule in promotionRules)
                {
                    if (rule.IsApplicable(context))
                    {
                        rule.ApplyPromotions(context);
                    }
                }
            }
        }
    }
}
