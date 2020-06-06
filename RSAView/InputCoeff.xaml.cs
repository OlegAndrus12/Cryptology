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

namespace RSAView
{
    /// <summary>
    /// Interaction logic for InputCoeff.xaml
    /// </summary>
    public partial class InputCoeff : Window
    {
        public InputCoeff()
        {
            InitializeComponent();
            coeffQTextBox.KeyDown += KeyValueTextBox_KeyDown;
        }
        private void KeyValueTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.Close();
            }
        }
    }
}
