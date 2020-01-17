namespace ShoppingCart_Test
{
    internal class Product
    {
        public Product(char code, decimal unitPrice, int discountCount, decimal discountPrice)
        {
            Code = code;
            UnitPrice = unitPrice;
            DiscountCount = discountCount;
            DiscountPrice = discountPrice;
        }

        public char Code { get; }
        public decimal UnitPrice { get; }
        public int DiscountCount { get; }
        public decimal DiscountPrice { get; }
    }
}