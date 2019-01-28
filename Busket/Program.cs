using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busket
{
    class Program
    {
        static private Random rand = new Random();

        static void Main(string[] args)
        {
            Busket1 busket = new Busket1();
            Console.WriteLine($"The weight of basket: {busket.Weight}\n");
            CounterKeeper counterKeeper = new CounterKeeper();


            UsualPlayer[] players = new UsualPlayer[5];

            Console.WriteLine("Add players: 1 - player, 2 - NodPadPlayer, 3 - uberPlayer, 4 - Cheater, 5 - UberPlayer");

            for (int i = 0; i < players.Length; i++)
            {                
                int temp = int.Parse(Console.ReadLine());
                if (temp == 1)
                    players[i] = new UsualPlayer($"Vitaly {i}", counterKeeper, busket);
                else if (temp == 2)
                    players[i] = new PlayerNotepad($"Den {i}", counterKeeper, busket);
                else if (temp == 3)
                    players[i] = new UberPlayer($"Maxim {i}", counterKeeper, busket);
                else if (temp == 4)
                    players[i] = new Cheater($"Vlad {i}", counterKeeper, busket);
                else
                    players[i] = new UberCheater($"Kostya {i}", counterKeeper, busket);
            }
            Console.WriteLine($"The number of players is {players.Length}\n");
            List<Task> playerTaskList = new List<Task>();
            foreach (var p in players)
            {
                playerTaskList.Add(p.RunThread());
            }

            Task.WaitAll(playerTaskList.ToArray());
            if (counterKeeper.counter > 100)
            {
                Console.WriteLine("Nobody have guessed a number after 100 attempts");
                players[0].WhoIsCloser();
            }
            Console.ReadKey();
        }

        

    }
}
