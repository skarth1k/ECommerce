using ECommerce.Contracts;
using ECommerce.Provider;
using NUnit.Framework;
using System;
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
        public void Create_IndividualPromotion_Test()
        {
            IPromotion createPromotion = new IndividualPromotionProcessor();
            createPromotion.Add(new IndividualPromotion
            {
                Price = 180,
                Quantity = 5,
                Type = PromotionType.Individual,
                Product = ProductHelper.Get(Constants.A)
            });

            Assert.AreEqual(3, createPromotion.TotalPromotions);
        }

        [Test]
        public void Create_IndividualPromotion_InvalidTest()
        {
            IPromotion createPromotion = new IndividualPromotionProcessor();

            Assert.Throws<InvalidOperationException>(() => createPromotion.Add(new IndividualPromotion
            {
                Price = 180,
                Quantity = 5,
                Type = PromotionType.Combo,
                Product = ProductHelper.Get(Constants.A)
            }));
        }


        [Test]
        public void Create_ComboPromotion_Test()
        {
            IPromotion createPromotion = new ComboPromotionProcessor();
            createPromotion.Add(new ComboPromotion
            {
                Price = 80,
                Quantity = 2,
                Type = PromotionType.Combo,
                Products = ProductHelper.GetProducts(Constants.A, Constants.B, Constants.C)
            });

            Assert.AreEqual(2, createPromotion.TotalPromotions);
        }

        [Test]
        public void Create_ComboPromotion_InvalidTest()
        {
            IPromotion createPromotion = new ComboPromotionProcessor();

            Assert.Throws<InvalidOperationException>(() => createPromotion.Add(new ComboPromotion
            {
                Price = 80,
                Quantity = 2,
                Type = PromotionType.Individual,
                Products = ProductHelper.GetProducts(Constants.A, Constants.B, Constants.C)
            }));
        }

        [Test]
        public void Cart_3Items_Test()
        {
            var cart = new Cart();
            cart.AddItem(ProductHelper.Get(Constants.A), 1);
            cart.AddItem(ProductHelper.Get(Constants.B), 1);
            cart.AddItem(ProductHelper.Get(Constants.C), 1);
            var totalPrice = cart.CartTotalPrice();
            Assert.AreEqual(100, totalPrice);
            Assert.AreEqual(3, cart.TotalProducts);
        }

        [Test]
        public void Cart_4Items_Test()
        {
            var cart = new Cart();
            cart.AddItem(ProductHelper.Get(Constants.A), 1);
            cart.AddItem(ProductHelper.Get(Constants.B), 1);
            cart.AddItem(ProductHelper.Get(Constants.C), 1);
            cart.AddItem(ProductHelper.Get(Constants.D), 1);
            var totalPrice = cart.CartTotalPrice();
            Assert.AreEqual(115, totalPrice);
            Assert.AreEqual(4, cart.TotalProducts);
        }

        [Test]
        public void Cart_2Items_Test()
        {
            var cart = new Cart();
            cart.AddItem(ProductHelper.Get(Constants.A), 1);
            cart.AddItem(ProductHelper.Get(Constants.B), 1);
            var totalPrice = cart.CartTotalPrice();
            Assert.AreEqual(80, totalPrice);
            Assert.AreEqual(2, cart.TotalProducts);
        }

        [Test]
        public void Cart_1Item_Test()
        {
            var cart = new Cart();
            cart.AddItem(ProductHelper.Get(Constants.A), 1);
            var totalPrice = cart.CartTotalPrice();
            Assert.AreEqual(50, totalPrice);
            Assert.AreEqual(1, cart.TotalProducts);
        }

        [Test]
        public void Cart_1Item_2Quantity_Test()
        {
            var cart = new Cart();
            cart.AddItem(ProductHelper.Get(Constants.A), 2);
            var totalPrice = cart.CartTotalPrice();
            Assert.AreEqual(100, totalPrice);
            Assert.AreEqual(1, cart.TotalProducts);
        }

        [Test]
        public void Cart_2Item_2Quantity_Test()
        {
            var cart = new Cart();
            cart.AddItem(ProductHelper.Get(Constants.A), 2);
            cart.AddItem(ProductHelper.Get(Constants.B), 2);
            var totalPrice = cart.CartTotalPrice();
            Assert.AreEqual(160, totalPrice);
            Assert.AreEqual(2, cart.TotalProducts);
        }

        [Test]
        public void Cart_IndividualPromotion_Test()
        {
            var cart = new Cart();
            cart.AddItem(ProductHelper.Get(Constants.A), 5);

            var rules = new List<IPromotionRule>
            {
                new IndividualPromotionProcessor()
            };

            var totalPrice = cart.CartTotalPrice();
            Assert.AreEqual(250, totalPrice);
            Assert.AreEqual(1, cart.TotalProducts);

            var discountedPrice = cart.Checkout(new PromotionProcessor(rules));
            Assert.AreEqual(230, discountedPrice);
        }
    }
}