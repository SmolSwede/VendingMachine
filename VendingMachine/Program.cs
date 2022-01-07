using System;

namespace VendingMachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            VenMachine vm = new VenMachine();
            bool running = true;

            while (running)
            {
                Console.WriteLine("-------- Vending Machine --------\n" +
                                  $"Money Pool: {vm.MoneyInMachine}\n" +
                                  "1. Display Vending Machine Items\n" +
                                  "2. Examine a Vending Machine Item\n" +
                                  "3. Purchase\n" +
                                  "4. Insert money\n" +
                                  "E. Exit\n\n" +
                                  "Enter the number coresponding with the option you want.");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Showing Items");
                    vm.ShowAll();
                }
                else if (input == "2")
                {
                    Console.WriteLine("Enter the location of the desired item. ");
                    string itemToExamine = Console.ReadLine();

                    if(vm.ItemExists(itemToExamine) == true)
                    {
                        Console.WriteLine(vm.VendingMachineItems[itemToExamine].ProductInfo);
                    }
                    else
                    {
                        Console.WriteLine("Please check the location of the item of interest");
                    }
                }
                else if (input == "3")
                {
                    Console.WriteLine("Enter the location of the desired item. ");
                    string choice = Console.ReadLine();
                    bool succses = vm.Purchase(choice);
                    if(succses == true)
                    {
                        Console.WriteLine(vm.VendingMachineItems[choice].VendedMessage);
                    }
                    else
                    {
                        Console.WriteLine($"Please check the location or insert more money. Current amount {vm.MoneyInMachine}");
                    }
                }
                else if(input == "4")
                {
                    while (true)
                    {
                        Console.WriteLine("Enter the amount you wish to add to the money pool\n" +
                                      "| 1 | 5 | 10 | 20 | 50 | 100 | 500 | 1000 |");
                        string selectedAmount = Console.ReadLine();
                        bool isNumber = int.TryParse(selectedAmount, out int result);
                        if (isNumber == true)
                        {
                            vm.InsertMoney(result);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a corresponding number with the wanted value");
                        }
                    }
                }
                else if (input.ToString() == "E")
                {
                    if (vm.MoneyInMachine <= 0)
                    {
                        running = false;
                    }
                    else
                    {
                        int[] change = vm.EndTransaction(out running);
                        Console.WriteLine("Here is your change\n" +
                                          $"{change[0]} 1Kr\n" +
                                          $"{change[1]} 5Kr\n" +
                                          $"{change[2]} 10Kr\n" +
                                          $"{change[3]} 20Kr\n" +
                                          $"{change[4]} 50Kr\n" +
                                          $"{change[5]} 100Kr\n" +
                                          $"{change[6]} 500Kr\n" +
                                          $"{change[7]} 1000Kr");
                    }
                    Console.WriteLine("Exiting now");
                }
                else
                {
                    Console.WriteLine("Please try again");
                }

                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
