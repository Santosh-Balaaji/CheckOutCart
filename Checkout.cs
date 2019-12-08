namespace ShoppingCart_Test
{
    internal class Checkout
    {
        private readonly string _items;
        private const decimal UnitPriceB = 30;
        private const decimal UnitPriceA = 50;

        public Checkout(string items)
        {
            _items = items;
        }

        public decimal CalculateTotal()
        {
            decimal total = 0;
            char[] item_arr = _items.ToCharArray();
            foreach (var item in item_arr)
            {
                if (item == 'A')
                    total += UnitPriceA;
                else if (item == 'B')
                    total += UnitPriceB;
            }
            return total;   
        }
    }
}