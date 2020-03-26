using System.Windows;


namespace Lab2View
{
    /// <summary>
    /// Interaction logic for MessageBox.xaml
    /// </summary>
    public partial class MessageBoxCustom : Window
    {
        public MessageBoxCustom(string content, string caption)
        {
            InitializeComponent();
            title.Text = caption;        
            contentTextBox.Text = AddHyphenation(content,50);
        
        }

        public static string AddHyphenation(string text, int positionToInsert)
        {
            string res = string.Empty;
            int j = 1;
            foreach(var i in text)
            {
                res += j % positionToInsert == 0 ? '\n' : i;
                ++j;
            }
            return res;
        }
    }
}
