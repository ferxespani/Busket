using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Busket
{
    class PlayerNotepad : UsualPlayer
    {
        public PlayerNotepad(string name) : base(name) { }

        public override int GuessNumber()
        {
            List<int> list = new List<int>();
            Console.WriteLine($"{Name} is thinking about number.... ");
            Thread.Sleep(1000);
            int temp = new Random().Next(40, 141);
            while (list.Contains(temp))
            {
                temp = new Random().Next(40, 141);

            }
            list.Add(temp);
            Console.WriteLine($"My number is {temp}");
            return temp;
        }


    }
}
