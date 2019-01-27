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
        public CounterKeeper counterKeeper;
        public Busket1 basket;

        static UsualPlayer()
        {
            list = new List<int>();
            rand = new Random();
        }

        public UsualPlayer(string name, CounterKeeper counterKeeper, Busket1 basket)
        {
            Name = name;
            this.counterKeeper = counterKeeper;
            this.basket = basket;

        }

        public void GetList()
        {
            foreach (int s in list)
            {
                Console.WriteLine($"{s}  ");
            }
        }

        public virtual int GuessNumber()
        {
            Console.WriteLine($"{Name} is thinking about number.... ");

            int temp = rand.Next(40, 141);
            if (!list.Contains(temp))
            {
                list.Add(temp);
            }
            Console.WriteLine($"{Name} number is {temp}");
            return temp;
        }

        public void ResultComparator()
        {
            while (!counterKeeper.check)
            {
                lock (counterKeeper)
                {
                    if (counterKeeper.counter > 100)
                    {
                        break;
                    }
                    Console.WriteLine($"Number of attempt: {counterKeeper.counter}");
                    counterKeeper.counter++;

                }

                bool check = CheckWeight(basket, this);
                if (check)
                {
                    lock (counterKeeper)
                    {
                        counterKeeper.check = check;
                    }
                    Console.WriteLine($"Player {Name} have guessed a number.");
                    break;
                }

                Thread.Sleep(100);
            }

        }
        public bool CheckWeight(Busket1 b, UsualPlayer p)
        {
            if (p.GuessNumber() == b.Weight)
            {
                Console.WriteLine($"Congratulation {Name}! The weight of basket was guessed\n");
                b.WeightGuessed = true;
                return true;
            }
            else
            {
                Console.WriteLine($"{Name}'s answer is not correct\n");
                return false;
            }
        }
        public Task RunThread()
        {
            return Task.Run(() => ResultComparator());
        }
    }
}
