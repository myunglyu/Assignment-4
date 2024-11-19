using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace _3_Ex_9_3
{
    internal class Rational
    {
        int Numerator;
        int Denominator;

        public Rational()
        {
            Numerator = 0;
            Denominator = 1;
        }
        public Rational(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }
        static void WriteRational(Rational r)
        {
            Console.WriteLine($"{r.Numerator} / {r.Denominator}");
        }
        void Negate()
        {
            this.Numerator = -this.Numerator;
        }
        void Invert()
        {
            int tmp = Denominator;
            Denominator = Numerator;
            Numerator = tmp;
        }
        static double ToDouble(Rational r)
        {
            double d = (double)r.Numerator / r.Denominator;
            return d;
        }
        static Rational Reduce(Rational r)
        {
            Rational newR = new Rational();

            static long GCD(long n1, long n2)
            {
                if (n2 == 0) { return n1; }
                else { return GCD(n2, n1 % n2); }
            }

            int gcd = (int)GCD(r.Numerator, r.Denominator);
            newR.Numerator = r.Numerator/gcd;
            newR.Denominator = r.Denominator/gcd;

            return newR;
        }
        static Rational Add(Rational r1, Rational r2)
        {
            int newDenominator = r1.Denominator * r2.Denominator;
            int newNumerator = r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator;
            Rational r = Reduce(new Rational(newNumerator, newDenominator));
            return r;
        }

    static void Main(string[] args)
        {
            Rational r = new Rational();
            Rational r2 = new Rational(2, 3);
            Rational r3 = new Rational(3, 4);
            Rational r4 = new Rational(152, 432);
            Rational r5 = new Rational(5, 16);
            Rational r6 = new Rational(1, 12);

            Console.Write("Default Cunstructor: ");
            WriteRational(r);
            Console.Write("Rational(2, 3): ");
            WriteRational(r2);
            Console.Write("Rational(2, 3) Negated: ");
            r2.Negate();
            WriteRational(r2);
            Console.Write("Rational(3,4) Inverted: ");
            r3.Invert();
            WriteRational(r3);
            Console.Write("Rational(152, 432) ToDouble: ");
            Console.WriteLine(ToDouble(r4));
            Console.Write("Rational(152, 432) Reduced: ");
            WriteRational(Reduce(r4));
            Console.Write("Rational(5, 16) + Rational(1, 12): ");
            WriteRational(Add(r5, r6));

        }
    }
}
