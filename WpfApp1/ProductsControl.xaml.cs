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
using System.Data.SqlClient;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for ProductsControl.xaml
    /// </summary>
    public partial class ProductsControl : UserControl
    {

        private static readonly List<int> MarketIds = new List<int>();
        public static int id_product = 0;

        public ProductsControl()
        {
            InitializeComponent();

            // Populating MarketTextBox
            SqlDataReader dr2 = Database.Select("SELECT id_market, name FROM Market ORDER BY id_market;");
            while (dr2.Read())
            {
                MarketIds.Add(Convert.ToInt32(dr2["id_market"]));
                MarketTextBox.Items.Add(dr2["name"].ToString());
            }

            MarketTextBox.SelectedIndex = 0;
        }

        private void NameListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            string query = "SELECT Id_product, name, date FROM Product where name like '" + NameListBox.SelectedValue + "';";
            SqlDataReader dr2 = Database.Select(query);
            while (dr2.Read())
            {
                id_product = Convert.ToInt32(dr2["Id_product"].ToString());
                DateTime date = Convert.ToDateTime(dr2["date"].ToString());
                DateLabel.Content = date.Date;
            }
            string query2 = "SELECT TOP 1 Price.value FROM Price JOIN Product ON Price.product_id = Product.Id_product WHERE Product.Id_product = " + id_product + " ORDER BY Price.date DESC;";
            SqlDataReader dr3 = Database.Select(query2);
            while (dr3.Read())
            {
                PriceLabel.Content = dr3["value"].ToString() + " PLN";
            }
        }

        private void CategoryBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NameListBox.Items.Count > 0)
                NameListBox.Items.Clear();
            string query = "SELECT name FROM Product where market_id = " + MarketIds[MarketTextBox.SelectedIndex] + " order by id_product ASC;";
            SqlDataReader dr2 = Database.Select(query);
            while (dr2.Read())
                NameListBox.Items.Add(dr2["name"].ToString());

        }

        private void DeleteItem_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (NameListBox.SelectedItems.Count > 0)
            {
                string query = "SELECT Id_product from Product WHERE name like '" + NameListBox.SelectedValue + "';";
                int id_product = 0;
                SqlDataReader dr2 = Database.Select(query);
                if (dr2.HasRows)
                {
                    while (dr2.Read())
                    {
                        id_product = Convert.ToInt32(dr2["Id_product"].ToString());
                    }
                }
                Database.ExecSQL("DELETE FROM Price WHERE product_id = '" + id_product + "';");
                Database.ExecSQL("DELETE FROM Product WHERE Id_product = '" + id_product + "';");
                NameListBox.Items.Remove(NameListBox.SelectedItem);
            }
        }
    }
}
