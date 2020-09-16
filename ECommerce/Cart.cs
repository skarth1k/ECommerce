using ECommerce.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce
{
    public class Cart
    {
        private List<ProductItem> productItems;
        private decimal totalPrice = 0.0m;
        public Cart()
        {
            productItems = new List<ProductItem>();
        }

        public void AddItem(Product product, int quantity)
        {
            productItems.Add(new ProductItem { Item = product, Quantity = quantity });
        }

        public void RemoveItem(Product product, int quantity)
        {
            productItems.Remove(new ProductItem { Item = product, Quantity = quantity });
        }        

        public decimal CalculateTotal()
        {
            foreach (var product in productItems)
            {
                totalPrice += product.Quantity * product.Item.Price;
            }

            return totalPrice;
        }

        public override string ToString()
        {
            var cartItems = new StringBuilder();

            foreach (var item in productItems)
            {
                cartItems.Append($"Product= {item.Item.Name}, Quantity= {item.Quantity}, Price= { item.Quantity * item.Item.Price} \n");
            }

            cartItems.Append($"Total Price: {totalPrice.ToString("0.00")}");

            return cartItems.ToString();
        }

        public bool Checkout(IPromotionProcessor promotionProcessor)
        {
            try
            {
                promotionProcessor.ApplyPromotions(new Context(productItems));
                return true;
            }
            catch (Exception)
            {
                //Log the exception
                return false;
            }
        }
    }
}
