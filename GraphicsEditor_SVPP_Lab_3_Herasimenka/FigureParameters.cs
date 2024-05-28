using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GraphicsEditor_SVPP_Lab_3_Herasimenka
{
    public class FigureParameters
    {
        private Color lineColor = Colors.Black;
        private Color backgroundColor = Colors.White;
        private double lineThickness = 2.0;

        public Color LineColor { get => lineColor; set => lineColor = value; }
        public Color BackgroundColor { get => backgroundColor; set => backgroundColor = value; }
        public double LineThickness { get => lineThickness; set => lineThickness = value; }
    }
}
