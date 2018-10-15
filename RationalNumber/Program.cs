using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fraction num = new Fraction(-1, 9, 9, 10);
            Console.WriteLine(num);
            Console.ReadKey();
        }
    }
}
