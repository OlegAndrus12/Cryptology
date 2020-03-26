using System.Windows;
using System.IO;
using Microsoft.Win32;
using System;
using Lab2Controler;
using Lab3;

namespace Lab2View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Key;
        public int A;
        public int B;
        public int C;
        public MainWindow()
        {
            InitializeComponent();
            openBtn.Click += openFileClick;
            exitBtn.Click += exitClick;
            saveBtn.Click += saveClick;
            printBtn.Click += printClick;
            encodeBtn.Click += encodeClick;
            aboutBtn.Click += aboutUsClick;
            padBtn.Click += padClick;
            decodeBtn.Click += decodeClick;
            statistics.Click += statisticsClick;
            gammaGenerator.Click += gammaClick;
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

        private void padClick(object sender, RoutedEventArgs e)
        {
            CipherPad pad = new CipherPad();
            pad.ShowDialog();
            if (pad.padName.Text != string.Empty)
                CipherPad.CreatePad(pad.padName.Text,Convert.ToInt32(pad.gammaLength.Text), Convert.ToInt32(pad.countPages.Text),(bool)pad.enRadioButton.IsChecked);            
        }

        private void aboutUsClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Designed by Oleh Andrus \n2019 \nAll rights reserved");
        }

        private void statisticsClick(object sender, RoutedEventArgs e)
        {
            Lab2Contoller contoller = new Lab2Contoller("");
            string res = string.Empty;
            foreach (var i in contoller.CountOccurancies(contentTextBox.Text))
            {
                res += i.Key + " : " + i.Value + "\n";
            }
            MessageBox.Show(res, "Frequencies");

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

        private void gammaClick(object sender, RoutedEventArgs e)
        {
            if (contentTextBox.Text != string.Empty)
            {
                string gamma = Lab3Controler.GenerateGamma(contentTextBox.Text.Length, (bool)enRadioButton.IsChecked);
                MessageBoxCustom message = new MessageBoxCustom(gamma, "Generated gamma");
                message.ShowDialog();
                
            }
        }

        private void printClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("— — — Send to processing — — —");
        }

        private void encodeClick(object sender, RoutedEventArgs e)
        {
            Lab2Contoller controller;
            string choice = methodsList.Text;
            switch (choice)
            {
                case "Vizhener":
                    InputFilename input = new InputFilename((bool)enRadioButton.IsChecked);
                    input.ShowDialog();
                    Key = input.KeyValueTextBox.Text;
                    controller = new Lab2Contoller(Key);
                    contentTextBox.Text = controller.EncodeVizhener(contentTextBox.Text, (bool)enRadioButton.IsChecked);
                    break;
                case "Linear":
                    InputLinear input1 = new InputLinear();
                    input1.ShowDialog();
                    A = Convert.ToInt32(input1.coeffATextBox.Text);
                    B = Convert.ToInt32(input1.coeffBTextBox.Text);
                    controller = new Lab2Contoller(A, B);
                    contentTextBox.Text = controller.Encode(contentTextBox.Text, true, (bool)enRadioButton.IsChecked);
                    break;
                case "NonLinear":
                    InputNonLinear input2 = new InputNonLinear();
                    input2.ShowDialog();
                    A = Convert.ToInt32(input2.coeffATextBox.Text);
                    B = Convert.ToInt32(input2.coeffBTextBox.Text);
                    C = Convert.ToInt32(input2.coeffcTextBox.Text);
                    controller = new Lab2Contoller(A, B, C);
                    contentTextBox.Text = controller.Encode(contentTextBox.Text, false, (bool)enRadioButton.IsChecked);
                    break;
                case "Gamma":
                    InputFilename input3 = new InputFilename((bool)enRadioButton.IsChecked);
                    input3.ShowDialog();
                    Key = input3.KeyValueTextBox.Text;
                    Lab3Controler lab3Controler = new Lab3Controler(Key);
                    contentTextBox.Text = lab3Controler.EncodeUnicode(contentTextBox.Text, (bool)enRadioButton.IsChecked);
                    break;
            }

        }

        private void decodeClick(object sender, RoutedEventArgs e)
        {
            Lab2Contoller controller;
            string choice = methodsList.Text;
            switch (choice)
            {
                case "Vizhener":
                    InputFilename input = new InputFilename((bool)enRadioButton.IsChecked);
                    input.ShowDialog();
                    Key = input.KeyValueTextBox.Text;
                    controller = new Lab2Contoller(Key);
                    contentTextBox.Text = controller.DecodeVizhener(contentTextBox.Text, (bool)enRadioButton.IsChecked);
                    break;
                case "Linear":
                    InputLinear input1 = new InputLinear();
                    input1.ShowDialog();
                    A = Convert.ToInt32(input1.coeffATextBox.Text);
                    B = Convert.ToInt32(input1.coeffBTextBox.Text);
                    controller = new Lab2Contoller(A, B);
                    contentTextBox.Text = controller.Decode(contentTextBox.Text, true, (bool)enRadioButton.IsChecked);
                    break;
                case "NonLinear":
                    InputNonLinear input2 = new InputNonLinear();
                    input2.ShowDialog();
                    A = Convert.ToInt32(input2.coeffATextBox.Text);
                    B = Convert.ToInt32(input2.coeffBTextBox.Text);
                    C = Convert.ToInt32(input2.coeffcTextBox.Text);
                    controller = new Lab2Contoller(A, B, C);
                    contentTextBox.Text = controller.Decode(contentTextBox.Text, false, (bool)enRadioButton.IsChecked);
                    break;
                case "Gamma":
                    InputFilename input3 = new InputFilename((bool)enRadioButton.IsChecked);
                    input3.ShowDialog();
                    Key = input3.KeyValueTextBox.Text;
                    Lab3Controler lab3Controler = new Lab3Controler(Key);
                    contentTextBox.Text = lab3Controler.EncodeUnicode(contentTextBox.Text, (bool)enRadioButton.IsChecked);
                    break;
            }

        }

        private void exitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
