using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart_Test
{
    internal class Checkout
    {
        private readonly List<Product> _inventory;
        private const decimal UnitPriceB = 30;
        private const decimal UnitPriceA = 50;
        private const decimal SpclPriceA = 130;
        private const decimal SpclPriceB = 45;
        private const decimal UnitPriceC = 20;
        private readonly IDictionary<char, Product> _product_code_dict;
        public Checkout(List<Product> Inventory)
        {
            _inventory = Inventory;
            _product_code_dict = _inventory.ToDictionary((item) => item.Code, (item) => item);
        }

        public decimal CalculateTotal(string items)
        {
            decimal totalPrice = 0;
            var numOfItemsPerCode = GetItemCount(items);
            foreach (var item in numOfItemsPerCode) {
                var productObject =_product_code_dict[item.Key];
                if (productObject.DiscountPrice != 0)
                {
                    totalPrice += ((item.Value % productObject.DiscountCount) * productObject.UnitPrice) + ((item.Value / productObject.DiscountCount) * productObject.DiscountPrice);
                } else
                {
                    totalPrice += item.Value * productObject.UnitPrice;
                }
            } 
            
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