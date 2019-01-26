using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Busket
{
    class PlayerNotepad : UsualPlayer
    {
        static private List<int> NotepadList;

        public PlayerNotepad(string name) : base(name)
        {
        }

        static PlayerNotepad()
        {
            NotepadList = new List<int>();
        }

        public override int GuessNumber()
        {
            Console.WriteLine($"{Name} is thinking about number.... ");

            Thread.Sleep(100);

            int temp = rand.Next(40, 141);

            while (NotepadList.Contains(temp))
            {
                temp = rand.Next(40, 141);
            }

            NotepadList.Add(temp);
            list.Add(temp);

            Console.WriteLine($"My number is {temp}");

            return temp;
        }


    }
}
