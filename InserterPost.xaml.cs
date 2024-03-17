using Praktika1._1.DataBaseInfoTableAdapters;
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
using System.Windows.Shapes;

namespace Praktika1._1
{
    /// <summary>
    /// Логика взаимодействия для InserterPost.xaml
    /// </summary>
    public partial class InserterPost : Window
    {
        PostTableAdapter post = new PostTableAdapter();

        public InserterPost()
        {
            InitializeComponent();
            DataGrid.ItemsSource = post.GetData();
        }

        private void SaveAndExit_Click(object sender, RoutedEventArgs e)
        {
            post.Insert(PostName.Text, Convert.ToInt32(Salary.Text));
            Bd2 window = new Bd2();
            window.Show();
            Close();
        }

        private void Salary_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UpdateAndExit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem as DataRowView != null)
            {
                object orId = (DataGrid.SelectedItem as DataRowView).Row[0];
                post.UpdateQuery(PostName.Text, Convert.ToInt32(Salary.Text), Convert.ToInt32(orId));
                Bd2 window = new Bd2();
                window.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Не трогайте пустые строки :( ");
            }
            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object postname = (DataGrid.SelectedItem as DataRowView).Row[1];
            object salary= (DataGrid.SelectedItem as DataRowView).Row[2];

            PostName.Text = postname.ToString();
            Salary.Text = salary.ToString();
        }
    }
}
