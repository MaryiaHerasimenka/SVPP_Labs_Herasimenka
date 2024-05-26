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
    public partial class ColorDialog : Window
    {
        public Color SelectedColor { get; private set; }

        public ColorDialog(Color initialColor)
        {
            InitializeComponent();
            ColorPicker.SelectedColor = initialColor;
        }

        private void ok_Button_Click(object sender, RoutedEventArgs e)
        {
            SelectedColor = ColorPicker.SelectedColor.Value;
            DialogResult = true;
            Close();
        }
    }
}
