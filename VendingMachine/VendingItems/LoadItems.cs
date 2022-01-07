using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public class LoadItems
    {
        private List<string> itemList = new List<string> 
        {
            "A1|Dunder Chips Salted|10|Slated chips from swedish potato farmers|Chip",
            "A2|Dunder Chips Dill|12|Dill flavored chips from swedish potato farmers|Chip",
            "A3|Dunder Chips Grill|16|Grill flavored chips from swedish potato farmers|Chip",
            "B1|Bepsi Cola|5|Bepsi Cola a soda from the US of A|Drink",
            "B2|Bingo Orange|8|Bingo Orange a orage flavored frome the cold refreshing north|Drink",
            "B3|Bonster Ultra|20|Unleash the inner beast but without sugar|Drink",
            "C1|WarHammer 40K Figurine|135|A figurine of a space marine from the WarHammer 40K universe|Toy",
            "C2|WarHammer Fantasy Figurine|79|A figurine of a scaven assassin from the WarHammer Fantasy universe|Toy",
            "C3|Stur Wurs Plushy|30|A plushy of the beloved Jar-Jar|Toy"
        };

        private const int Pos_itemNumber = 0;
        private const int Pos_ItemName = 1;
        private const int Pos_ItemPrice = 2;
        private const int Pos_ItemInfo = 3;
        private const int Pos_itemType = 4;

        public Dictionary<string, VendingItem> GetVendingItems()
        {
            Dictionary<string, VendingItem> items = new Dictionary<string, VendingItem>();

            for(int i = 0; i < itemList.Count; i++)
            {
                string itemToSplit = itemList[i].ToString();

                string[] itemDetails = itemToSplit.Split("|");

                string itemName = itemDetails[Pos_ItemName];

                if (!int.TryParse(itemDetails[Pos_ItemPrice], out int itemPrice))
                {
                    itemPrice = 0;
                }

                string itemInfo = itemDetails[Pos_ItemInfo];

                VendingItem item;

                switch (itemDetails[Pos_itemType])
                {
                    case "Chip":
                        item = new Chip(itemName, itemPrice, itemInfo);
                        break;
                    case "Drink":
                        item = new Drinks(itemName, itemPrice, itemInfo);
                        break;
                    case "Toy":
                        item = new Toys(itemName, itemPrice, itemInfo);
                        break;
                    default:
                        item = new Chip(itemName, itemPrice, itemInfo);
                        break;
                }

                items.Add(itemDetails[Pos_itemNumber], item);
            }

            return items;
        }
        
    }
}
