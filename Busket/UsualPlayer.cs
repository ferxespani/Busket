using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Busket
{
    class UsualPlayer
    {
        public string Name { get; set; }

        protected static List<int> list;

        protected static Random rand;

        static UsualPlayer()
        {
            list = new List<int>();
            rand = new Random();
        }

        public UsualPlayer(string name)
        {
            Name = name;
        }

        public void GetList()
        {
            foreach(int s in list)
            {
                Console.WriteLine($"{s}  ");
            }
        }

        public virtual int GuessNumber()
        {
            Console.WriteLine($"{Name} is thinking about number.... ");
            Thread.Sleep(100);
            int temp = rand.Next(40, 141);
            if (!list.Contains(temp))
            {
                list.Add(temp);
            }
            Console.WriteLine($"My number is {temp}");
            return temp;
        }
    }
}
