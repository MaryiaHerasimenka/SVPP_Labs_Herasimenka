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
using Xceed.Wpf.Toolkit;

namespace GraphicsEditor_SVPP_Lab_3_Herasimenka
{
    /// <summary>
    /// Interaction logic for SettingsDialog.xaml
    /// </summary>
    public partial class SettingsDialog : Window
    {
        public double LineThickness { get; private set; }
        public Color SelectedLineColor { get; private set; }
        public Color SelectedBackgroundColor { get; private set; }

        public SettingsDialog(Color initialLineColor, Color initialBackgroundColor, FigureParameters currentThickness)
        {
            InitializeComponent();
            ColorPickerLine.SelectedColor = initialLineColor;
            ColorPickerBackground.SelectedColor = initialBackgroundColor;
            ThicknessSlider.DataContext = currentThickness;
        }

        private void ok_Button_Click(object sender, RoutedEventArgs e)
        { 

            LineThickness = ThicknessSlider.Value;
            SelectedLineColor = ColorPickerLine.SelectedColor.Value;
            SelectedBackgroundColor = ColorPickerBackground.SelectedColor.Value;
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
