using System;
using System.Collections.Generic;
using Xunit;

namespace VendingMachine.TestProject
{
    public class VenMachineTests
    {
        VenMachine vm = new VenMachine();
        LoadItems loadItems = new LoadItems();
        string exsistingItem = "A1";
        string nonExsistingItem = "A0";

        [Fact]
        public void ItemExistsTest()
        {
            bool exists = vm.ItemExists(exsistingItem);
            
            Assert.True(exists);
        }

        [Fact]
        public void ItemDoesNotExistTest()
        {
            bool dontExist = vm.ItemExists(nonExsistingItem);

            Assert.False(dontExist);
        }

        [Fact]
        public void PurchaseClearTest()
        {
            vm.MoneyInMachine = 10;
            bool purchaseClear = vm.Purchase(exsistingItem);

            Assert.Equal(0, vm.MoneyInMachine);
            Assert.True(purchaseClear);
        }

        [Fact]
        public void PurchaseMoneyFailsTest()
        {
            vm.MoneyInMachine = 0;
            bool purchaseClear = vm.Purchase(exsistingItem);

            Assert.Equal(0, vm.MoneyInMachine);
            Assert.False(purchaseClear);
        }

        [Fact]
        public void PurchaseItemFailsTest()
        {
            vm.MoneyInMachine = 10;
            bool purchaseClear = vm.Purchase(nonExsistingItem);

            Assert.Equal(10, vm.MoneyInMachine);
            Assert.False(purchaseClear);
        }

        [Fact]
        public void MoneyAdded()
        {
            vm.InsertMoney(10);

            Assert.Equal(10, vm.MoneyInMachine);
        }

        [Fact]
        public void MoneyNotAdded()
        {
            vm.InsertMoney(35);

            Assert.Equal(0, vm.MoneyInMachine);
        }

        [Fact]
        public void StopTransaction()
        {
            // The money denominations in order from the left 1kr 5kr 10kr 20kr 50kr 100kr 500kr 1000kr
            int[] expectedArr = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
            vm.MoneyInMachine = 1686;
            bool running = true;
            int[] change = vm.EndTransaction(out running);

            Assert.Equal(expectedArr, change);
            Assert.False(running);
        }

        [Fact]
        public void GetVendingItemTest()
        {
            Dictionary<string, VendingItem> items = loadItems.GetVendingItems();
            VendingItem item = new Chip("Dunder Chips Salted", 10, "Slated chips from swedish potato farmers");

            Assert.Equal(item.ProductName, items["A1"].ProductName);
            Assert.Equal(item.Price, items["A1"].Price);
            Assert.Equal(item.VendedMessage, items["A1"].VendedMessage);
            Assert.Equal(item.ProductInfo, items["A1"].ProductInfo);
        }
    }
}
