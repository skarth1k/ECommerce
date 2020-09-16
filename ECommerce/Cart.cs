using ECommerce.Contracts;
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
           
        }

        public void RemoveItem(Product product, int quantity)
        {

        }


        public List<ProductItem> GetCartItems() 
        {
            return productItems;
        }

        public void CalculateTotal()
        {

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

    }
}
