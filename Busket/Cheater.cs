using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Busket
{
    class Cheater : UsualPlayer
    {
        public Cheater(string name) : base(name)
        {
        }

        public override int GuessNumber()
        {
            Console.WriteLine($"{Name} is thinking about number.... ");

            Thread.Sleep(100);

            int temp = rand.Next(40, 141);

            while (list.Contains(temp))
            {
                temp = rand.Next(40, 141);
            }

            list.Add(temp);

            Console.WriteLine($"My number is {temp}");

            return temp;
        }
    }
}
