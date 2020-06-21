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
using System.Data.SqlClient;
using System.Globalization;

namespace WpfApp1.SubControls
{
    /// <summary>
    /// Interaction logic for ReceiptViewControl.xaml
    /// </summary>
    public partial class ReceiptViewControl : UserControl
    {
        private static readonly List<int> Expandity = new List<int>(); // for control visibility check when CategoryBox Selection Changes

        private static readonly List<int> CategoryIds = new List<int>();

        public ReceiptViewControl()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            SqlDataReader dr1 = Database.Select("SELECT id_category, name, expand FROM Category ORDER BY id_category;");
            while (dr1.Read())
            {
                CategoryIds.Add(Convert.ToInt32(dr1["id_category"]));
                Expandity.Add(Convert.ToInt32(dr1["expand"]));
                CategoryBox.Items.Add(dr1["name"].ToString());
            }

        }

        private String CategoryInstruction()
        {
            String instruction = "";
            if(CategoryBox.SelectedIndex > 0)
            {
                int index = CategoryBox.SelectedIndex - 1;
                instruction = "category_id = " + CategoryIds[index];
            }
            return instruction;
        }

        private void NameListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string query = "";
            if (CategoryBox.SelectedIndex < 1)
                query = "SELECT date, total_price, discount, repeat, dateofcreation, category_id FROM Spending where name like '" + NameListBox.SelectedValue + "';";
            else
                query = "SELECT date, total_price, discount, repeat, dateofcreation, category_id FROM Spending where " + CategoryInstruction() + "AND name like '" + NameListBox.SelectedValue + "';";
            SqlDataReader dr2 = Database.Select(query);
            while (dr2.Read())
            {

                DateTime date = Convert.ToDateTime(dr2["date"].ToString());
                DateLabel.Content = date.Date;
                TotalLabel.Content = dr2["total_price"].ToString() + " PLN";
                DiscountLabel.Content = dr2["discount"].ToString() + " PLN";
            }
            SqlDataReader dr1 = Database.Select("SELECT Category.name, Category.expand, Spending.repeat, Spending.Id_spending FROM Spending INNER JOIN Category ON Spending.category_id = Category.id_category where Spending.name like '" + NameListBox.SelectedValue + "';");
            while (dr1.Read())
            {
                int expand = Convert.ToInt32(dr1["expand"].ToString());
                int repeat = Convert.ToInt32(dr1["repeat"].ToString());
                int id_spending = Convert.ToInt32(dr1["Id_spending"].ToString());
                if (expand < 1)
                {
                    RepeatanceGrid.Visibility = Visibility.Visible;
                    ProductView.Visibility = Visibility.Hidden;
                    DetailsLabel.Visibility = Visibility.Hidden;
                    if (repeat == 0)
                        RepeatanceBox.Text = "None";
                    else if (repeat == 1)
                        RepeatanceBox.Text = "Day";
                    else if (repeat == 7)
                        RepeatanceBox.Text = "Week";
                    else if (repeat == 30)
                        RepeatanceBox.Text = "Month";

                }
                else
                {
                    ProductView.Items.Clear();

                    RepeatanceGrid.Visibility = Visibility.Hidden;
                    ProductView.Visibility = Visibility.Visible;
                    DetailsLabel.Visibility = Visibility.Visible;

                    int id = 1;
                    SqlDataReader dr3 = Database.Select("SELECT quantity, name, Id_product FROM Spending_Product INNER JOIN Product ON Spending_Product.product_id = Product.Id_product WHERE spending_id = '" + id_spending + "';");
                    while (dr3.Read())
                    {
                        int quantity = Convert.ToInt32(dr3["quantity"].ToString());
                        int id_product = Convert.ToInt32(dr3["Id_product"].ToString());
                        string name = dr3["name"].ToString();
                        decimal price = 0;
                        SqlDataReader dr4 = Database.Select("SELECT TOP 1 Price.value FROM Price JOIN Product ON Price.product_id = Product.Id_product WHERE Product.Id_product = " + id_product + " ORDER BY Price.date DESC;");
                        while (dr4.Read())
                        {
                            price = Convert.ToDecimal(dr4["value"].ToString());
                        }
                            ProductView.Items.Add(new Constructors.ListViewItemCustom { No = id, Quantity = quantity, Name = name, Price = (price * quantity) });

                        id++;
                    }
                }
            }
        }

        private void CategoryBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NameListBox.Items.Count > 0)
                NameListBox.Items.Clear();
            string query = "";
            if (CategoryBox.SelectedIndex < 1)
                query = "SELECT name, date, total_price, discount, repeat, dateofcreation, category_id FROM Spending;";
            else
                query = "SELECT name, date, total_price, discount, repeat, dateofcreation, category_id FROM Spending where " + CategoryInstruction() + ";";
            SqlDataReader dr2 = Database.Select(query);
            if (dr2.HasRows)
            {
                while (dr2.Read())
                {
                    NameListBox.Items.Add(dr2["name"].ToString());
                }
            }
        }

        private void DeleteItem_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(NameListBox.SelectedItems.Count > 0)
            {
                string query = "SELECT Id_Spending from Spending WHERE name like '" + NameListBox.SelectedValue + "';";
                int id_spending = 0;
                SqlDataReader dr2 = Database.Select(query);
                if (dr2.HasRows)
                {
                    while (dr2.Read())
                    {
                        id_spending = Convert.ToInt32(dr2["Id_spending"].ToString());
                    }
                }
                Database.ExecSQL("DELETE FROM Spending_Product WHERE spending_id = '" + id_spending + "';");
                Database.ExecSQL("DELETE FROM Spending WHERE Id_spending = '" + id_spending + "';");
                NameListBox.Items.Remove(NameListBox.SelectedItem);
            }
                
        }
    }
}
