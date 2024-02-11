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

namespace Volkov_HW_ADO_NET_2
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
                command.CommandText = "SELECT * FROM VegetablesAndFruits";
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
                command.CommandText = "SELECT name FROM VegetablesAndFruits";
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
                command.CommandText = "SELECT color FROM VegetablesAndFruits";
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
                command.CommandText = "SELECT MAX(calories) FROM VegetablesAndFruits";
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
                command.CommandText = "SELECT MIN(calories) FROM VegetablesAndFruits";
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
                command.CommandText = "SELECT AVG(calories) FROM VegetablesAndFruits";
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
                command.CommandText = "SELECT COUNT(*) FROM VegetablesAndFruits WHERE type = 'Овощь'";
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
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT COUNT(*) FROM VegetablesAndFruits WHERE type = 'Фрукт'";
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

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            bool? dialogResult = window1.ShowDialog();
            if(dialogResult == true)
            {
                SqlConnection connect = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand();
                try
                {
                    connect.Open();
                    command.Connection = connect;
                    command.CommandText = $"SELECT COUNT(*) FROM VegetablesAndFruits WHERE color = '{window1.textbox1.Text}'";
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

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = $"SELECT color,COUNT(*) FROM VegetablesAndFruits GROUP BY color ORDER BY color";
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

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Calories calories = new Calories();
            bool? dialogResult = calories.ShowDialog();
            if (dialogResult == true)
            {
                SqlConnection connect = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand();
                try
                {
                    connect.Open();
                    command.Connection = connect;
                    command.CommandText = $"SELECT * FROM VegetablesAndFruits WHERE calories < '{calories.textbox1.Text}'";
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

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            Calories calories = new Calories();
            bool? dialogResult = calories.ShowDialog();
            if (dialogResult == true)
            {
                SqlConnection connect = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand();
                try
                {
                    connect.Open();
                    command.Connection = connect;
                    command.CommandText = $"SELECT * FROM VegetablesAndFruits WHERE calories > '{calories.textbox1.Text}'";
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

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            RangeCalories calories = new RangeCalories();
            bool? dialogResult = calories.ShowDialog();
            if (dialogResult == true)
            {
                SqlConnection connect = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand();
                try
                {
                    connect.Open();
                    command.Connection = connect;
                    command.CommandText = $"SELECT * FROM VegetablesAndFruits WHERE calories > '{calories.textbox1.Text}' AND calories < '{calories.textbox2.Text}'";
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

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT * FROM VegetablesAndFruits WHERE color IN ('Красный', 'Желтый') ORDER BY name";
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
}