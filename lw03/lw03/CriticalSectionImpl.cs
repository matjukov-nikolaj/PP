using System;
using System.Diagnostics;
using System.Threading;

namespace lw03
{
    public class CriticalSectionImpl : ICriticalSection
    {
        private int value;
        private int spinCount;
        
        public CriticalSectionImpl(int count)
        {
            this.value = 1;
            this.spinCount = count;
        }

        public void Enter()
        {
            while(true)
            {
                for(int i = 0; i < spinCount; ++i)
                {
                    if(Interlocked.CompareExchange(ref value, 2, 1) == 1)
                    {
                        return;
                    }
                }
                Thread.Sleep(10);
            }
        }

        public void Leave()
        {
            if(Interlocked.CompareExchange(ref value, 1, 2) != 2)
            {
                throw new Exception("Cant leave from section.");
            }
        }

        public void SetSpinCount(int count)
        {
            spinCount = count;
        }

        public bool TryEnter(int timeout)
        {
            var time = new Stopwatch();
            time.Start();
            while(time.ElapsedMilliseconds < timeout)
            {
                for(int i = 0; i < spinCount; ++i)
                {
                    if(Interlocked.CompareExchange(ref value, 2, 1) == 1)
                    {
                        return true;
                    }
                }
                Thread.Sleep(10);
            }
			
            return false;
        }
        
    }
}