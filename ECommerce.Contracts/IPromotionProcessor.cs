namespace ECommerce.Contracts
{
    public interface IPromotionProcessor
    {
        decimal ApplyPromotions(Context context);
    }
}
