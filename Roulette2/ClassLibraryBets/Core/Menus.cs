using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryBets.Core
{
    public class Menus : WheelSpin
    {
        public void Play()
        {
            bool play;
            string playAgain;
            while (play = true && Player.money > 0)
            {
                Console.Clear();
                WriteText.WriteLine("Place Your Bets!", ConsoleColor.Red);
                WriteText.WriteLine($"Choose a number cooresponding to the bet you'd like to place\n" +

                    $"1: bet on a number(1/36 odds)\t 2: Even or Odds(1/2 odds)\t 3: Red or Black(1/2 odds)\n" +

                    $"4: Lows or Highs(1/2 odds)\t 5: Dozens(1/3 odds)\t 6: Column bet(1/3 odds)\n" +

                    $"7: Street(1/12 odds)\t 8: six-line(1/6 odds)\t 9: Split(1/18 odds)\n" +

                    $"10: Corner bet(1/9 odds)", ConsoleColor.Green);
                int chosenBet = Int32.Parse(Console.ReadLine());

                //switch (chosenBet)
                //{
                //    case 1: chosenBet > 10;
                //    throw new IndexOutOfRangeException("You chose a number that dose not match any of the bets.");
                //    break;
                //}
                if (chosenBet > 10)
                {
                    throw new IndexOutOfRangeException("You chose a number that dose not match any of the bets.");
                }
                if (chosenBet == 1)
                {
                    Number number = new Number();
                    number.NumbersBet(Spin());
                }

                if (chosenBet == 2)
                {
                    EvenOrOdd evenorodd = new EvenOrOdd();
                    evenorodd.EvenOrOddBet(Spin());
                }
                if (chosenBet == 3)
                {
                    RedOrBlack redorblack = new RedOrBlack();
                    redorblack.RedOrBlackBet(Spin());
                }
                if (chosenBet == 4)
                {
                    LowsHighs loworhigh = new LowsHighs();
                    loworhigh.LowOrHighBet(Spin());
                }
                if (chosenBet == 5)
                {
                    Dozens dozens = new Dozens();
                    dozens.DozensBet(Spin());
                }
                if (chosenBet == 6)
                {
                    Columns columns = new Columns();
                    columns.ColumnBet(Spin());
                }
                if (chosenBet == 7)
                {
                    Street street = new Street();
                    street.StreetBet(Spin());
                }
                if (chosenBet == 8)
                {
                    SixLine sixLine = new SixLine();
                    sixLine.SixLineBet(Spin());
                }
                if (chosenBet == 9)
                {
                    Split split = new Split();
                    split.SplitBet(Spin());
                }
                if (chosenBet == 10)
                {
                    Corner corner = new Corner();
                    corner.CornerBet(Spin());
                }
                if (Player.money == 0)
                {
                    play = false;
                    WriteText.WriteLine("You lost all you own GET OUT!", ConsoleColor.Red);
                    Console.ReadKey();
                }
                if (Player.money > 0)
                {
                    WriteText.WriteLine("Play again? (yes/no): ", ConsoleColor.Red);
                    playAgain = Console.ReadLine();
                    playAgain.ToLower();
                    if (playAgain == "yes")
                    {
                        play = true;
                        Random random = new Random();
                        int phrase = random.Next(1, 3);
                        if (phrase == 1)
                        {
                            WriteText.WriteLine("Its always possible to have Better luck this time.", ConsoleColor.Red);
                        }
                        if (phrase == 2)
                        {
                            WriteText.WriteLine("Play Again!? Why?", ConsoleColor.Red);
                        }
                        if (phrase == 3)
                        {
                            WriteText.WriteLine("Luck is on your side.", ConsoleColor.Red);
                            Console.ReadKey();
                        }
                    }
                }
            }
        }
    }
}
