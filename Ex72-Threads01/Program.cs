using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex72_Threads01
{
    class Program
    {
        private char _sharedChar;
        private const int SIMULATE_WORK = 1;
        private object thisLock = new object();

        static void Main(string[] args)
        {
            Thread t = new Thread(WriteHello);

            Thread t2 = new Thread((object mess) =>
            {
                WriteHello(mess);
            });

            Thread t3 = new Thread(delegate(object mess)
            {
                WriteHello(mess);
            });

            t.Start("Hej t");
            t2.Start("Nej t2");
            t3.Start("Hello World");

            Program p = new Program();
            p.Run();
        }

        static void WriteHello(object mess)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(mess.ToString());
            }
        }

        public void Run()
        {
            Thread tA = new Thread(WriteA);
            Thread tB = new Thread(WriteB);
            tA.Name = "Thread A";
            tB.Name = "Thread B";
            tA.Start();
            tB.Start();
            tA.Join();
            tB.Join();
            Console.Write("\nPress a key ....");
            Console.ReadKey();
        }

        private void WriteA()
        {
            for (int i = 0; i < 10; i++)
            {
                lock (thisLock)
                {
                    _sharedChar = 'A';
                    Thread.Sleep(SIMULATE_WORK);
                    Console.WriteLine($"{Thread.CurrentThread.Name} : {_sharedChar}");
                }
                Thread.Yield();
            }
        }

        private void WriteB()
        {
            for (int i = 0; i < 10; i++)
            {
                lock (thisLock)
                {
                    _sharedChar = 'B';
                    Thread.Sleep(SIMULATE_WORK);
                    Console.WriteLine($"{Thread.CurrentThread.Name} : {_sharedChar}");
                }
                Thread.Yield();
            }
        }
    }
}