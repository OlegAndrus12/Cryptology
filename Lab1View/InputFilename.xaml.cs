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

namespace Lab1View
{
    /// <summary>
    /// Interaction logic for InputFilename.xaml
    /// </summary>
    public partial class InputFilename : Window
    {
        public InputFilename()
        {
            InitializeComponent();
            
        }

        private void KeyValueTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                this.Close();
            }
        }
    }
}
