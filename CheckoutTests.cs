using NUnit.Framework;
using System.Collections.Generic;

namespace ShoppingCart_Test
{
    [TestFixture]
    public class CheckoutTests
    {
        private Product productA;
        private Product productB;
        private Product productC;
        private List<Product> inventory;

        [SetUp]
        public void BeforeEach()
        {
            productA = new Product('A', 50, 3, 130);
            productB = new Product('B', 30, 2, 45);
            productC = new Product('C', 20, 0, 0);
            inventory = new List<Product>();
            inventory.Add(productA);
            inventory.Add(productB);
            inventory.Add(productC);
        }

        [Test]
        public void CalculateTotal_EmptyCart_Return0()
        {
            var productArr = new Product[10];

            var checkout = new Checkout(inventory);
            var total = checkout.CalculateTotal("");
            Assert.AreEqual(0, total);
        }

        [Test]
        public void CalculateTotal_GivenItemA_Return50()
        {
            var checkout = new Checkout(inventory);
            var total = checkout.CalculateTotal("A");
            Assert.AreEqual(50, total);
        }

        [Test]
        public void CalculateTotal_GivenItemsAB_Return80()
        {
            var checkout = new Checkout(inventory);
            var total = checkout.CalculateTotal("AB");
            Assert.AreEqual(80, total);
        }
        [Test]
        public void CalculateTotal_GivenItemsAAA_Return130()
        {
            var checkout = new Checkout(inventory);
            var total = checkout.CalculateTotal("AAA");
            Assert.AreEqual(130, total);
        }
        [Test]
        public void CalculateTotal_GivenItemsABC_Return100()
        {
            var checkout = new Checkout(inventory);
            var total = checkout.CalculateTotal("ABC");
            Assert.AreEqual(100, total);
        }
    }
}