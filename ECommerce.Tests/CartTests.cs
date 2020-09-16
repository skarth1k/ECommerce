using NUnit.Framework;
using System.Collections.Generic;

namespace ECommerce.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddItemTest()
        {
            var productItems = ProductHelper.GetProducts();
            Cart cart = new Cart();
            foreach (var product in productItems)
            {
                cart.AddItem(product, quantity);
            }

            Assert.AreEqual(5, cart.TotalItems);
        }

        [Test]
        public void RemoveItemTest()
        {
            var productItems = ProductHelper.GetProducts();
            Cart cart = new Cart();
            foreach (var product in productItems)
            {
                cart.AddItem(product, quantity);
            }

            var removeProduct = new Product();
            cart.RemoveItem(removeProduct, 2);

            Assert.AreEqual(3, cart.TotalItems);
        }

        [Test]
        public void PromotionTest()
        {
            var productItems = Cart.GetItems();
            var rules = new List<IPromotionRule>();
            var promotionProcessor = new PromotionProcessor(rules, productItems);
            promotionProcessor.ApplyPromotion();


        }

    }
}