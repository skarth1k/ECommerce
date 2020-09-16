using System;

namespace ECommerce.Contracts
{
    public interface IPromotionRule
    {
        bool IsApplicable(Context context);

        decimal ApplyPromotions(Context context);
    }
}
