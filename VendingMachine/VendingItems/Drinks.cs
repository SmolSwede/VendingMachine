using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public class Drinks : VendingItem
    {
        public const string Message = "I consume the drink";

        public Drinks(string productName, int price, string productInfo) : base(productName, price, Message, productInfo)
        {
        }
    }
}
