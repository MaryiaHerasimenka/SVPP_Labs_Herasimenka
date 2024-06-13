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
    public partial class AddTrackWindow : Window
    {
        public AddTrackWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var track = new Track
            {
                TrackTitle = txtTrackTitle.Text,
                TrackDuration = TimeSpan.Parse(txtTrackDuration.Text), // Преобразуйте строку в TimeSpan
                ArtistName = txtArtistName.Text,
                AlbumTitle = txtAlbumTitle.Text
            };
            track.Insert();
            this.Close(); // Закрыть окно после добавления
        }
    }
}
