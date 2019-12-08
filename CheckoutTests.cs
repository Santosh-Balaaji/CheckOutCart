using NUnit.Framework;

namespace ShoppingCart_Test
{
    public class CheckoutTests
    {
        [Test]
        public void CalculateTotal_EmptyCart_Return0()
        {
            var checkout = new Checkout();
            var total = checkout.CalculateTotal();
            Assert.AreEqual(0, total);
        }
    }
}