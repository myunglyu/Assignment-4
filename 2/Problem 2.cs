using System;
using System.IO;
using System.Diagnostics;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "numbers.txt"; // this file is saved to the same folder with the executable file.
            Stopwatch stopwatch = new Stopwatch();
            Method01(fileName, 1000, 1, 1001);


            string[] lines = File.ReadAllLines(fileName);   // Reads all lines from the file
            int[] values = new int[lines.Length];           // Initiates an array with the size of same number to the lines in the file.
            for (int i = 0; i < values.Length; i++)         // Each line in the file will be converted to integer and entered to the array.
            {
                values[i] = Convert.ToInt32(lines[i]);
            }

            stopwatch.Start();
            Console.WriteLine("starting ... ");
            Method02(values);
            Console.WriteLine("done! ... ");
            stopwatch.Stop();
            Console.WriteLine("time measured: {0} ms", stopwatch.ElapsedMilliseconds);
            foreach (int value in values)
                Console.Write(value + " ");
            Console.WriteLine();
        }

        /* This method takes filename and 3 numbers.
         * Then it generates 'total' number of random numbers between 'lowerRange' and 'upperRange'.
         * Each number will be written in a new line in the specified file. */
        static void Method01(string fileName, int total, int lowerRange, int upperRange)
        {
            using (var writer = new StreamWriter(fileName))
            {
                Random r = new Random();
                int number = 0;
                {
                    for (int i = 1; i < total; i++)
                    {
                        number = r.Next(lowerRange, upperRange);
                        writer.WriteLine(number);
                    }
                }
            }
        }
        /* This method will sort the array from the least to the greatest.
         * In first iteration, it will compare the first to the second element, to the third, and until the last one.
         * If the later element is greather than the one before, they will be swapped.
         * after the first iteration, the second element will be compared to from the third and the rest.
         * The program will continue until the second to last element is compared to the last one.
         */
        static void Method02(int[] arr)
        {
            for (int start = 0; start < arr.Length - 1; start++)
            {
                int posMin = start;
                for (int i = start + 1; i < arr.Length; i++)
                {
                    if (arr[i] < arr[posMin])
                    {
                        posMin = i;
                    }
                }
                int tmp = arr[start];
                arr[start] = arr[posMin];
                arr[posMin] = tmp;
            }
        }
    }
}