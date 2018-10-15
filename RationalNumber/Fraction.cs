using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RationalNumber
{
    [SuppressMessage("ReSharper", "CommentTypo")]
    class Fraction
    {
        public int Sign { get; set; }
        public int IntPart { get; set; }
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction()
        {
            Sign = 0;
            IntPart = 0;
            Numerator = 0;
            Denominator = 0;
        }

        public Fraction(int sign, int intPart, int numerator,int denominator)
        {
            this.Sign = sign;
            this.IntPart = intPart;
            this.Numerator = numerator;
            this.Denominator = denominator;
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
                    Numerator /= i;
                    Denominator /= i;
                    break;
                }
            }
            
        }

        private void GetIntPart()   // метод выделения целой части дроби

        {
            IntPart += Numerator / Denominator;
            Numerator = Numerator % Denominator;

        }

        public static Fraction Parse(string str)           //string to our obj
        {
            Fraction num = null;
            string[] words = str.Split(new[] { ' ', ',' });
            if (words[0][0] == '0')
                num.Sign = -1;
            else
                num.Sign = 1;
            num.IntPart = num.Sign * int.Parse(words[0]);
            num.Numerator = int.Parse(words[1]);
            num.Denominator = words[1].Length * 10;
            return num;
        }

        //public static Fraction operator + (Fraction ob1, Fraction ob2)
        //{
        //    Fraction num;
        //    num.Sign = ob1.Sign
        //    return num;
        //}

        //public static string ToString()
        //{
        //    double result = (denominator * intPart + numerator * sign)/;
        //    string strout = result.ToString();
        //    return strout;
        //}

        public static implicit operator string(Fraction ob)
        {
            double result = ((ob.Denominator * ob.IntPart + ob.Numerator) * ob.Sign)/ (double)ob.Denominator;
            return result.ToString("##.000");
        }
    }
}
