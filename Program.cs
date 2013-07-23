using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectedPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 5 Year Estimated Growth from the Valuation page\n");
            var fiveYrEstGrowth = Console.ReadLine();
            Console.WriteLine("Enter Industry Group P/E from the Current Year EPS on the Earning Estimate page\n");
            var groupPE = Console.ReadLine();

            var growth = Double.Parse(fiveYrEstGrowth);
            var PE = Double.Parse(groupPE);


            Console.WriteLine("Reduced 5 Year Growth Rate: " + reduceRate(growth));
            Console.WriteLine("Reduced PE: " + reduceRate(PE));
            Console.ReadLine();

        }

        public static double reduceRate(double rate)
        {
            double newRate = 0;
            if (rate < 6)
                newRate = rate;
            else if (rate < 12)
                newRate = rate - rate * .05;
            else if (rate < 20)
                newRate = rate - rate * .1;
            else if (rate < 30)
                newRate = rate - rate * .15;
            else
                newRate = rateOver30(rate);

            return newRate;
        }

        private static double rateOver30(double rate)
        {
            double newRate = 0;
            double reduction = .2;
            double benchmark = .3;
            while(newRate < .4)
            {
                if (rate < benchmark)
                    return rate - rate*reduction;

                reduction += 0.025;
                benchmark += .05;
            }
            return .4;
        }
    }
}
