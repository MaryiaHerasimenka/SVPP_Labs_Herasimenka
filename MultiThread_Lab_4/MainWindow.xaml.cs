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

namespace MultiThread_Lab_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OpenSParametresDialog(object sender, RoutedEventArgs e)
        {
            try
            {
                SettingsDialog dialog = new SettingsDialog(figure);
                if (dialog.ShowDialog() == true)
                {
                    //figure.LineThickness = dialog.LineThickness;
                    //figure.LineColor = dialog.SelectedLineColor;
                    //figure.BackgroundColor = dialog.SelectedBackgroundColor;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }

}