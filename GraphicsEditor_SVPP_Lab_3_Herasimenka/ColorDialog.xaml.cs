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
    public partial class ColorDialog : Window
    {
        //
        public ColorDialog(FigureParameters initialColor, bool colordialogentity)//
        {
            InitializeComponent();
            //
            BindingOperations.ClearBinding(ColorPicker, ColorPicker.SelectedColorProperty);
           
            Binding binding = new Binding();


            if (colordialogentity)
                binding.Path = new PropertyPath("LineColor");
            else
                binding.Path = new PropertyPath("BackgroundColor");

            ColorPicker.SetBinding(ColorPicker.SelectedColorProperty, binding);
            ColorPicker.DataContext = initialColor;
        }

        private void ok_Button_Click(object sender, RoutedEventArgs e)
        {
            //
            DialogResult = true;
            Close();
        }
    }
}
