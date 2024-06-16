using System.Data.Entity;
using System.Windows;

namespace BD_Lab7_Herasimenka
{
    public partial class MainWindow : Window
    {
        TrackContext context;

        public MainWindow()
        {
            InitializeComponent();
            context = new TrackContext("TestDbConnection");
            DataContext = context; 
            InitTrackList();
        }
        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    string result = DatabaseHelper.CheckDatabaseConnection();
        //    MessageBox.Show(result, "Database Connection Status", MessageBoxButton.OK, MessageBoxImage.Information);
        //}
        private void InitTrackList()
        {
            context.Tracks.Load();
            dGrid.DataContext = context.Tracks.Local; 
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newTrack = new Track();
            var editWindow = new EditTrackWindow(newTrack);
            if (editWindow.ShowDialog() == true)
            {
                context.Tracks.Add(newTrack);
                context.SaveChanges();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var track = (Track)dGrid.SelectedItem;
            if (track != null)
            {
                var editWindow = new EditTrackWindow(track);
                if (editWindow.ShowDialog() == true)
                {
                    context.SaveChanges();
                }
                else
                {
                    context.Entry(track).Reload();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите трек для изменения.");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены?", "Удалить запись", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var track = (Track)dGrid.SelectedItem;
                if (track != null)
                {
                    context.Tracks.Remove(track);
                    context.SaveChanges();
                }
            }
        }


        private void dGrid_LoadingRow(object sender, System.Windows.Controls.DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
    }
}
