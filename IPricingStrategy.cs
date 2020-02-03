using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart_Test
{
    public interface IPricingStrategy
    {
        public decimal CalculatePrice(decimal unitPrice, int quantity);
    }
}
