using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace HorseRaceControlLibrary
{
    public partial class HorseRaceControl : UserControl
    {
        public List<Horse> Horses { get; set; }

        public HorseRaceControl()
        {
            InitializeComponent();
            Horses = new List<Horse>();  
            DataContext = this;

   
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                Horses.Add(new Horse
                {
                    X = 0,
                    Y = i * 60,
                    Speed = random.Next(5, 15) 
                });
            }
        }

        public void MoveHorses()
        {
            foreach (var horse in Horses)
            {
                horse.Move();  
            }
        }

        public void ResetGame()
        {
            foreach (var horse in Horses)
            {
                horse.Reset(); 
            }
        }

        private void HorseRectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Rectangle horseRectangle && horseRectangle.DataContext is Horse horse)
            {
                MessageBox.Show(horse.GetPositionInfo());
            }
        }

        private void HorseRectangle_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Rectangle horseRectangle && horseRectangle.DataContext is Horse horse)
            {
                MessageBox.Show(horse.GetSpeedInfo());
            }
        }
    }
}
