using System.Windows;
using System.IO;
using System;
using System.Windows.Input;
namespace Lab2View
{
    /// <summary>
    /// Interaction logic for CipherPad.xaml
    /// </summary>
    public partial class CipherPad : Window
    {
        public CipherPad()
        {
            InitializeComponent();
            exitWindow.Click += exitWindow_Click;
        }

        public static void CreatePad(string path, int gammaLength, int count = 0, bool isEnglish = true)
        {
            string fullPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @$"\{path}";
            try
            {
                if (Directory.Exists(fullPath))
                {
                    MessageBox.Show("Such pad is already exist");
                    return;
                }
                Directory.CreateDirectory(fullPath);

            }
            catch (Exception e)
            {
                Console.WriteLine("{The process failed: {0}", e.ToString());
            }
            for (int i = 0; i < count; ++i)
            {
                using StreamWriter sw = File.CreateText(fullPath + @$"\Page{i + 1}.txt");
                sw.WriteLine(Lab3.Lab3Controler.GenerateGamma(gammaLength, isEnglish));
            }
        }

        private void exitWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
