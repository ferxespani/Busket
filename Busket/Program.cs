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
                int temp = rand.Next(1, 5);
                if (temp == 1)
                    players[i] = new UsualPlayer("Vitaly");
                else if (temp == 2)
                    players[i] = new PlayerNotepad("Den");
                else if (temp == 3)
                    players[i] = new UberPlayer("Maxim");
                else if (temp == 4)
                    players[i] = new Cheater("Vlad");
            }

            foreach (var s in players)
            {
                CheckWeight(busket, s);
            }

        }

        static bool CheckWeight(Busket1 b, UsualPlayer p)
        {
            if (p.GuessNumber() == b.Weight)
            {
                Console.WriteLine("Congratulation! The weight of basket was guessed\n");
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
