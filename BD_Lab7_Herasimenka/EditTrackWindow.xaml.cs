using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BD_Lab7_Herasimenka
{
    public partial class EditTrackWindow : Window
    {
        Track track;

        public EditTrackWindow()
        {
            InitializeComponent();

        }
        public EditTrackWindow(Track track) : this()
        {
            this.track = track;
            grid.DataContext = track;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Close();
        }
    }
}