using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp1
{
    class HexColor
    {
        public static SolidColorBrush Orange = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D66D0C"));
        public static SolidColorBrush White = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFEEEEEE"));
        public static SolidColorBrush Black = (SolidColorBrush)(new BrushConverter().ConvertFrom("#222"));
        public static SolidColorBrush DarkGrey = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF1F1E1E"));

    }
}
