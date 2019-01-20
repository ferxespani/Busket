using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busket
{
    class UsualPlayer
    {
        public string Name { get; set; }
        public Busket1 Busk { get; set; }

        public UsualPlayer() { }

        public UsualPlayer(string name)
        {
            Name = name;
            Busk = new Busket1();
        }

        public virtual int GuessNumber()
        {
            int temp = Busk.rand.Next(40, 141);
            return temp;
        }

        public void CheckAnswer()
        {
            var temp = GuessNumber();
            Console.WriteLine($"The player number is {temp} ");
            if (temp == Busk.Weight)
            {
                Console.WriteLine("Congratulations! The weight of busket was guessed");
            }
            else
            {
                Console.WriteLine("The answer is not correct");
            }
        }
    }
}
