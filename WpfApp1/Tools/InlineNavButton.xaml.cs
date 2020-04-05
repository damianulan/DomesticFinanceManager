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
    /// Interaction logic for InlineNavButton.xaml
    /// </summary>
    public partial class InlineNavButton : UserControl
    {

        public InlineNavButton()
        {
            InitializeComponent();
        }

        public MaterialDesignThemes.Wpf.PackIconKind IconKind
        {
            get { return Icon.Kind; }  
            set { Icon.Kind = value; } 
        }

        public object Text
        {
            get { return LabelContent.Content; }
            set { LabelContent.Content = value; }
        }

        private void InlineButton_MouseMove(object sender, MouseEventArgs e)
        {
            InlineButton.Background = HexColor.DarkGrey;
            Icon.Foreground = HexColor.Orange;
            LabelContent.Foreground = HexColor.Orange;
            
        }

        private void InlineButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InlineButton.Background = HexColor.Black;
            Icon.Foreground = HexColor.White;
            LabelContent.Foreground = HexColor.White;
        }

    }
}
