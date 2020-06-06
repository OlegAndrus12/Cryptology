using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RSA;

namespace RSAView
{
    /// <summary>
    /// Interaction logic for Generator.xaml
    /// </summary>
    
    public partial class Generator : Window
    {
        public int P;
        public int Q;
        public int N;
        public int M;
        public int D;
        public int E;

        public Generator()
        {
            InitializeComponent();
            calcE.Click += InitCoeff;
            calcKeys.Click += OnChangedItem;
        }

        private void OnChangedItem(object sender, RoutedEventArgs e)
        {
            E = Convert.ToInt32(EList.Text);
            D = RSAController.CalculateD(E, M);
            openedKey.Content = $"<E = {E}, N = {N}>";
            closedKey.Content = $"<D = {D}, N = {N}>";
        }

        private void InitCoeff(object sender, RoutedEventArgs e)
        {
            P = Convert.ToInt32(Pcoeff.Text);
            Q = Convert.ToInt32(Qcoeff.Text);
            M = (P - 1) * (Q - 1);
            N = P * Q;
            EList.ItemsSource = RSAController.CalculateE(M);
        }

    }
}
