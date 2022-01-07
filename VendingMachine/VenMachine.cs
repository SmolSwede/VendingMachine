using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class VenMachine : IVending
    {
        public Dictionary<string, VendingItem> VendingMachineItems = new Dictionary<string, VendingItem>();
        public int MoneyInMachine = 0;
        readonly int[] denominationArr = new int[] { 1, 5, 10, 20, 50, 100, 500, 1000 };
        LoadItems itemLoader = new LoadItems();
        
        public VenMachine()
        {
            this.VendingMachineItems = this.itemLoader.GetVendingItems();
        }

        public bool ItemExists(string choice)
        {
            return this.VendingMachineItems.ContainsKey(choice);
        }

        public bool Purchase(string choice)
        {
            if (this.ItemExists(choice) && MoneyInMachine >= this.VendingMachineItems[choice].Price)
            {
                MoneyInMachine = MoneyInMachine - this.VendingMachineItems[choice].Price;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ShowAll()
        {
            Console.WriteLine($"\n\n{"#".PadRight(5)} {"Product".PadRight(28)} {"Price".PadLeft(7)}");
            foreach (KeyValuePair<string, VendingItem> kvp in this.VendingMachineItems)
            {
                string itemNumber = kvp.Key.PadRight(5);
                string productName = kvp.Value.ProductName.PadRight(30);
                string price = kvp.Value.Price.ToString("C").PadLeft(7);
                Console.WriteLine($"{itemNumber} {productName} Costs: {price} each");
            }

        }

        public void InsertMoney(int insertedAmount)
        {
            if(denominationArr.Contains(insertedAmount))
            {
                MoneyInMachine = MoneyInMachine + insertedAmount;
                Console.WriteLine($"Adding {insertedAmount} to money pool");
            }
            else
            {
                Console.WriteLine("Please enter a valid denomination");
            }
        }

        public int[] EndTransaction(out bool running)
        {
            int[] change = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };

            while(MoneyInMachine != 0)
            {
                if(MoneyInMachine >= denominationArr[7])
                {
                    MoneyInMachine = MoneyInMachine - denominationArr[7];
                    change[7]++;
                }
                else if(MoneyInMachine >= denominationArr[6])
                {
                    MoneyInMachine = MoneyInMachine - denominationArr[6];
                    change[6]++;
                }
                else if (MoneyInMachine >= denominationArr[5])
                {
                    MoneyInMachine = MoneyInMachine - denominationArr[5];
                    change[5]++;
                }
                else if (MoneyInMachine >= denominationArr[4])
                {
                    MoneyInMachine = MoneyInMachine - denominationArr[4];
                    change[4]++;
                }
                else if (MoneyInMachine >= denominationArr[3])
                {
                    MoneyInMachine = MoneyInMachine - denominationArr[3];
                    change[3]++;
                }
                else if (MoneyInMachine >= denominationArr[2])
                {
                    MoneyInMachine = MoneyInMachine - denominationArr[2];
                    change[2]++;
                }
                else if (MoneyInMachine >= denominationArr[1])
                {
                    MoneyInMachine = MoneyInMachine - denominationArr[1];
                    change[1]++;
                }
                else if (MoneyInMachine >= denominationArr[0])
                {
                    MoneyInMachine = MoneyInMachine - denominationArr[0];
                    change[0]++;
                }
            }
            running = false;
            return change;
        }
    }
}
