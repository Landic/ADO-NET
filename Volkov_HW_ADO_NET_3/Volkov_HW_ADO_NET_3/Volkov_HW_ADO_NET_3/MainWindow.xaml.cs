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

namespace Volkov_HW_ADO_NET_3
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
            AddProduct addProduct = new AddProduct();
            bool? res = addProduct.ShowDialog();
            if(res == true)
            {
                MessageBox.Show($"Товар {addProduct.textbox1.Text} добавлен");

            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AddTypeProduct addTypeProduct = new AddTypeProduct();
            bool? res = addTypeProduct.ShowDialog();
            if (res == true)
            {
                MessageBox.Show($"Поставщик {addTypeProduct.textbox1.Text} добавлен");

            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            AddProvider addProvider = new AddProvider();
            bool? res = addProvider.ShowDialog();
            if (res == true)
            {
                MessageBox.Show($"Поставщик {addProvider.textbox1.Text} добавлен");

            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            UpdateProduct updateProduct = new UpdateProduct();
            bool? res = updateProduct.ShowDialog();
            if (res == true)
            {
                MessageBox.Show($"Товар {updateProduct.textbox1.Text} обновлен на новое название: {updateProduct.textbox2.Text}");

            }
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            UpdateProvider updateProvider = new UpdateProvider();
            bool? res = updateProvider.ShowDialog();
            if (res == true)
            {
                MessageBox.Show($"Поставщик {updateProvider.textbox1.Text}, {updateProvider.textbox2.Text} обновлен на новое название и страну: {updateProvider.textbox3.Text}, {updateProvider.textbox4.Text}");

            }
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            UpdateTypeProduct updateTypeProduct = new UpdateTypeProduct();
            bool? res = updateTypeProduct.ShowDialog();
            if (res == true)
            {
                MessageBox.Show($"Тип товара {updateTypeProduct.textbox1.Text} обновлен на новое тип товара: {updateTypeProduct.textbox2.Text}");

            }
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            DeleteProduct deleteProduct = new DeleteProduct();
            bool? res = deleteProduct.ShowDialog();
            if (res == true)
            {
                MessageBox.Show($"Товар {deleteProduct.combobox1.SelectedItem.ToString()} был удален");

            }
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            DeleteProvider deleteProvider = new DeleteProvider();
            bool? res = deleteProvider.ShowDialog();
            if (res == true)
            {
                MessageBox.Show($"Поставщик {deleteProvider.combobox1.SelectedItem.ToString()} был удален");

            }
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            DeleteTypeProduct deleteTypeProduct = new DeleteTypeProduct();
            bool? res = deleteTypeProduct.ShowDialog();
            if (res == true)
            {
                MessageBox.Show($"Тип товара {deleteTypeProduct.combobox1.SelectedItem.ToString()} был удален");

            }
        }


        private void Request(string commands)
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

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            Request("SELECT Provider.Name, Provider.Country, SUM(Stock.Count) AS Total FROM Provider JOIN Stock ON Provider.ID = Stock.ProviderID GROUP BY Provider.Name, Provider.Country ORDER BY Total DESC OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY");
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            Request("SELECT Provider.Name, Provider.Country, SUM(Stock.Count) AS Total FROM Provider JOIN Stock ON Provider.ID = Stock.ProviderID GROUP BY Provider.Name, Provider.Country ORDER BY Total ASC OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY");
        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            Request("SELECT TypeProduct.Type, SUM(Stock.Count) AS Total FROM TypeProduct JOIN Product ON TypeProduct.ID = Product.TypeID JOIN Stock ON Product.ID = Stock.ProductID GROUP BY TypeProduct.Type ORDER BY Total DESC OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY");
        }

        private void MenuItem_Click_12(object sender, RoutedEventArgs e)
        {
            Request("SELECT TypeProduct.Type, SUM(Stock.Count) AS Total FROM TypeProduct JOIN Product ON TypeProduct.ID = Product.TypeID JOIN Stock ON Product.ID = Stock.ProductID GROUP BY TypeProduct.Type ORDER BY Total ASC OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY");
        }

        private void MenuItem_Click_13(object sender, RoutedEventArgs e)
        {
            Day day = new Day();
            bool? res = day.ShowDialog();
            if(res == true)
            {
                Request($"SELECT Product.Name, Stock.Count, Stock.CostPrice, Stock.DateOfDelivery FROM Product JOIN Stock ON Product.ID = Stock.ProductID WHERE Stock.DateOfDelivery <= DATEADD(day, {day.day}, GETDATE())");
            }
        }
    }
}