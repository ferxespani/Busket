using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busket
{
    class Busket1
    {
        public int Weight { get; set; }

        public Busket1()
        {
            Weight = new Random().Next(40, 141);
        }
    }
}
