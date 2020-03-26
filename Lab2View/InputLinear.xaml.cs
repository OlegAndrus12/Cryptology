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
    /// Interaction logic for InputLinear.xaml
    /// </summary>
    public partial class InputLinear : Window
    {
        public InputLinear()
        {
            InitializeComponent();
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
