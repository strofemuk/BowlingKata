using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    class Program
    {
        static void Main(string[] args)
        {
            FrameCollection frames = new FrameCollection();

            int count = 0;

            do
            {
                count++;
                Console.WriteLine("In frame {0}, Please enter the pins knowked down...", count);
                Console.Write("...on the first throw:");
                string first = Console.ReadLine();
                string second = "0";
                if (first != "10" && first !="X" && first != "x")
                {
                    Console.Write("...on the second throw:");
                    second = Console.ReadLine();
                }
                frames.Add(new Frame(first,second));
            } while (count < 10);

            if (frames[9].IsStrike || frames[9].IsSpare)
            {
                Console.WriteLine("Bonus frame #1!");
                Console.Write("Enter pins knocked down on 1st bonus frame:");
                string bonusScore1 = Console.ReadLine();
                Frame bonus1 = new Frame(bonusScore1,true);
                frames.Add(bonus1);
                if (bonus1.IsStrike && frames[9].IsStrike)
                {
                    Console.WriteLine("Bonus frame #2!");
                    Console.Write("Enter pins knocked down on 2nd bonus frame:");
                    string bonusScore2 = Console.ReadLine();
                    frames.Add(new Frame(bonusScore2,true));
                }

            }

            Console.WriteLine("The final score was: {0}", frames.Score());
            Console.ReadLine();
        }
    }
}
