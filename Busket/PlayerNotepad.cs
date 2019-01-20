using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busket
{
    class PlayerNotepad : UsualPlayer
    {
        public PlayerNotepad(string name) : base(name) { }

        public override int GuessNumber()
        {
            List<int> list = new List<int>();
            int temp = Busk.rand.Next(40, 141);
            while (list.Contains(temp))
            {
                temp = Busk.rand.Next(40, 141);

            }
            list.Add(temp);
            return temp;
        }
    }
}
