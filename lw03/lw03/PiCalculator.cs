using System;
using System.Threading;

namespace lw03
{
    public class PiCalculator
    {
        private static ICriticalSection criticalSection;

        private static double pi = 0.0;

        private static int timeout;

        public static double GetPi(int numberOfThreads, int numberOfSteps, int numberOfSpins, int time, bool isEnter)
        {
            Thread[] threads = new Thread[numberOfThreads];
            int steps = numberOfSteps;
            timeout = time;
            criticalSection = new CriticalSectionImpl(numberOfSpins);
            int iterations = numberOfSteps / numberOfThreads;
            pi = 0;
            
            double step = 1.0 / steps;
            for (int i = 0; i < numberOfThreads; ++i)
            {
                Thread thread = isEnter ? new Thread(CalculateWithEnter) : new Thread(CalculateWithTryEnter);
                threads[i] = thread;
                
                ArgsThread argsThread = new ArgsThread(i * iterations, (i + 1) * iterations, step);
                thread.Start(argsThread);
            }
            
            for(int i = 0; i < numberOfThreads; ++i)
            {
                threads[i].Join();
            }

            return pi;

        }

        private static void CalculateWithEnter(object arg)
        {
            if (arg.GetType() != typeof(ArgsThread))
            {
                throw new Exception("Incorrect type");
            }
            ArgsThread argsThread = (ArgsThread)arg;
            for(long i = argsThread.left; i < argsThread.right; ++i)
            {
                double x = (i + 0.5) * argsThread.step;
                double value = 4.0 / (1 + x * x) * argsThread.step;
                
                criticalSection.Enter();
                pi += value;
                criticalSection.Leave();
            }
        }

        private static void CalculateWithTryEnter(object arg)
        {
            if (arg.GetType() != typeof(ArgsThread))
            {
                throw new Exception("Incorrect type");
            }
            ArgsThread argsThread = (ArgsThread)arg;
            for(long i = argsThread.left; i < argsThread.right;)
            {
                double x = (i + 0.5) * argsThread.step;
                double value = 4.0 / (1 + x * x) * argsThread.step;
                
                if(criticalSection.TryEnter(timeout))
                {
                    pi += value;
                    criticalSection.Leave();
                    ++i;
                }
            }
        }
    }
}