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

        public bool WeightGuessed { get; set; }

        private Random rand = new Random();

        public Busket1()
        {
            WeightGuessed = false;

            for (int i = 0; i < rand.Next(100); i++)
            {
                Weight += rand.Next(40, 141);
            }
            while (Weight > 140)
            {
                Weight /= 2;
            }
             while(Weight < 40)
            {
                if(Weight == 0)
                {
                    Weight = Weight + 40 + rand.Next(101);
                }
                else
                {
                    int temp = 40 - Weight;
                    Weight = Weight + temp + rand.Next(101);
                }
            }
        }
    }
}
