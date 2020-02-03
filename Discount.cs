namespace ShoppingCart_Test
{

    class Discount:IPricingStrategy
    {
        public int DiscountCount { get; }
        public decimal DiscountPrice { get; }
        public char Code { get; set; }

        public Discount(char code,int discountCount, decimal discountPrice)
        {
            Code = code; 
            DiscountCount = discountCount;
            DiscountPrice = discountPrice;
        }

        public decimal CalculatePrice(decimal unitPrice, int quantity)
        {
            return ((quantity % this.DiscountCount) * unitPrice) + ((quantity / this.DiscountCount) * this.DiscountPrice);
        }
    }
}
