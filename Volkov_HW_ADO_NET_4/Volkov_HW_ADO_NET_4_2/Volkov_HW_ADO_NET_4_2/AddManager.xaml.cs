using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
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
using System.Windows.Shapes;

namespace Volkov_HW_ADO_NET_4_2
{
    public partial class AddManager : Window
    {
        string? connectionString;
        public AddManager()
        {
            InitializeComponent();
            var builder = new ConfigurationBuilder();
            string path = Directory.GetCurrentDirectory();
            builder.SetBasePath(path);
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            connectionString = config.GetConnectionString("DefaultConnection");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("InsertManager", connect);
            try
            {
                connect.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("ManagerName", SqlDbType.NVarChar);
                cmd.Parameters["ManagerName"].Value = textbox1.Text;
                int n = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                connect.Close();
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
