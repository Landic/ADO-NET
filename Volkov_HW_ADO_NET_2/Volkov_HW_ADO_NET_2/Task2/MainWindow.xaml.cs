using System.IO;
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

namespace Task2
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT * FROM Product";
                SqlDataReader reader = command.ExecuteReader();
                int count = reader.FieldCount;
                list1.Items.Clear();
                while (reader.Read())
                {
                    string? res = "", temp = "";
                    for (int i = 0; i < count; i++)
                    {
                        temp = reader[i].ToString();
                        res += temp + " ";
                    }
                    list1.Items.Add(res);
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT Type FROM Product";
                SqlDataReader reader = command.ExecuteReader();
                int count = reader.FieldCount;
                list1.Items.Clear();
                while (reader.Read())
                {
                    string? res = "", temp = "";
                    for (int i = 0; i < count; i++)
                    {
                        temp = reader[i].ToString();
                        res += temp + " ";
                    }
                    list1.Items.Add(res);
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT * FROM Provider";
                SqlDataReader reader = command.ExecuteReader();
                int count = reader.FieldCount;
                list1.Items.Clear();
                while (reader.Read())
                {
                    string? res = "", temp = "";
                    for (int i = 0; i < count; i++)
                    {
                        temp = reader[i].ToString();
                        res += temp + " ";
                    }
                    list1.Items.Add(res);
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT Product.Name, Stock.Count FROM Stock JOIN Product ON Product.id = dbo.Stock.ProductID Where Count = (Select MAX(Count) From Stock)";
                SqlDataReader reader = command.ExecuteReader();
                int count = reader.FieldCount;
                list1.Items.Clear();
                while (reader.Read())
                {
                    string? res = "", temp = "";
                    for (int i = 0; i < count; i++)
                    {
                        temp = reader[i].ToString();
                        res += temp + " ";
                    }
                    list1.Items.Add(res);
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

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT Product.Name, Stock.Count FROM Stock JOIN Product ON Product.id = dbo.Stock.ProductID Where Count = (Select MIN(Count) From Stock)";
                SqlDataReader reader = command.ExecuteReader();
                int count = reader.FieldCount;
                list1.Items.Clear();
                while (reader.Read())
                {
                    string? res = "", temp = "";
                    for (int i = 0; i < count; i++)
                    {
                        temp = reader[i].ToString();
                        res += temp + " ";
                    }
                    list1.Items.Add(res);
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

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT Product.Name, Stock.CostPrice FROM Stock JOIN Product ON Product.id = dbo.Stock.ProductID Where CostPrice = (Select MIN(CostPrice) From Stock)";
                SqlDataReader reader = command.ExecuteReader();
                int count = reader.FieldCount;
                list1.Items.Clear();
                while (reader.Read())
                {
                    string? res = "", temp = "";
                    for (int i = 0; i < count; i++)
                    {
                        temp = reader[i].ToString();
                        res += temp + " ";
                    }
                    list1.Items.Add(res);
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

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT Product.Name, Stock.CostPrice FROM Stock JOIN Product ON Product.id = dbo.Stock.ProductID Where CostPrice = (Select MAX(CostPrice) From Stock)";
                SqlDataReader reader = command.ExecuteReader();
                int count = reader.FieldCount;
                list1.Items.Clear();
                while (reader.Read())
                {
                    string? res = "", temp = "";
                    for (int i = 0; i < count; i++)
                    {
                        temp = reader[i].ToString();
                        res += temp + " ";
                    }
                    list1.Items.Add(res);
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

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Category category = new Category();
            bool? dialogResult = category.ShowDialog();
            if (dialogResult == true)
            {
                SqlConnection connect = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand();
                try
                {
                    connect.Open();
                    command.Connection = connect;
                    command.CommandText = $"SELECT * FROM Product WHERE Type = '{category.textbox1.Text}'";
                    SqlDataReader reader = command.ExecuteReader();
                    int count = reader.FieldCount;
                    list1.Items.Clear();
                    while (reader.Read())
                    {
                        string? res = "", temp = "";
                        for (int i = 0; i < count; i++)
                        {
                            temp = reader[i].ToString();
                            res += temp + " ";
                        }
                        list1.Items.Add(res);
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
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Provider provider = new Provider();
            bool? dialogResult = provider.ShowDialog();
            if (dialogResult == true)
            {
                SqlConnection connect = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand();
                try
                {
                    connect.Open();
                    command.Connection = connect;
                    command.CommandText = $"SELECT Product.Name, Product.Type, Provider.Name FROM Stock JOIN Product ON Product.id = Stock.ProductID JOIN Provider ON Stock.ProviderID = Provider.ID WHERE Provider.Name = '{provider.textbox1.Text}'";
                    SqlDataReader reader = command.ExecuteReader();
                    int count = reader.FieldCount;
                    list1.Items.Clear();
                    while (reader.Read())
                    {
                        string? res = "", temp = "";
                        for (int i = 0; i < count; i++)
                        {
                            temp = reader[i].ToString();
                            res += temp + "  ";
                        }
                        list1.Items.Add(res);
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
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT Product.Name, Product.Type FROM Stock JOIN Product ON Product.id = Stock.ProductID ORDER BY Stock.DateOfDelivery ASC OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY";
                SqlDataReader reader = command.ExecuteReader();
                int count = reader.FieldCount;
                list1.Items.Clear();
                while (reader.Read())
                {
                    string? res = "", temp = "";
                    for (int i = 0; i < count; i++)
                    {
                        temp = reader[i].ToString();
                        res += temp + "  ";
                    }
                    list1.Items.Add(res);
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

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT Product.Type, AVG(Stock.Count) FROM Stock JOIN Product ON Product.id = Stock.ProductID GROUP BY Product.Type";
                SqlDataReader reader = command.ExecuteReader();
                int count = reader.FieldCount;
                list1.Items.Clear();
                while (reader.Read())
                {
                    string? res = "", temp = "";
                    for (int i = 0; i < count; i++)
                    {
                        temp = reader[i].ToString();
                        res += temp + "  ";
                    }
                    list1.Items.Add(res);
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
    }
}