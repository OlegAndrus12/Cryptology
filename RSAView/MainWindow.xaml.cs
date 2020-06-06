using System.Windows;
using System.IO;
using Microsoft.Win32;
using System;
using RSA;
using System.ComponentModel.DataAnnotations;

namespace RSAView
{

    public partial class MainWindow : Window
    {
        public int P;
        public int Q;
        public int N;
        public int M;
        public int D;
        public int E;

        public MainWindow()
        {
            InitializeComponent();
            aboutBtn.Click += aboutUsClick;
            printBtn.Click += printClick;
            saveBtn.Click += saveClick;
            exitBtn.Click += exitClick;
            encodeBtn.Click += encodeClick;
            decodeBtn.Click += decodeClick;
            GenerateKeyPairs.Click += GenerateKeyPairsClick;
        }

        private void GenerateKeyPairsClick(object sender, RoutedEventArgs e)
        {
            Generator generator = new Generator();
            generator.ShowDialog();
        }

        private void encodeClick(object sender, RoutedEventArgs e)
        {
            InputCoeff input1 = new InputCoeff();
            input1.ShowDialog();
            P = Convert.ToInt32(input1.coeffPTextBox.Text);
            Q = Convert.ToInt32(input1.coeffQTextBox.Text);
            M = (P - 1) * (Q - 1);
            N = P * Q;
            E = RSAController.CalculateE(M)[0];
            D = RSAController.CalculateD(E, M);
            contentTextBox.Text = RSAController.Encode(contentTextBox.Text, E, N);
        }

        private void decodeClick(object sender, RoutedEventArgs e)
        {
            contentTextBox.Text = RSAController.Decode(contentTextBox.Text, D, N);
        }

        private void aboutUsClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Designed by Oleh Andrus \n2019 \nAll rights reserved");
        }

        private void openFileClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                contentTextBox.Text = File.ReadAllText(openFileDialog.FileName);
                filenameLabel.Content = openFileDialog.FileName;
            }
        }
        private void saveClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "All files (*.*)|*.*";
            saveFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, contentTextBox.Text);
            }

        }
        private void printClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("— — — Send to processing — — —");
        }
        private void exitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
