using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart_Test
{
    internal class Checkout
    {
        private readonly List<Product> _productInventory;
        private readonly List<Discount> _discountInventory;
        private readonly List<FreePricing> _freepricingInventory;

        private readonly IDictionary<char, Product> _product_code_dict;

        public Checkout(List<Product> product_Inventory, List<Discount> discount_Inventory, List<FreePricing> freePricing_inventory )
        {
            _productInventory = product_Inventory;
            _discountInventory = discount_Inventory;
            _freepricingInventory = freePricing_inventory;
            _product_code_dict = _productInventory.ToDictionary((item) => item.Code, (item) => item);
        }

        public decimal CalculateTotal(string items)
        {
           decimal totalPrice = 0;
            decimal discountPrice = 0;
            decimal freePrice = 0;
           var numOfItemsPerCode = GetItemCount(items);           
           foreach (var item in numOfItemsPerCode)
            {
                var product = _product_code_dict[item.Key];
                var itemDiscount = _discountInventory.FirstOrDefault(dis => dis.Code == item.Key);
                if (itemDiscount != null)
                {
                    discountPrice += itemDiscount.CalculatePrice(product.UnitPrice, numOfItemsPerCode[product.Code]);
                } else
                {
                    discountPrice += product.CalculatePrice(product.UnitPrice, numOfItemsPerCode[product.Code]);
                }
                var itemFree = _freepricingInventory.FirstOrDefault(dis => dis.Code == item.Key);
                if (itemFree != null)
                {
                    freePrice += itemFree.CalculatePrice(product.UnitPrice, numOfItemsPerCode[product.Code]);
                }
                else
                    freePrice += product.CalculatePrice(product.UnitPrice, numOfItemsPerCode[product.Code]);
            }
            totalPrice =Math.Min(discountPrice, freePrice);
            return totalPrice;   
        }

        public IDictionary<char, int> GetItemCount(string itemString)
        {
            var cart = new Dictionary<char, int>();
            char[] items = itemString.ToCharArray();
            foreach (var item in items)
            {
                if (cart.ContainsKey(item))
                {
                    cart[item] = cart[item] + 1;
                }
                else
                    cart.Add(item, 1);
            }
            return cart;
        }

        public IDictionary<char, Product> ReturnProductCodeToProductDict(List<Product> inventory)
        {
            var product_code_dict = new Dictionary<char, Product>();
            foreach (var prodcut in inventory)
            {
                product_code_dict.Add(prodcut.Code, prodcut);
            }
            return product_code_dict;
        }

    }
}