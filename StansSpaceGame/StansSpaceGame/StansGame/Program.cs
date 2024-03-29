﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StansLib;

namespace StansGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setting the conolse text color to green
            Console.ForegroundColor = ConsoleColor.DarkRed;

            // Creating trading goods and trade menus
            Items[] tradingGoods = Utilities.CreateTradingItems();
            string[] TradeMenu = Utilities.CreateTradeMenus(tradingGoods);

            Console.WriteLine("\nWelcome to Paragon");

            // Creating a new user.
            Player myPlayer = new Player();
            Console.Clear();

            // Opens action menu. This is where the game runs.
            ShowActionMenu(myPlayer, tradingGoods, TradeMenu);
        }

        // Action menu
        private static void ShowActionMenu(Player myPlayer, Items[] tradingGoods, string[] TradeMenu)
        {
            bool keepLooping = true;
            do
            {
                bool commandNotExecuted = true;
                do
                {
                    try
                    {
                        Console.Write("\nSelect from the following options:\n\n1. UserStats\n2. Store\n3. Travel\n4. Quit game\n\n>>> ");
                        MenuSelection selection = new MenuSelection(Console.ReadLine().Trim());
                        if (Enumerable.Range(1, 5).Contains(selection.GetSelection()))
                        {
                            switch (selection.GetSelection())
                            {
                                case 1:
                                    myPlayer.ShowStatus();
                                    break;
                                case 2:
                                    Console.Clear();
                                    Trade(tradingGoods, myPlayer, TradeMenu);
                                    break;
                                case 3:
                                    myPlayer.newShip(true);
                                    break;
                                case 4:
                                    Console.WriteLine("You chose to end the game.\n");
                                    Utilities.EndGameReport(myPlayer);
                                    keepLooping = false;
                                    break;
                            }
                            commandNotExecuted = false;
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
                } while (commandNotExecuted);
                Console.WriteLine("\nCommand successfully executed. Press Enter to Continue.");
                Console.ReadLine();
                Console.Clear();
            } while (keepLooping);
        }

        // Executes the trading decisions
        private static void Trade(Items[] tradingGoods, Player myPlayer, string[] TradeMenu)
        {
            string buyMenu = TradeMenu[0];
            string sellMenu = TradeMenu[1];
            bool keepLooping = true;
            do
            {
                Console.Write("\nSelect from the following options:\n\n1. buy\n2. sell\n\nC: Cancel\n\n>>> ");
                MenuSelection selection = new MenuSelection(Console.ReadLine().Trim());
                try
                {
                    if (selection.GetSelection() == 0)
                    {
                        break;
                    }
                    else if (selection.GetSelection() == 1)
                    {
                        myPlayer.BuyGoods(buyMenu, tradingGoods);
                    }
                    else if (selection.GetSelection() == 2)
                    {
                        myPlayer.SellGoods(sellMenu, tradingGoods);
                    }
                    else
                    {
                        throw new Exception("\nInvalid Entry");
                    }
                    keepLooping = false;
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            } while (keepLooping);
        }
    }
}
