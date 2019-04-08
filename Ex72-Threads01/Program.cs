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
        public delegate void ThreadStart();
        static void Main(string[] args)
        {
            Thread t = new Thread(WriteHello);

            Thread t2 = new Thread((Object mess) =>
            {
                WriteHello(mess);
            });

            Thread t3 = new Thread(delegate(Object mess)
            {
                WriteHello(mess);
            });

            t.Start("Hej t");
            t2.Start("Nej t2");
            t3.Start("Hello World");
        }

        static void WriteHello(Object mess)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(mess.ToString());
            }
        }
    }
}
