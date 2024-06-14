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

namespace BD_Lab6_Herasimenka
{
    public partial class EditTrackWindow : Window
    {
        public Track Track { get; set; }

        public EditTrackWindow(Track track)
        {
            InitializeComponent();
            Track = track;
            DataContext = Track;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Track.Update();
            DialogResult = true;
            Close();
        }
    }
}