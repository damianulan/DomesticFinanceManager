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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for ReceiptControl.xaml
    /// </summary>
    public partial class ReceiptControl : UserControl
    {
        public ReceiptControl()
        {
            InitializeComponent();
        }

        UserControl usc;
        private void ViewBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            GridMain.Children.Clear();
            usc = new SubControls.ReceiptViewControl();
            GridMain.Children.Add(usc);
        }

        private void AddBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GridMain.Children.Clear();
            usc = new SubControls.ReceiptAddControl();
            GridMain.Children.Add(usc);
        }
    }
}
