using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public class Toys : VendingItem
    {
        public const string Message = "I play with the toy";

        public Toys(string productName, int price, string productInfo) : base(productName, price, Message, productInfo)
        {
        }
    }
}
