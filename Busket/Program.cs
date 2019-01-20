using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busket
{
    class Program
    {
        static void Main(string[] args)
        {
            UsualPlayer u = new UsualPlayer("Vitaliy");
            PlayerNotepad p = new PlayerNotepad("Denis");
            u.CheckAnswer();
            p.CheckAnswer();
        }
    }
}
