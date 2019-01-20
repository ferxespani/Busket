using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Busket
{
    class UsualPlayer
    {
        public string Name { get; set; }

        public UsualPlayer() { }

        public UsualPlayer(string name)
        {
            Name = name;
        }

        public virtual int GuessNumber()
        {
            Console.WriteLine($"{Name} is thinking about number.... ");
            Thread.Sleep(1000);
            int temp = new Random().Next(40, 141);
            Console.WriteLine($"My number is {temp}");
            return temp;
        }
    }
}
