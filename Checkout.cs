using System.Collections.Generic;

namespace ShoppingCart_Test
{
    internal class Checkout
    {
        private readonly string _items;       
        private const decimal UnitPriceB = 30;
        private const decimal UnitPriceA = 50;
        private const decimal SpclPriceA = 130;
        private const decimal SpclPriceB = 45;
        public Checkout(string items)
        {
            _items = items;
        }

        public decimal CalculateTotal()
        {
            decimal totalPrice = 0;
            var cart = GetItemCount(_items);
            
            foreach(var item in cart){
                if (item.Key == 'A')
                {
                    totalPrice += ((item.Value % 3) * UnitPriceA) + ((item.Value / 3) * SpclPriceA);
                }
                else if (item.Key == 'B') {
                    totalPrice += ((item.Value % 2) * UnitPriceB) + ((item.Value / 2) * SpclPriceB);
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
    }
}