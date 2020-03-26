using System.Windows;
using Lab1Control;
using System;
using System.IO;
using Microsoft.Win32;
using System.Printing;

namespace Lab1View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int Key;
        public MainWindow()
        {
           
            InitializeComponent();
            openBtn.Click += openFileClick;
            exitBtn.Click += exitClick;
            saveBtn.Click += saveClick;
            encodeBtn.Click += encodeClick;
            aboutBtn.Click += aboutUsClick;
            decodeBtn.Click += decodeClick;
            
        }

        private void openFileClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text file (*.txt) |*.txt";
            openFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                contentTextBox.Text = File.ReadAllText(openFileDialog.FileName);
                filenameLabel.Content = openFileDialog.FileName;
            }
        }

        private void aboutUsClick (object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Designed by Oleh Andrus \n2019 \nAll rights reserved");
        }

        private void saveClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt) |*.txt";
            saveFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            if(saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, contentTextBox.Text);
            }
            
        }


        private void encodeClick(object sender, RoutedEventArgs e)
        {
            InputFilename input = new InputFilename();
            input.ShowDialog();
            Key = Convert.ToInt32(input.KeyValueTextBox.Text);
            MainWindowController controller = new MainWindowController(Key);
            contentTextBox.Text = controller.Encode(contentTextBox.Text);           
        }

        private void decodeClick(object sender, RoutedEventArgs e)
        {
            MainWindowController controller = new MainWindowController(Key);
            contentTextBox.Text = controller.Decode(contentTextBox.Text);
        }

        private void exitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
