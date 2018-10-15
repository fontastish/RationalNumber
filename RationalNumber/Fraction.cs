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
            Sign = 1;
            IntPart = 0;
            Numerator = 0;
            Denominator = 1;
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
            Fraction num = new Fraction();
            if (str.Length == 0 || str[0]=='0')
            {
                return num;
            }

            string[] words = str.Split(new[] {' ', ',', '.'});
            if (words[0][0] == '-')
                num.Sign = -1;
            else
                num.Sign = 1;
            num.IntPart = num.Sign * int.Parse(words[0]);
            num.Numerator = int.Parse(words[1]);
            num.Denominator = (int) Math.Pow(10, words[1].Length);
            return num;
        }

        public static Fraction operator + (Fraction ob1, Fraction ob2)
        {
            double ob1d = ((ob1.Denominator * ob1.IntPart + ob1.Numerator) * ob1.Sign) / (double) ob1.Denominator;
            double ob2d = ((ob2.Denominator * ob2.IntPart + ob2.Numerator) * ob2.Sign) / (double)ob2.Denominator;
            double obd = ob1d + ob2d;
            Fraction num = Fraction.Parse(obd.ToString("##.#######"));
            num.GetMixedView();
            return num;
        }

        public static Fraction operator +(Fraction ob1, int a)
        {
            Fraction ob2 = new Fraction(a>0?1:-1,a,0,1);
            double ob1d = ((ob1.Denominator * ob1.IntPart + ob1.Numerator) * ob1.Sign) / (double)ob1.Denominator;
            double obd = ob1d + a;
            Fraction num = Fraction.Parse(obd.ToString("##.########"));
            num.GetMixedView();
            return num;
        }

        public static Fraction operator +(int a, Fraction ob1)
        {
            return ob1 + a;
        }

        public static Fraction operator -(Fraction ob)
        {
            ob.Sign *= -1;
            return ob;
        }

        public static Fraction operator -(Fraction ob1, Fraction ob2)
        {
            return ob1 + -ob2;
        }

        public static Fraction operator -(Fraction ob1, int a)
        {
            return ob1 + -a;
        }

        public static Fraction operator -(int a, Fraction ob1)
        {
            return a + -ob1;
        }

        public static Fraction operator *(Fraction ob1, Fraction ob2)
        {
            double ob1d = ((ob1.Denominator * ob1.IntPart + ob1.Numerator) * ob1.Sign) / (double)ob1.Denominator;
            double ob2d = ((ob2.Denominator * ob2.IntPart + ob2.Numerator) * ob2.Sign) / (double)ob2.Denominator;
            double obd = ob1d * ob2d;
            Fraction num = Fraction.Parse(obd.ToString("##.########"));
            num.GetMixedView();
            return num;
        }

        public static Fraction operator *(Fraction ob1, int a)
        {

        }

        public static implicit operator string(Fraction ob)
        {
            double result = ((ob.Denominator * ob.IntPart + ob.Numerator) * ob.Sign)/ (double)ob.Denominator;
            return result.ToString("#0.###");
        }
    }
}
