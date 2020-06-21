using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using LiveCharts;
using LiveCharts.Wpf;

namespace WpfApp1.SubControls
{
    /// <summary>
    /// Interaction logic for ProductsChart.xaml
    /// </summary>
    public partial class ProductsChart : UserControl
    {
        public ProductsChart()
        {
            InitializeComponent();
            int CurrentMonth = DateTime.Today.Month;

            List<int> LastMonths = new List<int>();
            List<string> LastMonthsString = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                LastMonths.Add(CurrentMonth);
                CurrentMonth--;
                if (CurrentMonth < 1)
                    CurrentMonth = 12;
            }
            for (int i = 3; i > -1; i--)
            {
                if (LastMonths[i] == 1)
                    LastMonthsString.Add("Jan");
                if (LastMonths[i] == 2)
                    LastMonthsString.Add("Feb");
                if (LastMonths[i] == 3)
                    LastMonthsString.Add("Mar");
                if (LastMonths[i] == 4)
                    LastMonthsString.Add("Apr");
                if (LastMonths[i] == 5)
                    LastMonthsString.Add("May");
                if (LastMonths[i] == 6)
                    LastMonthsString.Add("Jun");
                if (LastMonths[i] == 7)
                    LastMonthsString.Add("Jul");
                if (LastMonths[i] == 8)
                    LastMonthsString.Add("Aug");
                if (LastMonths[i] == 9)
                    LastMonthsString.Add("Sept");
                if (LastMonths[i] == 10)
                    LastMonthsString.Add("Oct");
                if (LastMonths[i] == 11)
                    LastMonthsString.Add("Nov");
                if (LastMonths[i] == 12)
                    LastMonthsString.Add("Dec");
            }
            List<decimal> SumPrices = new List<decimal>();
            for (int i = 3; i > -1; i--)
            {
                SqlDataReader dr = Database.Select("SELECT TOP 1 value FROM Price WHERE product_id = "+ ProductsControl.id_product +" AND MONTH(date) = " + LastMonths[i] + " AND YEAR(date) = YEAR(getdate());");
                while (dr.Read())
                {
                    string total = dr["value"].ToString();
                    if (total == "")
                        total = "0";
                    SumPrices.Add(Convert.ToDecimal(total));
                }
            }

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Price",
                    Values = new ChartValues<decimal> { SumPrices[0], SumPrices[1], SumPrices[2], SumPrices[3] },
                    LineSmoothness = 0, //0: straight lines, 1: really smooth lines
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10,
                    
                    //PointForeground = HexColor.Orange,
                    //Stroke = HexColor.Orange,
                    //Fill = HexColor.Orange
                },

            };


            Labels = new[] { LastMonthsString[0], LastMonthsString[1], LastMonthsString[2], LastMonthsString[3] };
            YFormatter = value => value.ToString();

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; }
        public string[] Labels { get; set; }
        public Func<decimal, string> YFormatter { get; set; }

    }
}