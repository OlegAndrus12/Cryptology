using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab2View
{
    /// <summary>
    /// Interaction logic for InputFilename.xaml
    /// </summary>
    public partial class InputFilename : Window
    {
        public bool IsEnglish;
        public const string EnAlphabet = " abcdefghijklmnopqrstuvwxyz";
        public const string UkAlphabet = " абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
        public InputFilename(bool isEnglish = true)
        {
            InitializeComponent();
            this.IsEnglish = isEnglish;
        }

        public bool Validate(string input)
        {
            bool res = true;
            string alphabet = IsEnglish == true ? EnAlphabet : UkAlphabet;
            foreach (var i in new List<char>(input))
            {
                if(alphabet.IndexOf(i) == -1)
                {
                    res = false;
                }
            }
            return res;
        }

        private void KeyValueTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if (Validate(KeyValueTextBox.Text) == true)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrct key. \nPlease try again!");
                    KeyValueTextBox.Text = string.Empty;
                }
            }
        }
    }
}
