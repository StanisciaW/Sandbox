using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StansLib
{
    public class Utilities
    {

        // Generates trading Items
        public static Items[] CreateTradingItems()
        {
            Items[] arrayOfItems = new Items[6];
            {
                arrayOfItems[0] = new Items("Gems", 100, 10);
                arrayOfItems[1] = new Items("Gold", 150, 9);
                arrayOfItems[2] = new Items("Pie", 50, 8);
                arrayOfItems[3] = new Items("Donkey", 70, 7);
                arrayOfItems[4] = new Items("Platinum", 1000, 6);
                arrayOfItems[5] = new Items("Slave", 2200, 5);
            }
            return arrayOfItems;
        }

        // Creates Trade Menu Lists
        public static string[] CreateTradeMenus(Items[] tradingItems)
        {
            // Building the output strings for buy and sell menues
            string itemList = "";
            int count = 1;
            foreach (Items items in tradingItems)
            {

                itemList += count++ + ". " + items.GetName() + "\n";
                if (count == 11)
                {
                    itemList += "\n>>> ";
                }
            }
            string[] tradeMenu = { "\nWhat would you like to buy?\n\n" + itemList, "\nWhat would you like to sell?\n\n" + itemList };
            return tradeMenu;
        }

        // Displays the endgame stats.
        public static void EndGameReport(Player myPlayer)
        {
            myPlayer.ShowStatus();
            Console.WriteLine("\nYour Journey is over. ");
            Console.WriteLine($"GameOver Good Job.");
            // Quits the Game
            Environment.Exit(-1);
        }
    }
}
