using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;

namespace LB2_SVPP
{
    public class Values
    {
        public double xStart { get; set; }
        public double xStop { get; set; }
        public double stepValue { get; set; }
        private int n;
        public int nIteration {
            get { return n; }
            set {
                if (value <= 5)
                    throw new ArgumentException("Значение должно быть больше 5");
                else
                    n = value;

            }
            //double resY;
            //double resS;
        }
      
    }
   
    public partial class MainWindow : Window
    {
        Values values;
        public MainWindow()
        {
            InitializeComponent();
            Values values = new Values();
            grid.DataContext = values;

        }

        private void Button_Click_Calculate(object sender, RoutedEventArgs e)
        {
            //resY
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            Button buttonClear = (Button)sender;
            xStartTB.Clear();
            xStopTB.Clear();
            stepV.Clear();
            nIt.Clear();
        }

        private void outputResultWin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}