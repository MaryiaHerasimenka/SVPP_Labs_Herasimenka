using System;
using System.ComponentModel;

namespace HorseRaceControlLibrary
{
    public class Horse : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private double speed;

        public double X
        {
            get { return x; }
            set
            {
                x = value;
                OnPropertyChanged("X");
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                y = value;
                OnPropertyChanged("Y");
            }
        }

        public double Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                OnPropertyChanged("Speed");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Move()
        {
            
            X += Speed; 
        }

        public void Reset()
        {
            X = 0;
            Y = 0;
            Speed = new Random().Next(5, 15); 
        }

        public string GetPositionInfo()
        {
            return $"Position: X={X}, Y={Y}";
        }

        public string GetSpeedInfo()
        {
            return $"Speed: {Speed}";
        }
    }
}
