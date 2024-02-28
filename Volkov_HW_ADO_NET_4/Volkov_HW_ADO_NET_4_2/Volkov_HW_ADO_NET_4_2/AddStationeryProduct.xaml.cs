using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Volkov_HW_ADO_NET_4_2
{
    public partial class AddStationeryProduct : Window
    {
        string? connectionString;
        public AddStationeryProduct()
        {
            InitializeComponent();
            var builder = new ConfigurationBuilder();
            string path = Directory.GetCurrentDirectory();
            builder.SetBasePath(path);
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            connectionString = config.GetConnectionString("DefaultConnection");
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();

            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllTypeProducts";
                SqlDataReader reader = command.ExecuteReader();
                int count = reader.FieldCount;
                comboBox1.Items.Clear();
                while (reader.Read())
                {
                    string? res = "", temp = "";
                    for (int i = 0; i < count; i++)
                    {
                        temp = reader[i].ToString();
                        res += temp + " ";
                    }
                    comboBox1.Items.Add(res);
                    res = "";
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                command.Dispose();
                connect.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("InsertStationeryProduct", connect);
            try
            {
                connect.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("ProductName", SqlDbType.NVarChar);
                cmd.Parameters["ProductName"].Value = textbox1.Text;
                cmd.Parameters.Add("ProductType", SqlDbType.NVarChar);
                cmd.Parameters["ProductType"].Value = comboBox1.SelectedItem.ToString();
                cmd.Parameters.Add("Quantity", SqlDbType.Int);
                cmd.Parameters["Quantity"].Value = textbox2.Text;
                cmd.Parameters.Add("CostPrice", SqlDbType.Decimal);
                cmd.Parameters["CostPrice"].Value = textbox3.Text;
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
