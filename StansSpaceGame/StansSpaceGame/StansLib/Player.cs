using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StansLib
{
    public class Player
    {
        public Player()
        {
            bool keepLooping = true;
            // enter Name
            do
            {
                try
                {
                    Console.Write("\nPlease enter your name\n\n>>> ");
                    string input = Console.ReadLine().Trim();
                    if (input != "")
                    {
                        this.name = input;
                        keepLooping = false;
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        throw new Exception("\nInvalid Entry");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (keepLooping);


            this.location = new Planet("Earth");
            // give starting credits to the player
            this.credits = 3000;

            Console.WriteLine($"\nHello {this.GetName()}. Your character has been created and awarded with enough money to start you off.");
            Console.WriteLine("\nPress Enter to Continue");
            Console.ReadLine();
            Console.Clear();
            // prompt the user to purchase a ship
            this.ship = newShip(true);
            Console.Clear();
            // Updates user's wallet.
            SetCredits(-ship.GetPrice());
            Console.Clear();
        }

        private string name;
        private Planet location;
        private int credits;
        private List<Items> Cargo = new List<Items>();
        private Ship ship;


        // Methods relying on character creation.
        public string GetName() => this.name;
        public void SetName(string name) => this.name = name;

        public Planet GetLocation() => this.location;
        public void SetLocation(Planet location) => this.location = location;

        public int GetCredits() => this.credits;
        public void SetCredits(int credits) => this.credits += credits;

        public List<Items> GetCargo() => this.Cargo;
        public int GetCargoCount() => this.Cargo.Count();
        public void AddCargo(Items cargo) => this.Cargo.Add(cargo);
        public void RemoveCargo(Items cargo) => this.Cargo.Remove(cargo);
        public Ship GetShip() => this.ship;
        public void Multiplier(Player player) => this.credits += 2;

        // Displays information about user and Planet
        public void ShowStatus()
        {
            Console.WriteLine($"\nwallet: {GetCredits()}\nlocation: {GetLocation().GetName()}");
        }

        // Buy goods
        public void BuyGoods(string buyMenu, Items[] tradingGoods)
        {
            bool keepLooping = true;
            do
            {
                try
                {
                    if (GetCargo().Count() != GetShip().GetCargoCapacity())
                    {
                        Console.Write(buyMenu);
                        MenuSelection selection = new MenuSelection(Console.ReadLine().Trim());
                        if (selection.GetSelection() == 0)
                        {
                            break;
                        }
                        else if (Enumerable.Range(1, 10).Contains(selection.GetSelection()))
                        {
                            Console.Write("\nHow many units would you like to buy?\n\nC: Cancel\n\n>>> ");
                            MenuSelection quantity = new MenuSelection(Console.ReadLine().Trim());
                            // Checks if the user can carry anymore cargo.
                            if (quantity.GetSelection() == 0)
                            {
                                break;
                            }
                            else if (GetCargo().Count() + quantity.GetSelection() <= GetShip().GetCargoCapacity())
                            {
                                if (GetCredits() >= quantity.GetSelection() * tradingGoods[selection.GetSelection() - 1].GetPrice())
                                {
                                    // Adds an item to the player's cargo
                                    for (int i = 0; i < quantity.GetSelection(); i++)
                                    {
                                        AddCargo(tradingGoods[selection.GetSelection() - 1]);
                                    }

                                    keepLooping = false;
                                }
                                else
                                {
                                    throw new Exception("\nYou don't have enough credit to purchase this good.");
                                }
                            }
                            else
                            {
                                throw new Exception("\nThere isn't enough room in the ship's cargo bay for the selected quantity. Select fewer items.");
                            }
                        }
                        else
                        {
                            throw new Exception("\nInvalid Entry");
                        }
                    }
                    else
                    {
                        keepLooping = false;
                        throw new Exception("\nThe ship's cargo bay is full. Sell some goods before you attempt to purchase more.");
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            } while (keepLooping);
        }

        // Sell goods
        public void SellGoods(string sellMenu, Items[] tradingGoods)
        {
            bool keepLooping = true;
            do
            {
                try
                {
                    Console.Write(sellMenu);
                    MenuSelection selection = new MenuSelection(Console.ReadLine().Trim());
                    if (selection.GetSelection() == 0)
                    {
                        break;
                    }
                    else if (Enumerable.Range(1, 10).Contains(selection.GetSelection()))
                    {
                        // Counts how many of selected items does the user have in his cargo
                        int count = 0;
                        foreach (Items items in GetCargo())
                        {
                            if (items.GetName() == tradingGoods[selection.GetSelection() - 1].GetName())
                            {
                                count++;
                            }
                        }
                        if (count > 0)
                        {
                            Console.Write("\nHow many units would you like to sell?\n\nC: Cancel\n\n>>> ");
                            MenuSelection quantity = new MenuSelection(Console.ReadLine().Trim());
                            if (quantity.GetSelection() == 0)
                            {
                                break;
                            }
                            if (quantity.GetSelection() <= count)
                            {
                                // removes the sold item from the user's cargo
                                for (int i = 0; i < quantity.GetSelection(); i++)
                                {
                                    RemoveCargo(tradingGoods[selection.GetSelection() - 1]);
                                }
                                keepLooping = false;
                            }
                            else
                            {
                                int number = 0;
                                foreach (Items items in GetCargo())
                                {
                                    if (items.GetName() == tradingGoods[selection.GetSelection() - 1].GetName())
                                        number++;
                                }
                                throw new Exception($"\nYou have only {number} {tradingGoods[selection.GetSelection() - 1].GetName()} in your cargo bay.");
                            }
                        }
                        else
                        {
                            keepLooping = false;
                            throw new Exception("\nYou don't have any of the selected goods in the cargo bay.");
                        }
                    }
                    else
                    {
                        throw new Exception("\nInvalid Entry");
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            } while (keepLooping);
        }

        // Purchase a ship
        public Ship newShip(bool keepLooping)
        {
            string model = "";
            do
            {
                try
                {
                    Console.WriteLine($"\nWallet: {this.GetCredits()} credits");

                    string[] modelNames = { "Collosus", "SpitFire" };
                    Console.Write($"\nSelect the type of ship you want to purchase, {this.name}:\n" +
                        $"\n1. {modelNames[0]}\t1000 credits" +
                        $"\n2. {modelNames[1]}\t\t2000 credits\n\nC: Cancel\n\n>>> ");
                    MenuSelection selection = new MenuSelection(Console.ReadLine().Trim());
                    if (selection.GetSelection() == 0)
                    {
                        break;
                    }
                    else if (Enumerable.Range(1, 4).Contains(selection.GetSelection()))
                    {
                        model = modelNames[selection.GetSelection() - 1];
                        Ship newShip = new Ship(model);
                        if (this.GetCredits() >= newShip.GetPrice())
                        {
                            keepLooping = false;
                        }
                        else
                        {
                            Console.Clear();
                            throw new Exception("\nYou don't have enough credits to purchase the selected model.");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        throw new Exception("\nInvalid Entry");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (keepLooping);
            return new Ship(model);
        }
    }
}

