using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryBets;
using ClassLibraryBets.Core;

namespace Roulette2
{
    public class Program
    {

        Menus menu = new Menus();
        static void Main(string[] args)
        {

            Menus menu = new Menus();
            Console.ReadLine();
            Console.Clear();
            menu.Play();
        }
    }
}
