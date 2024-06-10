using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace IntegralCalculationApp
{
    public partial class MainWindow : Window
    {
        private BackgroundWorker backgroundWorker;

        public MainWindow()
        {
            InitializeComponent();
            backgroundWorker = (BackgroundWorker)this.Resources["worker"];
        }

        private async void btnDispatcher_Click(object sender, RoutedEventArgs e)
        {
            btnDispatcher.IsEnabled = false;
            btnBackgroundWorker.IsEnabled = false;
            btnInput.IsEnabled = false;
            resultTextBox.Clear();
            progressBar.Value = 0;

            await CalculateWithDispatcherAsync();

            btnDispatcher.IsEnabled = true;
            btnBackgroundWorker.IsEnabled = true;
            btnInput.IsEnabled = true;
        }

        private Task CalculateWithDispatcherAsync()
        {
            var h = (InputParameters.B - InputParameters.A) / InputParameters.N;
            double result = 0;
            var step = Math.Round((double)(InputParameters.N / 100));

            return Task.Run(() =>
            {
                for (int i = 0; i <= InputParameters.N; i++)
                {
                    if (i % step == 0)
                    {
                        Dispatcher.Invoke(() =>
                        {
                            progressBar.Value = (i * 100) / InputParameters.N;
                        });
                    }

                    var x = InputParameters.A + h * i;
                    var fx = Math.Sqrt(x);
                    result += fx * h;
                }

                Dispatcher.Invoke(() =>
                {
                    resultTextBox.Text = result.ToString();
                });
            });
        }

        private void btnBackgroundWorker_Click(object sender, RoutedEventArgs e)
        {
            btnDispatcher.IsEnabled = false;
            btnBackgroundWorker.IsEnabled = false;
            btnInput.IsEnabled = false;
            resultTextBox.Clear();
            progressBar.Value = 0;

            backgroundWorker.RunWorkerAsync();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var h = (InputParameters.B - InputParameters.A) / InputParameters.N;
            double result = 0;
            var step = Math.Round((double)(InputParameters.N / 100));

            for (int i = 0; i <= InputParameters.N; i++)
            {
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                if (i % step == 0)
                {
                    backgroundWorker.ReportProgress((i * 100) / InputParameters.N);
                }

                var x = InputParameters.A + h * i;
                var fx = Math.Sqrt(x);
                result += fx * h;
            }

            e.Result = result;
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnDispatcher.IsEnabled = true;
            btnBackgroundWorker.IsEnabled = true;
            btnInput.IsEnabled = true;

            if (!e.Cancelled && e.Error == null)
            {
                resultTextBox.Text = e.Result.ToString();
            }
        }

        private void OpenParametersDialog(object sender, RoutedEventArgs e)
        {
            var parametersDialog = new Parameters();
            if (parametersDialog.ShowDialog() == true)
            {
   
            }
        }
    }
}
