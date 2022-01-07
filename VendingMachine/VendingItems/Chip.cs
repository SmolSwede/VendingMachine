using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public class Chip : VendingItem
    {
        public const string Message = "I'll take a potato chip and eat it";

        public Chip(string productName, int price, string productInfo) : base(productName, price, Message, productInfo)
        {
        }
    }
}
