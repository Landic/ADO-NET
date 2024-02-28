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
using System.ComponentModel.Design;
using System.Data;
using Microsoft.Extensions.Primitives;

namespace Volkov_HW_ADO_NET_4_2
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddStationeryProduct addproduct = new AddStationeryProduct();
            bool? res = addproduct.ShowDialog();
            if(res == true)
            {
                MessageBox.Show($"Продукт {addproduct.textbox1.Text}, добавлен");
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AddTypeProduct addtypeproduct = new AddTypeProduct();
            bool? res = addtypeproduct.ShowDialog();
            if (res == true)
            {
                MessageBox.Show($"Тип продукт {addtypeproduct.textbox1.Text}, добавлен");
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            AddManager addManager = new AddManager();
            bool? res = addManager.ShowDialog();
            if (res == true)
            {
                MessageBox.Show($"Менеджер {addManager.textbox1.Text}, добавлен");
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            AddCustomers addCustomers = new AddCustomers();
            bool? res = addCustomers.ShowDialog();
            if (res == true)
            {
                MessageBox.Show($"Фирма {addCustomers.textbox1.Text}, добавлен");
            }
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            UpdateProduct updProduct = new UpdateProduct();
            bool? res = updProduct.ShowDialog();
            if (res == true)
            {
                MessageBox.Show($"Продукт {updProduct.comboBox1.SelectedItem.ToString()}, обновлен, на {updProduct.textbox1.Text}");
            }
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            UpdateCustomers updCustomers = new UpdateCustomers();
            bool? res = updCustomers.ShowDialog();
            if (res == true)
            {
                MessageBox.Show($"Фирма {updCustomers.comboBox1.SelectedItem.ToString()}, обновлена, на {updCustomers.textbox1.Text}");
            }
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            UpdateManager updManager = new UpdateManager();
            bool? res = updManager.ShowDialog();
            if (res == true)
            {
                MessageBox.Show($"Менджер {updManager.comboBox1.SelectedItem.ToString()}, обновлен, на {updManager.textbox1.Text}");
            }
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            UpdateTypeProduct updTypeProduct = new UpdateTypeProduct();
            bool? res = updTypeProduct.ShowDialog();
            if (res == true)
            {
                MessageBox.Show($"Тип продукта {updTypeProduct.comboBox1.SelectedItem.ToString()}, обновлен, на {updTypeProduct.textbox1.Text}");
            }
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            DeleteProduct delproduct = new DeleteProduct();
            bool? res = delproduct.ShowDialog();
            if (res == true)
            {
                MessageBox.Show($"Продукт {delproduct.comboBox1.SelectedItem.ToString()} удален");
            }
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            DeleteManager deleteManager = new DeleteManager();
            bool? res = deleteManager.ShowDialog();
            if (res == true)
            {
                MessageBox.Show($"Менеджер {deleteManager.comboBox1.SelectedItem.ToString()} удален");
            }
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            DeleteTypeProduct deleteTypeProduct = new DeleteTypeProduct();
            bool? res = deleteTypeProduct.ShowDialog();
            if (res == true)
            {
                MessageBox.Show($"Тип продукта {deleteTypeProduct.comboBox1.SelectedItem.ToString()} удален");
            }
        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            DeleteCustomers deleteCustomers = new DeleteCustomers();
            bool? res = deleteCustomers.ShowDialog();
            if (res == true)
            {
                MessageBox.Show($"Фирма {deleteCustomers.comboBox1.SelectedItem.ToString()} удален");
            }
        }


        void Request(string cmd, SqlParameter[] param = null)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();

            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = cmd;
                if (param != null)
                {
                    command.Parameters.AddRange(param);
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


        private void MenuItem_Click_12(object sender, RoutedEventArgs e)
        {
            Request("GetTopSalesManager");
        }

        private void MenuItem_Click_13(object sender, RoutedEventArgs e)
        {
            Request("GetTopProfitSalesManager");
        }

        private void MenuItem_Click_14(object sender, RoutedEventArgs e)
        {
            RangeInput rangeInput = new RangeInput();
            bool? res = rangeInput.ShowDialog();
            if(res == true)
            {
                string start = rangeInput.textbox1.Text;
                string end = rangeInput.textbox2.Text;
                SqlParameter[] parameters = new SqlParameter[]
                {
                     new SqlParameter("@StartDate", start),
                     new SqlParameter("@EndDate", end)
                };
                Request("GetTopProfitSalesManagerInRange", parameters);
            }
        }

        private void MenuItem_Click_15(object sender, RoutedEventArgs e)
        {
            Request("GetTopSpendingCustomer");
        }

        private void MenuItem_Click_16(object sender, RoutedEventArgs e)
        {
            Request("GetTopSalesTypeProduct");
        }

        private void MenuItem_Click_17(object sender, RoutedEventArgs e)
        {
            Request("GetTopProfitableTypeProduct");
        }

        private void MenuItem_Click_18(object sender, RoutedEventArgs e)
        {
            Request("GetMostPopularStationeryProducts");
        }

        private void MenuItem_Click_19(object sender, RoutedEventArgs e)
        {
            NotSoldForDays notSoldForDays = new NotSoldForDays();
            bool? res = notSoldForDays.ShowDialog();
            if (res == true)
            {
                int day = int.Parse(notSoldForDays.textbox1.Text);
                SqlParameter[] parameters = new SqlParameter[]
                {
                     new SqlParameter("@NumberOfDays", day),
                };
                Request("GetStationeryProductsNotSoldForDays", parameters);
            }
        }
    }
}