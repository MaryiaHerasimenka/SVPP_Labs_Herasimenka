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
using System.Collections.ObjectModel;
using System.Windows;


namespace BD_Lab6_Herasimenka
{
    public partial class MainWindow : Window
    {

        ObservableCollection<Track> Tracks;
        public MainWindow()
        {
            Tracks = new ObservableCollection<Track>();
            InitializeComponent();
            lBox.DataContext = Tracks;
            FillData();
        }
        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            FillData();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddTrackWindow addTrackWindow = new AddTrackWindow();
            addTrackWindow.ShowDialog();
            FillData();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var track = (Track)lBox.SelectedItem;
            if (track != null)
            {
                var editWindow = new EditTrackWindow(track);
                if (editWindow.ShowDialog() == true)  
                {
                    FillData();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите трек для изменения.");
            }
        }

        private void FillData()
        {
            Tracks.Clear();
            foreach (var item in Track.GetAllTracks())
            {
                Tracks.Add(item);
            }
        }


        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            var trackId = ((Track)lBox.SelectedItem).TrackID;
            Track.Delete(trackId);
            FillData();
        }
    }
}