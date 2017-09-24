using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection_13
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var t1 = new ResourceHolderBase())
            {
                t1.MakeAction();
                t1.Dispose();
            }
            using (var t2 = new ResourceHolderDerived())
            {
                t2.MakeAction();
                GC.Collect();
            }

            Console.ReadLine();
        }
    }
}
