using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GraphicsEditor_SVPP_Lab_3_Herasimenka
{
    public partial class MainWindow : Window
    {
        public static RoutedCommand ClearCommand = new RoutedCommand();
        public static RoutedCommand ExitCommand = new RoutedCommand();

        FigureParameters figure;

        public MainWindow()
        {
            InitializeComponent();
            CommandBinding binding = new CommandBinding(ApplicationCommands.Save);
            binding.Executed += SaveCommand_Executed;
            binding.CanExecute += SaveCommand_CanExecute;
            this.CommandBindings.Add(binding);
            CommandBinding binding1 = new CommandBinding(ApplicationCommands.Open);
            binding1.Executed += LoadCommand_Executed;
            this.CommandBindings.Add(binding1);
            CommandBinding binding2 = new CommandBinding(ClearCommand);
            binding2.Executed += ClearCommand_Executed;
            this.CommandBindings.Add(binding2);

            InputBindings.Add(new KeyBinding(ClearCommand, Key.Delete, ModifierKeys.Control));
            
            figure = new FigureParameters();

        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(DrawingCanvas);
            DrawStar(position);
            UpdateStatus(position);
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point position = e.GetPosition(DrawingCanvas);
            UpdateStatus(position);
        }

        private void DrawStar(Point position)
        {
            Polygon star = new Polygon
            {
                Stroke = new SolidColorBrush(figure.LineColor),
                StrokeThickness = figure.LineThickness,
                Fill = new SolidColorBrush(figure.BackgroundColor),
                Points = CalculateStarPoints(position, 5, 30, 10) // 5 лучей, радиус 30, радиус внутреннего круга 10
            };
            DrawingCanvas.Children.Add(star);
        }

        private PointCollection CalculateStarPoints(Point center, int numPoints, double outerRadius, double innerRadius)
        {
            PointCollection points = new PointCollection();
            double angleStep = Math.PI / numPoints;
            for (int i = 0; i < 2 * numPoints; i++)
            {
                double angle = i * angleStep;
                double radius = i % 2 == 0 ? outerRadius : innerRadius;
                points.Add(new Point(center.X + radius * Math.Sin(angle), center.Y - radius * Math.Cos(angle)));
            }
            return points;
        }
        private void OpenSettingsDialog(object sender, RoutedEventArgs e)
        {
            try
            {
                SettingsDialog dialog = new SettingsDialog(figure);
                if (dialog.ShowDialog() == true)
                {
                    //figure.LineThickness = dialog.LineThickness;
                    //figure.LineColor = dialog.SelectedLineColor;
                    //figure.BackgroundColor = dialog.SelectedBackgroundColor;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        //private void OpenLineThicknessDialog(object sender, RoutedEventArgs e)
        //{

        //    LineThicknessDialog dialog = new LineThicknessDialog(figure);
        //    dialog.ShowDialog();

        //}
        private void OpenLineThicknessDialog(object sender, RoutedEventArgs e)
    {
        try
        {
            LineThicknessDialog dialog = new LineThicknessDialog(figure);
            if (dialog.ShowDialog() == true)
            {
             //   figure.LineThickness = dialog.LineThickness;
            }
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void OpenLineColorDialog(object sender, RoutedEventArgs e)
        {
            try
            {
                ColorDialog dialog = new ColorDialog(figure,true);
            if (dialog.ShowDialog() == true)
            {
              //  figure.LineColor = dialog.SelectedColor;
            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void OpenBackgroundColorDialog(object sender, RoutedEventArgs e)
        {
            try
            {
                ColorDialog dialog = new ColorDialog(figure,false);
            if (dialog.ShowDialog() == true)
            {
          //      figure.BackgroundColor = dialog.SelectedColor;
            }
        }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
}

        private void OpenAboutDialog(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("GraphicsEditor_SVPP_Lab_3_Herasimenka\nVersion 1.0", "About");
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Data file| *.dat | All files| *.* "; 
            if (saveFileDialog.ShowDialog() == true)
            {
                List<StarData> stars = new List<StarData>();
                foreach (var child in DrawingCanvas.Children)
                {
                    if (child is Polygon star)
                    {
                        stars.Add(new StarData
                        {
                            Points = star.Points,
                            LineColor = ((SolidColorBrush)star.Stroke).Color,
                            BackgroundColor = ((SolidColorBrush)star.Fill).Color,
                            LineThickness = star.StrokeThickness
                        });
                    }
                }
                string json = JsonSerializer.Serialize(stars);
                File.WriteAllText(saveFileDialog.FileName, json);
                Title = saveFileDialog.FileName;
            }
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = DrawingCanvas.Children.Count > 0;
        }

        private void LoadCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string json = File.ReadAllText(openFileDialog.FileName);
                List<StarData> stars = JsonSerializer.Deserialize<List<StarData>>(json);
                DrawingCanvas.Children.Clear();
                foreach (var starData in stars)
                {
                    Polygon star = new Polygon
                    {
                        Points = starData.Points,
                        Stroke = new SolidColorBrush(starData.LineColor),
                        Fill = new SolidColorBrush(starData.BackgroundColor),
                        StrokeThickness = starData.LineThickness
                    };
                    DrawingCanvas.Children.Add(star);
                }
                Title = openFileDialog.FileName;
            }
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            DrawingCanvas.Children.Clear();
        }
        private void ClearCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DrawingCanvas.Children.Clear();
        }
        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void UpdateStatus(Point position)
        {
            MouseCoordinates.Text = $"X: {position.X}, Y: {position.Y}";
        }
    }

    public class StarData
    {
        public PointCollection Points { get; set; }
        public Color LineColor { get; set; }
        public Color BackgroundColor { get; set; }
        public double LineThickness { get; set; }
    }
}