using Windows.System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI;

namespace ColorBinding.ViewModel
{
    class MainViewModel :INotifyPropertyChanged
    {
        private Color _color;
        private SolidColorBrush _selectColor;

        public MainViewModel()
        {
            _color = new Color();
            _color.A = 255;
        }
        public int Red {
            get => _color.R;
                
            set
            {
                _color.R = (byte)value;
                SelectedColor = new SolidColorBrush(_color);
                NotifyPropertyChanged();
                NotifyPropertyChanged("MergedDecimal");
                NotifyPropertyChanged("HexaDecimal");
            }
        }
        public int Green
        {
            get => _color.G;

            set
            {
                _color.G = (byte)value;
                SelectedColor = new SolidColorBrush(_color);
                NotifyPropertyChanged();
                NotifyPropertyChanged("MergedDecimal");
                NotifyPropertyChanged("HexaDecimal");
            }
        }
        public int Blue
        {
            get => _color.B;

            set
            {
                _color.B = (byte)value;
                SelectedColor = new SolidColorBrush(_color);
                NotifyPropertyChanged();
                NotifyPropertyChanged("MergedDecimal");
                NotifyPropertyChanged("HexaDecimal");
            }
        }
        public SolidColorBrush SelectedColor
        {
            get => _selectColor;
            set
            {
                _selectColor = value;
                NotifyPropertyChanged();
            }
        }
        public string MergedDecimal
        {
            get => string.Format("({0},{1},{2})", Red, Green, Blue);

        }
        public string HexaDecimal
        {
            get
            {
                string r = Red.ToString("X");
                string g = Green.ToString("X");
                string b = Blue.ToString("X");
                return "#" + r.PadLeft(2, '0') + g.PadLeft(2, '0') + b.PadLeft(2, '0');
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
