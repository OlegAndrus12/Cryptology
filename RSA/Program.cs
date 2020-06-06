using System;
using System.Collections.Generic;

namespace RSA
{
    public class Program
    {
        static void Main(string[] args)
        {
            //RSAController rsa = new RSAController(3,11);
            //string Alphabet = " abcdefghijklmnopqrstuvwxyz";
            //Console.WriteLine($"P : {rsa.P} Q : {rsa.Q} N : {rsa.N} M : {rsa.M}");
            //rsa.CalculateE();
            //rsa.CalculateD();
            //Console.WriteLine($"E : {rsa.E}, D : {rsa.D}");
            //string input = " abcdefghijklmnopqrstuvwxyz".ToLower();
            //string output = rsa.Encode(input);
            //Console.WriteLine(output);
            //foreach(var i in new List<char>(input))
            //{
            //    Console.Write(Alphabet.IndexOf(i) + " ");
            //}
            //Console.WriteLine();
            //string decodedText = rsa.Decode(output);
            //Console.WriteLine(decodedText);
        }
    }

    public static class RSAController
    {
        public const string EnAlphabet = " abcdefghijklmnopqrstuvwxyz";

        public static bool IsCoprime(int a, int b)
        {
            return a == b
                   ? a == 1
                   : a > b
                        ? IsCoprime(a - b, b)
                        : IsCoprime(b - a, a);
        }

        public static List<int> SieveEratosthenes(int n)
        {
            var numbers = new List<int>();
            for (var i = 2; i < n; i++)
            {
                numbers.Add(i);
            }

            for (var i = 0; i < numbers.Count; i++)
            {
                for (var j = 2; j < n; j++)
                {
                    numbers.Remove(numbers[i] * j);
                }
            }

            return numbers;
        }
        public static int Euclid(int a, int m)
        {
            int m0 = m;
            int y = 0, x = 1;

            if (m == 1)
                return 0;

            while (a > 1)
            {
                // q is quotient 
                int q = a / m;

                int t = m;

                // m is remainder now, process 
                // same as Euclid's algo 
                m = a % m;
                a = t;
                t = y;

                // Update x and y 
                y = x - q * y;
                x = t;
            }

            // Make x positive 
            if (x < 0)
                x += m0;

            return x;
        }

        public static int CalculateD(int E, int M)
        {
            return Euclid(E, M);
        }

        public static List<int> CalculateE(int M)
        {
            List<int> primeNumbers = SieveEratosthenes(M);
            List<int> eArray = new List<int>();
            foreach (var i in primeNumbers)
            {
                if (IsCoprime((int)M, (int)i))
                {
                    eArray.Add(i);
                }
            }
            Console.WriteLine();
            return eArray;
        }

        public static string Encode(string input, int E, int N)
        {
            string res = string.Empty;
            
            foreach (var i in new List<char>(input))
            {
                res += "$" + Convert.ToInt32(Math.Pow(EnAlphabet.IndexOf(Char.ToLower(i)), E) % N);
            }

            return res;
        }
        public static string Decode(string input, int D, int N)
        {
            string res = string.Empty;
            string[] r = input.Split('$');
            for (int i = 1; i<r.Length; ++i)
            {
                res += EnAlphabet[Convert.ToInt32(Math.Pow(Convert.ToInt32(r[i]), D) % N)];
            }
            return res;
        }
    }
}
