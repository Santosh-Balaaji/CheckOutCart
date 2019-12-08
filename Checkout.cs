namespace ShoppingCart_Test
{
    internal class Checkout
    {
        private readonly string _items;
        private const decimal PriceA = 50;

        public Checkout(string items)
        {
            _items = items;
        }

        public decimal CalculateTotal()
        {
            if (_items == "A")
                return PriceA;

            return 0;   
        }
    }
}