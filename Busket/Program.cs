using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busket
{
    class Program
    {
        static private Random rand = new Random();

        static void Main(string[] args)
        {
            Busket1 busket = new Busket1();
            Console.WriteLine($"The weight of basket: {busket.Weight}\n");


            UsualPlayer[] players = new UsualPlayer[rand.Next(2, 9)];

            for (int i = 0; i < players.Length; i++)
            {
                int temp = rand.Next(1, 6);
                if (temp == 1)
                    players[i] = new UsualPlayer("Vitaly");
                else if (temp == 2)
                    players[i] = new PlayerNotepad("Den");
                else if (temp == 3)
                    players[i] = new UberPlayer("Maxim");
                else if (temp == 4)
                    players[i] = new Cheater("Vlad");
                else
                    players[i] = new UberCheater("Kostya");
            }

            int counter = 1;

            while (!busket.WeightGuessed && counter < 101)
            {
                foreach (var s in players)
                {
                    Console.WriteLine($"Number of attempt: {counter}");
                    bool check = CheckWeight(busket, s);
                    if (check)
                    {
                        Console.WriteLine($"Player {s.Name} have guessed a number.");
                        break;
                    }
                    else if (counter == 100)
                    {
                        Console.WriteLine("Nobody have guessed a number after 100 attempts");
                        counter++;
                        break;
                    }
                    else
                    {
                        counter++;
                    }
                }
            }

        }

        static bool CheckWeight(Busket1 b, UsualPlayer p)
        {
            if (p.GuessNumber() == b.Weight)
            {
                Console.WriteLine("Congratulation! The weight of basket was guessed\n");
                b.WeightGuessed = true;
                return true;
            }
            else
            {
                Console.WriteLine("The answer is not correct\n");
                return false;
            }
        }

    }
}
