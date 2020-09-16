namespace ECommerce.Contracts
{
    public interface IPromotion
    {
        double TotalPromotions { get; }

        void Add(Promotion promotion);
        void Remove(Promotion promotion);
    }
}
