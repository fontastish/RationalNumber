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
            Fraction num = new Fraction(1, 2, 5, 10);
            Fraction testParse = Fraction.Parse("10.25");
            //Fraction num = new Fraction(-1, 9, 9, 10);
            //Fraction testParse = new Fraction();
            //testParse = Fraction.Parse("-9,9");
            //Console.WriteLine(testParse);
            //Console.WriteLine(num);
            //Console.WriteLine(testParse + num);
            //Console.WriteLine(testParse + -9);
            //Console.WriteLine(-9 + testParse);
            //Console.WriteLine(-testParse);
            Console.WriteLine(testParse / num);
            Console.ReadKey();
        }
    }
}
