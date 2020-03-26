using System;
using System.Collections.Generic;
using System.Text.Encodings;
using System.Linq;

namespace Lab2Controler
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "abc asas AS sa ";

            string Alphabet = " abcdefghijklmnopqrstuvwxyz";
            Lab2Contoller contoller = new Lab2Contoller(125, 147);
            foreach (var i in contoller.CountOccurancies(input))
            {
                Console.WriteLine(i.Key + " : " + i.Value);
            }
            return;
            string output = contoller.Encode(input, true, true);
            Console.WriteLine(input == contoller.Decode(output));

            int k1 = Alphabet.IndexOf(output[0]) - Alphabet.IndexOf(input[0]);
            int k2 = Alphabet.IndexOf(output[1]) - Alphabet.IndexOf(input[1]);
            int k3 = Alphabet.IndexOf(output[2]) - Alphabet.IndexOf(input[2]);
            float[,] matrix = new float[3, 3] { { 0, 1, k1 }, { 1, 1, k2 }, { 2, 1, k3 } };
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.Write("\n");
            }
            float B = matrix[0, 2];
            float A = matrix[1, 2] - B;
            Lab2Contoller contoller1;
            int it = 0;
            bool res = true;
            while (res)
            {
                Console.WriteLine("A = " + A + " B = " + B);
                contoller1 = new Lab2Contoller((int)A, (int)B);
                A += Alphabet.Length;
                B += Alphabet.Length;
                ++it;
                if ((contoller1.Encode(input, true, true) == output))
                {
                    res = false;
                }

            }

        }
    }


    public class Lab2Contoller
    {

        public const string EnAlphabet = " abcdefghijklmnopqrstuvwxyz";
        public const string UkAlphabet = " абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";

        public string KeyWord { get; set; }
        public int A { get; set; } = 0;
        public int B { get; set; } = 0;
        public int C { get; set; } = 0;
        public Lab2Contoller(int A, int B)
        {
            this.A = A;
            this.B = B;
        }
        public Lab2Contoller(int A, int B, int C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }
        public Lab2Contoller(string KeyWord)
        {
            this.KeyWord = KeyWord;
        }

        public string DecodeVizhener(string input, bool IsEnglish = true)
        {
            string res = string.Empty;
            int key;
            int j = 0;
            string alphabet = IsEnglish == true ? EnAlphabet : UkAlphabet;
            foreach (var i in new List<char>(input))
            {
                key = alphabet.IndexOf(KeyWord[j % KeyWord.Length]) % alphabet.Length;
                ++j;
                res += alphabet.IndexOf(i) != -1 ?
                    (key > 0) && (alphabet.IndexOf(i) < Math.Abs(key)) ?
                    alphabet[alphabet.Length - (Math.Abs(key) - alphabet.IndexOf(i))]
                    :
                    alphabet[(alphabet.IndexOf(i) - key) % alphabet.Length]
                    : i;
            }
            return res;
        }

        public Dictionary<char, int> CountOccurancies(string input, bool IsEnglish = true)
        {
            List<char> source = new List<char>(input);
            string alphabet = IsEnglish == true ? EnAlphabet : UkAlphabet;
            Dictionary<char, int> res = new Dictionary<char, int>();
            foreach (var i in alphabet)
            {
                var matchquery = from c in source
                                 where char.ToLower(c) == i
                                 select c;
                res.Add(i, matchquery.Count());
            }
            res = res.OrderBy(x => x.Value).Reverse().ToDictionary(z => z.Key, y => y.Value);
            return res;
        }

        public string Encode(string input, bool IsLinear = true, bool IsEnglish = true)
        {
            string res = string.Empty;
            int key;

            string alphabet = IsEnglish == true ? EnAlphabet : UkAlphabet;
            int j = 0;
            foreach (var i in new List<char>(input))
            {

                key = IsLinear == true ? A * j + B : A * A + B * j + C;
                ++j;
                key %= alphabet.Length;
                res += alphabet.IndexOf(i) != -1 ?
                    (key < 0) && (alphabet.IndexOf(i) < Math.Abs(key)) ?
                    alphabet[alphabet.Length - (Math.Abs(key) - alphabet.IndexOf(i)) % alphabet.Length]
                    :
                    alphabet[(alphabet.IndexOf(i) + key) % alphabet.Length]
                    : i;
                Console.WriteLine("Symbol" + i + "Index " + alphabet.IndexOf(i) + "Key" + key);
            }
            return res;
        }

        public string Decode(string input, bool IsLinear = true, bool isEnglish = true)
        {
            string res = string.Empty;
            int key;
            int j = 0;
            string alphabet = isEnglish == true ? EnAlphabet : UkAlphabet;
            foreach (var i in new List<char>(input))
            {
                key = IsLinear == true ? A * j + B : A * A + B * j + C;
                ++j;
                key %= alphabet.Length;
                res += alphabet.IndexOf(i) != -1 ?
                    (key > 0) && (alphabet.IndexOf(i) < Math.Abs(key)) ?
                    alphabet[alphabet.Length - (Math.Abs(key) - alphabet.IndexOf(i)) % alphabet.Length]
                    :
                    alphabet[(alphabet.IndexOf(i) - key) % alphabet.Length]
                    : i;
                Console.WriteLine("Symbol" + i + "Index " + alphabet.IndexOf(i) + "Key" + key);
            }
            return res;
        }

        public string EncodeVizhener(string input, bool isEnglish = true)
        {
            string res = string.Empty;
            int key;
            int j = 0;
            string alphabet = isEnglish == true ? EnAlphabet : UkAlphabet;
            foreach (var i in new List<char>(input))
            {
                key = alphabet.IndexOf(KeyWord[j % KeyWord.Length]) % alphabet.Length;
                ++j;
                res += alphabet.IndexOf(i) != -1 ?
                        (key < 0) && (alphabet.IndexOf(i) < Math.Abs(key)) ?
                        alphabet[alphabet.Length - (Math.Abs(key) - alphabet.IndexOf(i))]
                        :
                        alphabet[(alphabet.IndexOf(i) + key) % alphabet.Length]
                        : i;
            }

            return res;
        }

        public void Attack(string input, string output)
        {
            int k1 = EnAlphabet.IndexOf(output[0]) - EnAlphabet.IndexOf(input[0]);
            int k2 = EnAlphabet.IndexOf(output[1]) - EnAlphabet.IndexOf(input[1]);


        }
    }
}

