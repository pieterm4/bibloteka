using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFsd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataLayer.DB.ApplicationName = "WinDemo Application";
            DataLayer.DB.ConnectionTimeout = 30;
            SqlConnection conn = DataLayer.DB.GetSqlConnection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataLayer.Employees es = new DataLayer.Employees();
                DataLayer.Employee employee = es.GetEmployee(int.Parse(TextBoxID.Text));
                TextBlocFName.Text = employee.FirstName;
            }
            catch { }
        }
    }
}
