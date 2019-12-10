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
            int count_A = 0, count_B=0;
            char[] item_arr = _items.ToCharArray();
            foreach (var item in item_arr)
            {
                if (item == 'A')
                { 
                    count_A += 1;
                }
                else if (item == 'B')
                    count_B +=1;
            }
            decimal total_priceA = ((count_A % 3) * UnitPriceA) + ((count_A / 3) * SpclPriceA)+ ((count_B % 2) * UnitPriceB) + ((count_B / 2) * SpclPriceB);
            
            return total_priceA;   
        }
    }
}