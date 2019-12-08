using NUnit.Framework;

namespace ShoppingCart_Test
{
    public class CheckoutTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculateTotal_EmptyCart_Return0()
        {
            var checkout = new Checkout();
            decimal total = checkout.CalculateTotal();
            Assert.AreEqual(0, total);
        }
    }
}