using System;
using System.Text;
using System.Collections.Generic;



namespace Lab1Control
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            MainWindowController controller = new MainWindowController(-3);
            Console.WriteLine(controller.Encode("abcAbBC AZX"));
        }
    }



    public class MainWindowController
    {
        public const string EnAlphabet = "abcdefghijklmnopqrstuvwxyz";
        public const string UkAlphabet = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
        public int Key { get; set; }

        public MainWindowController(int key = 3)
        {
            Key = key % EnAlphabet.Length;
        }

        public string Encode(string input)
        {
            string res = string.Empty;

            foreach (var i in new List<char>(input))
            {
                if (!char.IsUpper(i))
                {
                    res += EnAlphabet.IndexOf(i) != -1 ?
                        (Key < 0) && (EnAlphabet.IndexOf(i) < Math.Abs(Key)) ?
                        EnAlphabet[EnAlphabet.Length - (Math.Abs(Key) - EnAlphabet.IndexOf(i))]
                        :
                        EnAlphabet[(EnAlphabet.IndexOf(i) + Key) % EnAlphabet.Length]
                        : i;
                }
                else
                {
                    res += EnAlphabet.IndexOf(char.ToLower(i)) != -1 ?
                        (Key < 0) && (EnAlphabet.IndexOf(char.ToLower(i)) < Math.Abs(Key)) ?
                        char.ToUpper(EnAlphabet[EnAlphabet.Length - (Math.Abs(Key) - EnAlphabet.IndexOf(char.ToLower(i)))])
                        :
                        char.ToUpper(EnAlphabet[(EnAlphabet.IndexOf(char.ToLower(i)) + Key) % EnAlphabet.Length])
                        : i;
                }
            }
            return res;
        }
        public string Decode(string input)
        {
            string res = string.Empty;

            foreach (var i in new List<char>(input))
            {
                if (!char.IsUpper(i))
                {
                    res += EnAlphabet.IndexOf(i) != -1 ?
                        (Key > 0) && (EnAlphabet.IndexOf(i) < Math.Abs(Key)) ?
                        EnAlphabet[EnAlphabet.Length - (Math.Abs(Key) - EnAlphabet.IndexOf(i))]
                        :
                        EnAlphabet[(EnAlphabet.IndexOf(i) - Key) % EnAlphabet.Length]
                        : i;
                }
                else
                {
                    res += EnAlphabet.IndexOf(char.ToLower(i)) != -1 ?
                        (Key > 0) && (EnAlphabet.IndexOf(char.ToLower(i)) < Math.Abs(Key)) ?
                        char.ToUpper(EnAlphabet[EnAlphabet.Length - (Math.Abs(Key) - EnAlphabet.IndexOf(char.ToLower(i)))])
                        :
                        char.ToUpper(EnAlphabet[(EnAlphabet.IndexOf(char.ToLower(i)) - Key) % EnAlphabet.Length])
                        : i;
                }
            }
            return res;
        }
    }
}
