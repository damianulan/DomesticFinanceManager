using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Tools
{
    /// <summary>
    /// Interaction logic for IconButton.xaml
    /// It serves check-box style icon based buttons
    /// </summary>
    public partial class IconButton : UserControl
    {
        public IconButton()
        {
            InitializeComponent();
        }

        public MaterialDesignThemes.Wpf.PackIconKind IconKind
        {
            get { return Icon.Kind; }
            set { Icon.Kind = value; }
        }

        int i = 0;
        private void InlineButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(i == 0)
            {
                Icon.Foreground = HexColor.Orange;
                i++;
            }
            else if(i == 1)
            {
                Icon.Foreground = HexColor.White;
                i--;
            }

        }
    }
}
