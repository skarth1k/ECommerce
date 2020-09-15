using NUnit.Framework;

namespace ECommerce.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CartTest()
        {
            Cart cart = new Cart();
            cart.Checkout();
        }
    }
}