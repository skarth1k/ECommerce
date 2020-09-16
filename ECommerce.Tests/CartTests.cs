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
        public void CreateIndividualPromotionTest()
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
        public void CreateIndividualPromotion_InvalidTest()
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
        public void CreateComboPromotionTest()
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
        public void CreateComboPromotion_InvalidTest()
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
        public void Cart3ItemsTest()
        {
            var cart = new Cart();
            cart.AddItem(ProductHelper.Get(Constants.A), 1);
            cart.AddItem(ProductHelper.Get(Constants.B), 1);
            cart.AddItem(ProductHelper.Get(Constants.C), 1);
            var totalPrice = cart.CalculateTotal();
            Assert.AreEqual(100, totalPrice);          
        }

        [Test]
        public void Cart4ItemsTest()
        {
            var cart = new Cart();
            cart.AddItem(ProductHelper.Get(Constants.A), 1);
            cart.AddItem(ProductHelper.Get(Constants.B), 1);
            cart.AddItem(ProductHelper.Get(Constants.C), 1);
            cart.AddItem(ProductHelper.Get(Constants.D), 1);
            var totalPrice = cart.CalculateTotal();
            Assert.AreEqual(115, totalPrice);
        }

        [Test]
        public void Cart2ItemsTest()
        {
            var cart = new Cart();
            cart.AddItem(ProductHelper.Get(Constants.A), 1);
            cart.AddItem(ProductHelper.Get(Constants.B), 1);            
            var totalPrice = cart.CalculateTotal();
            Assert.AreEqual(80, totalPrice);
        }

        [Test]
        public void Cart1ItemTest()
        {
            var cart = new Cart();
            cart.AddItem(ProductHelper.Get(Constants.A), 1);            
            var totalPrice = cart.CalculateTotal();
            Assert.AreEqual(50, totalPrice);
        }

        [Test]
        public void Cart1Item2QuantityTest()
        {
            var cart = new Cart();
            cart.AddItem(ProductHelper.Get(Constants.A), 2);
            var totalPrice = cart.CalculateTotal();
            Assert.AreEqual(100, totalPrice);
        }

        [Test]
        public void Cart2Item2QuantityTest()
        {
            var cart = new Cart();
            cart.AddItem(ProductHelper.Get(Constants.A), 2);
            cart.AddItem(ProductHelper.Get(Constants.B), 2);
            var totalPrice = cart.CalculateTotal();
            Assert.AreEqual(160, totalPrice);
        }
    }
}