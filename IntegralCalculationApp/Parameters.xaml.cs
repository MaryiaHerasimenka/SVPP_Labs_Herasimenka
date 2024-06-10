using System;
using System.Windows;

namespace IntegralCalculationApp
{
    public partial class Parameters : Window
    {
        public Parameters()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(parA.Text, out double a) &&
                double.TryParse(parB.Text, out double b) &&
                int.TryParse(parN.Text, out int n))
            {
                InputParameters.A = a;
                InputParameters.B = b;
                InputParameters.N = n;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Введите корректные значения.");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            parA.Clear();
            parB.Clear();
            parN.Clear();
        }
    }
}
