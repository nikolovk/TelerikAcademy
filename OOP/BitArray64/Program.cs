using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray64
{
    class Program
    {
        static void Main(string[] args)
        {
            BitArray64 number = new BitArray64(555555555555550);
            for (int i = 63; i >= 0; i--)
            {
                Console.Write(number[i]);
            }
            Console.WriteLine();
            foreach (var item in number)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
    }
}
