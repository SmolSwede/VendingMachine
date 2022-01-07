using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public interface IVending
    {
        // For buying a product
        bool Purchase(string choice);

        // For showing all products in the machine
        void ShowAll();

        // For adding money to the pool
        void InsertMoney(int insertedAmount);

        // For ending the transaction and returning the money left in the pool in a apropriate amount of change
        int[] EndTransaction(out bool running);
    }
}
