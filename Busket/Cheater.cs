using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Busket
{
    class Cheater : UsualPlayer
    {
        public Cheater(string name, CounterKeeper counterKeeper, Busket1 busket) : base(name, counterKeeper, busket)
        {
        }

        public override int GuessNumber()
        {
            Thread.Sleep(100);
            int temp = rand.Next(40, 141);
            while (list.Contains(temp))
            {
                temp = rand.Next(40, 141);
            }
            list.Add(temp);
            ClosestNumber(temp);
            return temp;
        }
    }
}
