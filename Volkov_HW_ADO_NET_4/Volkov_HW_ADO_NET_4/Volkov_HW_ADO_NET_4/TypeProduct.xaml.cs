using System;
using System.Collections.Generic;
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

namespace Volkov_HW_ADO_NET_4
{
    /// <summary>
    /// Interaction logic for TypeProduct.xaml
    /// </summary>
    public partial class TypeProduct : Window
    {
        public string type { get; set; }

        public TypeProduct()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            type = textbox1.Text;
            DialogResult = true;
            this.Close();
        }
    }
}
