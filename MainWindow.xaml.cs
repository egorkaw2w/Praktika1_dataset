using System;
using System.Collections.Generic;
using System.Data;
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
using Praktika1._1.DataBaseInfoTableAdapters;

namespace Praktika1._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        EmployeeTableAdapter employee = new EmployeeTableAdapter();

        public MainWindow()
        {
            InitializeComponent();
            Kamen.ItemsSource = employee.GetData();
        }

        private void Kamen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Bd2 window = new Bd2();
            window.Show();
            Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Bd2 window = new Bd2();
            window.Show();
            Close();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            InserterEmployeer windowInsert = new InserterEmployeer();
            windowInsert.Show();
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Kamen.SelectedItem as DataRowView != null)
                {
                    object id = (Kamen.SelectedItem as DataRowView).Row[0];
                    employee.DeleteQuery(Convert.ToInt32(id));
                    Kamen.ItemsSource = employee.GetData();
                }
                else
                {
                    MessageBox.Show("Нельзя удалять пустые строки ");
                }
            }
            catch
            {
                MessageBox.Show("Низя");
            }


        }

    }
}
