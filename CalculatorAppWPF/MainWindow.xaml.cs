using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace CalculatorAppWPF
{

    public partial class Calculator : Window
    {
        double firstValue, secondValue;
        String op;
        int counter = 0;
        public Calculator()
        {
            InitializeComponent();
            //получение даты
        //   DateTime currentDate= DateTime.Now;
        //   labelSum.Text=currentDate.ToString();
        }
       
        private void Operation_Click(object sender, RoutedEventArgs e)
        {//
            Button btnOp = (Button)sender;
            try
            {
                firstValue = Convert.ToDouble(calcDisplay.Text);
                op = (string)btnOp.Content;
                calcDisplay.Text = "";
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void oneDivX_Click(object sender, RoutedEventArgs e)
        {
            double oneDivX = Convert.ToDouble(calcDisplay.Text);
            oneDivX = 1 / oneDivX;
            calcDisplay.Text=Convert.ToString(oneDivX);
        }
        private void sqrt_Click(object sender, RoutedEventArgs e)
        {
            double sqrt = Convert.ToDouble(calcDisplay.Text);
            sqrt = Math.Sqrt(sqrt);
            calcDisplay.Text = Convert.ToString(sqrt);
        }
        private void sin_Click(object sender, RoutedEventArgs e)
        {
            double sin = Convert.ToDouble(calcDisplay.Text);
            sin = Math.Sin(sin);
            calcDisplay.Text = Convert.ToString(sin);
        }
        private void cos_Click(object sender, RoutedEventArgs e)
        {
            double cos = Convert.ToDouble(calcDisplay.Text);
            cos = Math.Cos(cos);
            calcDisplay.Text = Convert.ToString(cos);
        }
        private void tan_Click(object sender, RoutedEventArgs e)
        {
            double tan = Convert.ToDouble(calcDisplay.Text);
            tan = Math.Tan(tan);
            calcDisplay.Text = Convert.ToString(tan);
        }
        private void Euqual_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                secondValue = Convert.ToDouble(calcDisplay.Text);
           
            switch (op)
            {
                case "+":
                    calcDisplay.Text = Convert.ToString((firstValue + secondValue));
                    counter++;
                    labelSum.Text = counter.ToString();

                    break;
                case "-":
                    calcDisplay.Text = Convert.ToString((firstValue - secondValue));
                    break;
                case "×":
                    calcDisplay.Text = (Convert.ToString(firstValue * secondValue));
                    break;
                case "÷":
                        if (secondValue == 0) {
                            MessageBox.Show("Divide by zero exception");
                            break;
                            //throw new DivideByZeroException("Divide by zero");
                            //break;
                        }
                    calcDisplay.Text = Convert.ToString((firstValue / secondValue));  
                    break;
                case "x^n":
                    calcDisplay.Text = Convert.ToString(Math.Pow(firstValue, secondValue));
                    break;
                default:
                    break;


            }
        }
        catch(Exception ex){
            MessageBox.Show(ex.Message);
           }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            calcDisplay.Text = "";
        }

        private void Num_Click(object sender, RoutedEventArgs e)
        {
            Button num = (Button) sender;
            if (calcDisplay.Text == "0")
                calcDisplay.Text = "";
            else
                calcDisplay.Text += num.Content;
        }

        

    }
}