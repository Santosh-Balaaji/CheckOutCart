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
        private List<Product> product_inventory;
        private List<Discount> Discount_inventory;
        private List<FreePricing> FreePricing_inventory;

        
        private Discount DiscountA;
        private Discount DiscountB;

        private FreePricing PricingA;
        private FreePricing PricingB;
        private FreePricing PricingC;

        
        [SetUp]
        public void BeforeEach()
        {
            product_inventory = new List<Product>();
            Discount_inventory = new List<Discount>();
            FreePricing_inventory = new List<FreePricing>();


            productA = new Product('A',50);
            DiscountA = new Discount('A', 3,130);
            PricingA = new FreePricing('A', 2, 1);
            product_inventory.Add(productA);
            Discount_inventory.Add(DiscountA);
            FreePricing_inventory.Add(PricingA);

            productB = new Product('B', 30);
            DiscountB = new Discount('B', 2,45);
            PricingB = new FreePricing('B', 3, 1);
            product_inventory.Add(productB);
            Discount_inventory.Add(DiscountB);
            FreePricing_inventory.Add(PricingB);


            
            productC = new Product('C', 20);
            PricingC = new FreePricing('C', 3, 1);
            product_inventory.Add(productC);
            FreePricing_inventory.Add(PricingC);

        }

        [Test]
        public void CalculateTotal_EmptyCart_Return0()
        {
            var productArr = new Product[10];

            var checkout = new Checkout(product_inventory,Discount_inventory,FreePricing_inventory);
            var total = checkout.CalculateTotal("");
            Assert.AreEqual(0, total);
        }

        [Test]
        public void CalculateTotal_GivenItemA_Return50()
        {
            var checkout = new Checkout(product_inventory, Discount_inventory, FreePricing_inventory);
            var total = checkout.CalculateTotal("A");
            Assert.AreEqual(50, total);
        }

        [Test]
        public void CalculateTotal_GivenItemsAB_Return80()
        {
            var checkout = new Checkout(product_inventory, Discount_inventory, FreePricing_inventory);
            var total = checkout.CalculateTotal("AB");
            Assert.AreEqual(80, total);
        }
        [Test]
        public void CalculateTotal_GivenItemsAAA_Return100()
        {
            var checkout = new Checkout(product_inventory, Discount_inventory, FreePricing_inventory);
            var total = checkout.CalculateTotal("AAA");
            Assert.AreEqual(100, total);
        }
        [Test]
        public void CalculateTotal_GivenItemsABC_Return100()
        {
            var checkout = new Checkout(product_inventory, Discount_inventory, FreePricing_inventory);
            var total = checkout.CalculateTotal("ABC");
            Assert.AreEqual(100, total);
        }
    }
}