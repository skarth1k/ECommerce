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
            throw new System.NotImplementedException();
        }
    }
}
