using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GraphicsEditor_SVPP_Lab_3_Herasimenka
{ 
 public partial class LineThicknessDialog : Window
{
    public double LineThickness { get; private set; }

    public LineThicknessDialog(double currentThickness)
    {
        InitializeComponent();
        ThicknessSlider.Value = currentThickness;
    }

    private void ok_Button_Click(object sender, RoutedEventArgs e)
    {
        LineThickness = ThicknessSlider.Value;
        DialogResult = true;
        Close();
    }
        private void ThicknessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (PreviewLine != null)
            {
                PreviewLine.StrokeThickness = e.NewValue;
            }
        }
    }
}
