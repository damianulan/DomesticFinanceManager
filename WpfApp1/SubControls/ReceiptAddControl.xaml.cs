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

namespace WpfApp1.SubControls
{
    /// <summary>
    /// Interaction logic for ReceiptAddControl.xaml
    /// </summary>
    public partial class ReceiptAddControl : UserControl
    {
        // --> PRODUCTS' DETAILS LISTS <-- CONSISTS OF DB 'SELECT' DATA
        private static readonly List<string> ProductNames = new List<string>();
        private static readonly List<int> ProductQuantities = new List<int>();
        private static readonly List<decimal> ProductPrices = new List<decimal>();
        // --> END <--
        private static readonly List<int> Expandity = new List<int>(); // for control visibility check when CategoryBox Selection Changes
        int index = 0;

        private static readonly List<int> CategoryIds = new List<int>();
        private static readonly List<int> MarketIds = new List<int>();

        private decimal PricePattern = 0; // needed for determining either user proceed with any changes
        // regarding PriceBox control. See InsertUpdateProduct() void method
        // introduced with value at ProductName_SelectionChanged(..)


        public ReceiptAddControl()
        {
            InitializeComponent();

            Load();
            
        }

        private void Load()
        {
            ProgressBarSaving.Visibility = Visibility.Hidden;

            CurrencyLabel1.Content = Properties.Settings.Default.Currency;
            CurrencyLabel2.Content = Properties.Settings.Default.Currency;
            CurrencyLabel3.Content = Properties.Settings.Default.Currency;

            SqlDataReader dr = Database.Select("SELECT COUNT(*) as count FROM Spending;");
            while (dr.Read())
                index = Convert.ToInt32(dr["count"]);
            index++;
            TitleLabel.Content = "new order #" + index.ToString();


            // Populating CategoryBox
            SqlDataReader dr1 = Database.Select("SELECT id_category, name, expand FROM Category ORDER BY id_category;");
            while (dr1.Read())
            {
                CategoryIds.Add(Convert.ToInt32(dr1["id_category"]));
                Expandity.Add(Convert.ToInt32(dr1["expand"]));
                CategoryBox.Items.Add(dr1["name"].ToString());
            }

            // Populating MarketTextBox
            SqlDataReader dr2 = Database.Select("SELECT id_market, name FROM Market ORDER BY id_market;");
            while (dr2.Read())
            {
                MarketIds.Add(Convert.ToInt32(dr2["id_market"]));
                MarketTextBox.Items.Add(dr2["name"].ToString());
            }

            CategoryBox.SelectedIndex = 0;
            MarketTextBox.SelectedIndex = 0;
        }

        private void PriceBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            bool approvedDecimalPoint = false;

            if (e.Text == ".")
            {
                if (!((TextBox)sender).Text.Contains("."))
                    approvedDecimalPoint = true;
            }

            if (!(char.IsDigit(e.Text, e.Text.Length - 1) || approvedDecimalPoint))
                e.Handled = true;
        }

        private void PriceBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if(PriceBox.Text.Length < 5)
            {
                if (PriceBox.Text.Contains("."))
                {
                    int id = PriceBox.Text.IndexOf('.');
                    int last_id = PriceBox.Text.Length - 1;
                    int counter = last_id - id;
                    if (counter < 2)
                        _ = PriceBox.Text.Insert(PriceBox.Text.Length, "0");
                    if (counter < 1)
                        _ = PriceBox.Text.Insert(PriceBox.Text.Length, "00");
                }
                else
                {
                    _ = PriceBox.Text.Insert(PriceBox.Text.Length, ".00");
                }
            }
        }
        int id = 0;
        private void AddProduct_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(ProductName.Text != "" && CategoryBox.Text != "" && PriceBox.Text != "" && QuantityBox.Text != "" && MarketTextBox.Text != "")
            {
                ProductNames.Add(ProductName.Text);
                ProductQuantities.Add(Convert.ToInt32(QuantityBox.Text));
                ProductPrices.Add(Convert.ToDecimal(PriceBox.Text));
                
                ProductView.Items.Add(new Constructors.ListViewItemCustom { No = id+1, Quantity = ProductQuantities[id], Name = ProductNames[id], Category = CategoryBox.SelectedItem.ToString(), Price = (ProductPrices[id] * ProductQuantities[id]) });
                id++;
                MarketTextBox.IsEnabled = false;
                CategoryBox.IsEnabled = false;
                InsertUpdateProduct();
            }
            SetDefaulValues();
            UpdateTotalPrice();
            ProductNamePopulator();
        }

        private void RepeatCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (RepeatCheckBox.IsChecked == true)
                RepeatanceBox.Visibility = Visibility.Visible;
            else
                RepeatanceBox.Visibility = Visibility.Hidden;
        }

        private void CategoryBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetDefaulValues();

            // Populating Product Names
            ProductNamePopulator();

            if (Expandity[CategoryBox.SelectedIndex] == 1)
            {
                RepeatGrid.Visibility = Visibility.Hidden;
                RightGrid.Visibility = Visibility.Visible;
                ExpenseTitle.Visibility = Visibility.Hidden;
                RepeatanceBox.Visibility = Visibility.Hidden;
            }

            else
            {
                RepeatGrid.Visibility = Visibility.Visible;
                RepeatanceBox.Visibility = Visibility.Hidden;
                RightGrid.Visibility = Visibility.Hidden;
                ExpenseTitle.Visibility = Visibility.Visible;
            }
        }

        private void MarketTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetDefaulValues();
            // Populating Product Names
            ProductNamePopulator();
        }

        private void InsertUpdateProduct()
        {
            // CHECKING IF NECESSARY TO INSERT PRICE DATA
            SqlDataReader dr = Database.Select("SELECT * FROM Product WHERE category_id=" + CategoryIds[CategoryBox.SelectedIndex] + " AND market_id=" + MarketIds[MarketTextBox.SelectedIndex] + " AND name LIKE '" + ProductName.Text + "';");
            if (!dr.HasRows)
            {
                string query = "INSERT INTO Product ([name], [market_id], [category_id], [date]) " +
    "VALUES('" + ProductName.Text + "', '" + MarketIds[MarketTextBox.SelectedIndex] + "', '" + CategoryIds[CategoryBox.SelectedIndex] + "', '" + DateTime.Now.ToString() + "');";
                Database.ExecSQL(query);
                InsertPriceToDB("SELECT TOP 1 Id_product FROM Product ORDER BY Id_product DESC;");
            }
            // CHECKING IF NECESSARY TO UDPATE PRICE DATA
            else
            {
                decimal mirror = Convert.ToDecimal(PriceBox.Text);
                if (mirror != PricePattern)
                    InsertPriceToDB("SELECT TOP 1 Id_product FROM Product WHERE category_id=" + CategoryIds[CategoryBox.SelectedIndex] + " AND market_id=" + MarketIds[MarketTextBox.SelectedIndex] + " AND name LIKE '" + ProductName.Text + "';");
            }

        }

        private void InsertPriceToDB(string select)
        {
            SqlDataReader dr1 = Database.Select(select);
            while (dr1.Read())
            {
                int id = Convert.ToInt32(dr1["Id_product"]);
                string query = "INSERT INTO Price ([value], [date], [product_id]) " +
    "VALUES('" + PriceBox.Text + "', '" + DateTime.Now + "', '" + id + "');";
                Database.ExecSQL(query);
            }
        }

        private void UpdateTotalPrice()
        {
            decimal sum = 0;
            for(int i=0; i<ProductPrices.Count; i++)
            {
                sum += (ProductPrices[i] * ProductQuantities[i]);
            }

            string v = sum.ToString();
            TotalBox.Text = v;
        }

        private void SetDefaulValues()
        {
            // Set default values
            ProductName.SelectedIndex = -1;
            PriceBox.Text = null;
            QuantityBox.Text = "1";
        }

        private void ProductName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ProductName.Items.Count > 0)
            {
                if(ProductName.SelectedIndex > -1)
                {
                    SqlDataReader dr1 = Database.Select("SELECT TOP 1 Price.value FROM Price JOIN Product ON Price.product_id = Product.Id_product WHERE Product.name LIKE '" + ProductName.SelectedItem.ToString() + "' AND Product.market_id=" + MarketIds[MarketTextBox.SelectedIndex] + " ORDER BY Price.date DESC;");
                    while (dr1.Read())
                        PriceBox.Text = dr1["value"].ToString();
                    PricePattern = Convert.ToDecimal(PriceBox.Text);
                }

            }
        }

        private void ApproveBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult me = MessageBox.Show("Do You wish to continue?", "Approval", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(me == MessageBoxResult.Yes)
            {
                if (DateOfReceipt.SelectedDate != null && CategoryBox.Text != "" && TotalBox.Text != "")
                {
                    ProgressBarSaving.Visibility = Visibility.Visible;
                    ProgressBarSaving.Value += 10;

                    if (DiscountBox.Text == "")
                        DiscountBox.Text = "0";

                    decimal TotalPriceNum = Convert.ToDecimal(TotalBox.Text);
                    decimal Discount = Convert.ToDecimal(DiscountBox.Text);
                    decimal TotalPriceFinal = TotalPriceNum - Discount;
                    ProgressBarSaving.Value += 10;

                    int _ = 0;
                    if (RepeatGrid.Visibility == Visibility.Visible)
                    {
                        if (RepeatCheckBox.IsChecked == true)
                        {
                            if (RepeatanceBox.SelectedIndex == 0)
                                _ = 1;
                            if (RepeatanceBox.SelectedIndex == 1)
                                _ = 7;
                            if (RepeatanceBox.SelectedIndex == 2)
                                _ = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
                            if (RepeatanceBox.SelectedIndex == 3)
                            {
                                if (DateTime.IsLeapYear(DateTime.Today.Year) == false)
                                    _ = 365;
                                else
                                    _ = 366;
                            }
                        }
                    }
                    ProgressBarSaving.Value += 10;
                    string Title;
                    if (ExpenseTitle.Text != "")
                        Title = ExpenseTitle.Text;
                    else
                    {

                        Title = CategoryBox.Text + " #" + index.ToString();
                    }

                    ProgressBarSaving.Value += 10;
                    string query = "INSERT INTO Spending ([name], [date], [total_price], [discount], [repeat], [dateofcreation], [category_id]) " +
"VALUES('" + Title + "', '" + DateOfReceipt.Text + "', '" + TotalPriceFinal.ToString() + "', '" + Discount.ToString() + "', '" + _.ToString() + "', '" + DateTime.Now.ToString() + "', '" + CategoryIds[CategoryBox.SelectedIndex] + "');";
                    Database.ExecSQL(query);
                    ProgressBarSaving.Value += 10;
                    int SpendingId = 0;
                    SqlDataReader dr1 = Database.Select("SELECT TOP 1 Id_spending FROM Spending ORDER BY Id_spending DESC;");
                    while (dr1.Read())
                        SpendingId = Convert.ToInt32(dr1["Id_spending"]);

                    ProgressBarSaving.Value += 10;
                    if (ProductView.Items.Count > 0)
                        Spending_ProductFill(SpendingId);
                    ProgressBarSaving.Value += 10;

                    MessageBox.Show("Operation succeeded!");
                    ProgressBarSaving.Value = 0;
                    Reload();
                }
                else
                    MessageBox.Show("Fill all the required fields!");
            }
        }

        private void DeleteItem_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(ProductView.SelectedItems.Count == 1)
            {
                id--;
                decimal CurrentPrice = Convert.ToDecimal(TotalBox.Text);
                decimal NewPrice = CurrentPrice - (ProductPrices[ProductView.SelectedIndex] * ProductQuantities[ProductView.SelectedIndex]);
                TotalBox.Text = NewPrice.ToString();

                ProductPrices.RemoveAt(ProductView.SelectedIndex);
                ProductNames.RemoveAt(ProductView.SelectedIndex);
                ProductQuantities.RemoveAt(ProductView.SelectedIndex);

                ProductView.Items.Remove(ProductView.SelectedItem);

                ProductView.Items.Refresh();
                
            }
        }

        // ---> POPULATORS <---

        private void ProductNamePopulator()
        {

            if(MarketTextBox.SelectedIndex > -1)
            {
                if (ProductName.HasItems)
                    ProductName.Items.Clear();
                SqlDataReader dr = Database.Select("SELECT name FROM Product WHERE category_id=" + CategoryIds[CategoryBox.SelectedIndex] + " AND market_id=" + MarketIds[MarketTextBox.SelectedIndex] + " ORDER BY id_product;");
                while (dr.Read())
                    ProductName.Items.Add(dr["name"].ToString());
            }

        }

        // --> END POPULATORS <--

        private void Spending_ProductFill(int spendingId)
        {
            List<int> ProductIds = new List<int>();

            for(int i = 0; i<ProductNames.Count; i++)
            {
                SqlDataReader dr = Database.Select("SELECT TOP 1 Id_product FROM Product WHERE category_id=" + CategoryIds[CategoryBox.SelectedIndex] + " AND market_id=" + MarketIds[MarketTextBox.SelectedIndex] + " AND name LIKE '" + ProductNames[i] + "';");
                while (dr.Read())
                    ProductIds.Add(Convert.ToInt32(dr["Id_product"]));
            }
            for(int i=0; i<ProductIds.Count; i++)
            {
                string query = "INSERT INTO Spending_Product ([spending_id], [product_id], [quantity]) " +
"VALUES('" + spendingId.ToString() + "', '" + ProductIds[i] + "', '" + ProductQuantities[i] + "');";
                Database.ExecSQL(query);
            }
        }

        private void Reload()
        {
            DateOfReceipt.SelectedDate = null;
            CategoryBox.SelectedIndex = 0;
            CategoryBox.IsEnabled = true;
            ExpenseTitle.Text = "";
            DiscountBox.Text = "";
            PriceBox.Text = "";
            MarketTextBox.SelectedIndex = 0;
            MarketTextBox.IsEnabled = true;
            ProductName.Text = "";
            TotalBox.Text = "";
            QuantityBox.Text = "1";

            ProductView.Items.Clear();

            ProductNames.Clear();
            ProductQuantities.Clear();
            ProductPrices.Clear();
            Expandity.Clear();

            Load();
        }
    }
}
