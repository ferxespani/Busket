using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busket
{
    class Program
    {
        static void Main(string[] args)
        {
            Busket1 busket = new Busket1();
            UsualPlayer u = new UsualPlayer("Vitaliy");
            PlayerNotepad p = new PlayerNotepad("Denis");
            CheckWeight(busket, u);
            CheckWeight(busket, p);
        }

        static void CheckWeight(Busket1 b, UsualPlayer p)
        {
            if (p.GuessNumber() == b.Weight)
            {
                Console.WriteLine("Congratulation! The weight of busket was guessed");
            }
            else
            {
                Console.WriteLine("The answer is not correct");
            }
        }
    }
}
