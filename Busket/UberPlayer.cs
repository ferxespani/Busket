﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Busket
{
    class UberPlayer : UsualPlayer
    {
        private static int startNumber;
        private static int count;

        static UberPlayer()
        {
            startNumber = 40;
            count = 0;
        }

        public UberPlayer(string name) : base(name)
        {
        }

        public override int GuessNumber()
        {
            Console.WriteLine($"{Name} is thinking about number.... ");
            Thread.Sleep(100);
            int temp = startNumber + count;
            if(!list.Contains(temp))
            {
                list.Add(temp);
            }
            count++;
            Console.WriteLine($"My number is {temp}");
            return temp;
        }
    }
}