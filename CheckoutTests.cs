using NUnit.Framework;

namespace ShoppingCart_Test
{
    [TestFixture]
    public class CheckoutTests
    {
        [Test]
        public void CalculateTotal_EmptyCart_Return0()
        {
            var checkout = new Checkout("");
            var total = checkout.CalculateTotal();
            Assert.AreEqual(0, total);
        }

        [Test]
        public void CalculateTotal_GivenItemA_Return50()
        {
            var checkout = new Checkout("A");
            var total = checkout.CalculateTotal();
            Assert.AreEqual(50, total);
        }

        [Test]
        public void CalculateTotal_GivenItemsAB_Return80()
        {
            var checkout = new Checkout("AB");
            var total = checkout.CalculateTotal();
            Assert.AreEqual(80, total);
        }
        [Test]
        public void CalculateTotal_GivenItemsAAA_Return130()
        {
            var checkout = new Checkout("AAA");
            var total = checkout.CalculateTotal();
            Assert.AreEqual(130, total);
        }
    }
}