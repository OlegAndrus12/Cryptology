using System;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
namespace Lab3
{
    public class Program
    {

        static void Main(string[] args)
        {

        }
    }

    public class Lab3Controler
    {
        public const string EnAlphabet = " abcdefghijklmnopqrstuvwxyz";
        public const string UkAlphabet = " абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";

        public string KeyWord { get; set; }

        public Lab3Controler(string KeyWord = " ")
        {
            this.KeyWord = KeyWord;
        }

        public string EncodeCurrentAlphabet(string input, bool isEnglish)
        {
            string res = string.Empty;
            int key;
            int j = 0;

            string alphabet = isEnglish == true ? EnAlphabet : UkAlphabet;
            foreach (var i in new List<char>(input))
            {
                key = alphabet.IndexOf(KeyWord[j % KeyWord.Length]);
                ++j;

                res += alphabet.IndexOf(i) != -1 ?
                    (key ^ alphabet.IndexOf(i)) >= alphabet.Length ? i : alphabet[(key ^ alphabet.IndexOf(i))]
                    : i;
            }

            return res;
        }

        public static string GenerateGamma(int gammaSize, bool isEnglish = true)
        {
            string res = string.Empty;
            var rand = new Random();
            string alphabet = isEnglish == true ? EnAlphabet : UkAlphabet;
            for (int i = 0; i < gammaSize; ++i)
            {
                res += alphabet[rand.Next(alphabet.Length)];
            }
            return res;
        }

        public string EncodeUnicode(string input, bool isEnglish)
        {
            string res = string.Empty;
            char key;
            int j = 0;

            string alphabet = isEnglish == true ? EnAlphabet : UkAlphabet;
            foreach (var i in new List<char>(input))
            {
                key = KeyWord[j % KeyWord.Length];
                ++j;

                res += (char)((int)i ^ (int)key);

            }

            return res;
        }
    }

}
