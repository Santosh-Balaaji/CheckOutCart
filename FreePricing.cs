namespace ShoppingCart_Test
{
    class FreePricing:IPricingStrategy
    {
        public FreePricing(char code, int freeQuantityCount, int freePricingCount)
        {
            Code = code;
            FreeQuantityCount = freeQuantityCount;
            FreePricingCount = freePricingCount;
        }

        public char Code { get; }
        public int FreeQuantityCount { get; }
        public int FreePricingCount { get; }

        public decimal CalculatePrice(decimal unitPrice, int quantity)
        {
           return ((quantity / this.FreeQuantityCount) * unitPrice) + ((quantity % this.FreePricingCount) * unitPrice);
        }
    }
}