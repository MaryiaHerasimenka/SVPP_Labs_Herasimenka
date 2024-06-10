using System.Windows;
using System.Threading;
using HorseRaceControlLibrary;

namespace GameAppHerasimenka
{
    public partial class MainWindow : Window
    {
        private bool isRunning = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            isRunning = true;
            Thread thread = new Thread(RunGame);
            thread.Start();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            isRunning = false;
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            isRunning = false;
            horseRaceControl.ResetGame();
        }

        private void RunGame()
        {
            while (isRunning)
            {
                Dispatcher.Invoke(() =>
                {
                    horseRaceControl.MoveHorses();
                });
                Thread.Sleep(1000); 
            }
        }
    }
}
