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
        protected static List<int> whoIsCloserList;
        protected static List<string> namesList;

        protected static Random rand;
        public CounterKeeper counterKeeper;
        public Busket1 basket;

        static UsualPlayer()
        {
            list = new List<int>();
            whoIsCloserList = new List<int>();
            namesList = new List<string>();
            rand = new Random();
        }

        public UsualPlayer(string name, CounterKeeper counterKeeper, Busket1 basket)
        {
            Name = name;
            this.counterKeeper = counterKeeper;
            this.basket = basket;

        }

        public void ClosestNumber(int guessNumber)
        {
            int temp = basket.Weight - guessNumber;
            whoIsCloserList.Add(temp);
            namesList.Add(Name);
        }

        public  void WhoIsCloser()
        {
            int min = 0;
            int counter = 0;
            for (int i = 1; i < 140; i++)
            {
                if (whoIsCloserList.Contains(i) || whoIsCloserList.Contains(-i))
                {
                    for(int j = 0; j < whoIsCloserList.Count; j++)
                    {
                        if(whoIsCloserList[j] == i || whoIsCloserList[j] == -i)
                        {
                            min = whoIsCloserList[j];
                            counter = j;
                            break;
                        }
                    }
                    break;
                }
            }
            

            Console.WriteLine($"But player {namesList[counter]} was closer than others with number {basket.Weight - min}");
        }

        public virtual int GuessNumber()
        {
            int temp = rand.Next(40, 141);
            if (!list.Contains(temp))
            {
                list.Add(temp);
            }
            ClosestNumber(temp);
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
                    counterKeeper.counter++;

                }

                bool check = CheckWeight(basket, this);
                if (check)
                {
                    lock (counterKeeper)
                    {
                        counterKeeper.check = check;
                    }
                    Console.WriteLine($"Player {Name} have guessed a number. Number of attempt: {counterKeeper.counter}\n");
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
                return false;
            }
        }
        public Task RunThread()
        {
            return Task.Run(() => ResultComparator());
        }
    }
}