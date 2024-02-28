using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// <summary>
    /// Interaction logic for UpdateTypeProduct.xaml
    /// </summary>
    public partial class UpdateTypeProduct : Window
    {
        string? connectionString;
        public UpdateTypeProduct()
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
                command.CommandText = "Select Type From TypeProduct";
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
            SqlCommand cmd = new SqlCommand("UpdateTypeProduct", connect);
            try
            {
                connect.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("TypeID", SqlDbType.Int);
                cmd.Parameters["TypeID"].Value = comboBox1.SelectedIndex + 1;
                cmd.Parameters.Add("NewType", SqlDbType.NVarChar);
                cmd.Parameters["NewType"].Value = textbox1.Text;
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
