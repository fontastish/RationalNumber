using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RationalNumber
{
    [SuppressMessage("ReSharper", "CommentTypo")]
    class Fraction
    {
        private int sign;
        private int intPart;
        private int numerator;
        private int denominator;

        public int Sign { get => sign; set => sign = value; }
        public int IntPart { get => intPart; set => intPart = value; }
        public int Numerator { get => numerator; set => numerator = value; }
        public int Denominator { get => denominator; set => denominator = value; }

        public Fraction()
        {
            sign = 0;
            intPart = 0;
            numerator = 0;
            denominator = 0;
        }

        public Fraction(int sign, int intPart, int numerator,int denominator)
        {
            this.sign = sign;
            this.intPart = intPart;
            this.numerator = numerator;
            this.denominator = denominator;
        }

        private void GetMixedView()   // метод преобразование дроби в смешанный вид
        {
            Cancellation();
            GetIntPart();
        }

        private void Cancellation()   // метод сокращения дроби

        {
            for (int i = Numerator; i > 0; i--)
            {
                if (Numerator % i == 0 && Denominator % i == 0)
                {
                    numerator /= i;
                    denominator /= i;
                    break;
                }
            }
            
        }

        private void GetIntPart()   // метод выделения целой части дроби

        {
            intPart += numerator / denominator;
            numerator = numerator % denominator;

        }

        public static Fraction Parse(string str)           //string to our obj
        {
            Fraction num = null;
            string[] words = str.Split(new[] { ' ', ',' });
            if (words[0][0] == '0')
                num.sign = -1;
            else
                num.sign = 1;
            num.intPart = num.sign * int.Parse(words[0]);
            num.numerator = int.Parse(words[1]);
            num.denominator = words[1].Length * 10;
            return num;
        }

        public override string ToString()
        {
            double result = denominator * intPart + numerator * sign;
            string strout = result.ToString();
            return strout;
        }
    }
}
