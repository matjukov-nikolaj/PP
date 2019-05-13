using System;
using System.Diagnostics;

namespace lw03
{
    class Program
    {
        private const int NUMBER_OF_THREADS = 4; 
        static void Main(string[] args)
        {
            if (args.Length > 3)
            {
                Console.WriteLine("Incorrect number of arguments.");
                return;
            }
            
            int numberOfSteps= Int32.Parse(args[0]);
            int timeout = Int32.Parse(args[1]);
            int numberOfSpins = Int32.Parse(args[2]);
            
            Stopwatch time = new Stopwatch();
            
            Console.WriteLine("Enter: ");
            time.Start();
            double pi = PiCalculator.GetPi(NUMBER_OF_THREADS, numberOfSteps, numberOfSpins, timeout, true);
            time.Stop();
            Console.WriteLine("    Time: " + time.ElapsedMilliseconds);
            Console.WriteLine("    Pi = " + pi);
            
            time.Reset();
            Console.WriteLine("TryEnter: ");
            time.Start();
            pi = PiCalculator.GetPi(NUMBER_OF_THREADS, numberOfSteps, numberOfSpins, timeout, false);
            time.Stop();
            Console.WriteLine("    Time: " + time.ElapsedMilliseconds);
            Console.WriteLine("    Pi = " + pi);
        }
    }
}