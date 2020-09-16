using ECommerce.Contracts;
using System.Collections.Generic;

namespace ECommerce.Provider
{
    public class PromotionProcessor
    {
        private List<IPromotionRule> promotionRules;
        public PromotionProcessor(List<IPromotionRule> promotionRules)
        {
            this.promotionRules = promotionRules;
        }
    }
}
