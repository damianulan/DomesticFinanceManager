using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WpfApp1
{
    public static class Database
    {

        public static SqlConnection GetDBConnection()

        {
            string cn_String = Properties.Settings.Default.ConnectionString;

            SqlConnection cn_connection = new SqlConnection(cn_String);
            
            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();
            return cn_connection;
        }

        public static DataTable GetDataTable(string SQLText)

        {
            SqlConnection cn_connection = GetDBConnection();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(SQLText, cn_connection);
            adapter.Fill(table);
            return table;
        }

        public static SqlDataReader Select(string query)
        {
            SqlConnection cn = GetDBConnection();
            SqlCommand cm = new SqlCommand(query, cn);
            SqlDataReader dr = cm.ExecuteReader();

            return dr;
        }

        public static void ExecSQL(string query)
        {
            try
            {
                SqlConnection cn = GetDBConnection();

                SqlCommand cmd = new SqlCommand(query, cn);

                cmd.ExecuteNonQuery();

                cn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
