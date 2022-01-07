using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public abstract class VendingItem
    {
        // Name of the VendingItem
        public string ProductName { get; set; }

        // Price of the VendingItem
        public int Price { get; set; }

        // What is displayed when the VendingItem is vended
        public string VendedMessage { get; set; }

        public string ProductInfo { get; set; }

        public VendingItem()
        {

        }
        public VendingItem(string productName, int price, string vendedMessage, string productInfo)
        {
            this.ProductName = productName;
            this.Price = price;
            this.VendedMessage = vendedMessage;
            this.ProductInfo = productInfo;
        }
    }
}
