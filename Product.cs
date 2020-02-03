namespace ShoppingCart_Test
{
    internal class Product: IPricingStrategy
    {
        public Product(char code, decimal unitPrice)
        {
            Code = code;
            UnitPrice = unitPrice;
        }
        public char Code { get; }
        public decimal UnitPrice { get; }

        public decimal CalculatePrice(decimal unitPrice, int quantity)
        {
            return (unitPrice * quantity);
        }
    }
}