using System.Text;
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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using System.Data;

namespace Volkov_HW_ADO_NET_4
{
    public partial class MainWindow : Window
    {
        string? connectionString;
        public MainWindow()
        {
            InitializeComponent();
            var builder = new ConfigurationBuilder();
            string path = Directory.GetCurrentDirectory();
            builder.SetBasePath(path);
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            connectionString = config.GetConnectionString("DefaultConnection");
        }

        void ExecuteProcedure(string commands, SqlParameter param = null)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();

            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = commands;
                if (param != null)
                {
                    command.Parameters.Add(param);
                }
                SqlDataReader reader = command.ExecuteReader();
                int count = reader.FieldCount;
                listbox1.Items.Clear();
                while (reader.Read())
                {
                    string? res = "", temp = "";
                    for (int i = 0; i < count; i++)
                    {
                        temp = reader[i].ToString();
                        res += temp + " ";
                    }
                    listbox1.Items.Add(res);
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

        void ExecuteFuction(string commands)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();

            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = $"{commands}";
                SqlDataReader reader = command.ExecuteReader();
                int count = reader.FieldCount;
                listbox1.Items.Clear();
                while (reader.Read())
                {
                    string? res = "", temp = "";
                    for (int i = 0; i < count; i++)
                    {
                        temp = reader[i].ToString();
                        res += temp + " ";
                    }
                    listbox1.Items.Add(res);
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ExecuteProcedure("GetAllProducts");
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ExecuteProcedure("GetAllTypeProducts");
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            ExecuteFuction("Select * From GetAllManager()");
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            ExecuteProcedure("GetProductsByMaxQuantity");
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            ExecuteProcedure("GetProductsByMinQuantity");
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            ExecuteProcedure("GetProductsByMinCostPrice");
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            ExecuteProcedure("GetProductsByMaxCostPrice");
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            TypeProduct product = new TypeProduct();
            bool? res = product.ShowDialog();
            if (res == true)
            {
                string Value = product.type;
                ExecuteProcedure("GetTypeProduct", new SqlParameter("@ProductType", Value));
            }
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            Manager manager = new Manager();
            bool? res = manager.ShowDialog();
            if (res == true)
            {
                string Value = manager.manager;
                ExecuteProcedure("GetManagerSales", new SqlParameter("@Name", Value));
            }
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            Customers customer = new Customers();
            bool? res = customer.ShowDialog();
            if (res == true)
            {
                string Value = customer.customer;
                ExecuteProcedure("GetCustomerBuyProduct", new SqlParameter("@Name", Value));
            }
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            ExecuteFuction("Select * From GetDateLastSale()");
        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            ExecuteFuction("Select * From GetAvgTypeQuantity()");
        }
    }
}