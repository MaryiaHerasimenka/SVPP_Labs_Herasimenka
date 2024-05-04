using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace LB2_SVPP
{
    public class Values : INotifyPropertyChanged

    {
        public double xStart
        {
            get { return xST; }
            set
            {
                xST = value;
                OnPropertyChanged("xStart");
            }
        }
        public double xStop
        {
            get { return xSP; }
            set
            {
                xSP = value;
                OnPropertyChanged("xStop");
            }
        }
        public double stepValue
        {
            get { return sV; }
            set
            {
                sV = value;
                OnPropertyChanged("stepValue");
            }
        }
        private int n;
        private double xST;
        private double xSP;
        private double sV;
        public double xNow;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public int nIteration {
            get { return n; }
            set {
                if (value <= 5)
                    throw new ArgumentException("The expected value must be greater than 5.");
                else
                    n = value;

            }

        }



    }
   
    public partial class MainWindow : Window
    {
        Values values;
        ObservableCollection<string> results;

        public MainWindow()
        {
            InitializeComponent();
            Values values = new Values();
            grid.DataContext = values;
            results = new ObservableCollection<string>();
            outputResultWin.DataContext = results;



        }

        private void Button_Click_Calculate(object sender, RoutedEventArgs e)
        {
            try
            {
                //double xST = Convert.ToDouble(xStartTB.Text);

                //results.Add(Convert.ToString(xST));
                double s = 0;

                for (double i = Convert.ToDouble(xStartTB.Text); i <= Convert.ToDouble(xStopTB.Text); i += Convert.ToDouble(stepV.Text))
                {
                    //string xSTEP = Convert.ToString(i);
                    results.Add("x=" + Convert.ToString(i));
                    //string yRES = Convert.ToString(-Math.Log(Math.Abs(2 * Math.Sin(i / 2))));
                    results.Add("Y(x)=" + Convert.ToString(-Math.Log(Math.Abs(2 * Math.Sin(i / 2)))));
                    
                    for (int k = 1; k <= Convert.ToInt32(nIt.Text); k++)
                    {
                        s += (Math.Cos(k * i)) / k;
                    }
                    //string sRES = Convert.ToString(s);
                    results.Add("S(x)=" + Convert.ToString(s));
                    s = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            Button buttonClear = (Button)sender;
            xStartTB.Clear();
            xStopTB.Clear();
            stepV.Clear();
            nIt.Clear();
            results.Clear();
        }

    }
}