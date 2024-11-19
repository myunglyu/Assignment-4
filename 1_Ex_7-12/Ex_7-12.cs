using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace _1_Ex_7_12
{
    internal class CaptainCrunch
    {
        static void Main(string[] args)
        {
            string str = "Hello, World!";
            string str2 = Encode(str, 854);
            Console.WriteLine(str);
            Console.WriteLine(str2);
        }

        public static string Encode(string str, int num)
        {
            if (num <= 0)
            {
                num = num % 26 + 26;
            }

            char d;
            string newString = "";
            foreach (char c in str)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    d = (char)(((c - 'A' + num) % 26) + 'A');
                }
                else if (c >= 'a' && c <= 'z')
                {
                    d = (char)(((c - 'a' + num) % 26) + 'a');
                }
                else
                {
                    d = c;
                }
                newString += d;
            }
            return newString;
        }
    }
}
