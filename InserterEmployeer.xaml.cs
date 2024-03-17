using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
using Praktika1._1.DataBaseInfoTableAdapters;

namespace Praktika1._1
{
    /// <summary>
    /// Логика взаимодействия для InserterEmployeer.xaml
    /// </summary>
    public partial class InserterEmployeer : Window
    {
        EmployeeTableAdapter db = new EmployeeTableAdapter();
        PostTableAdapter post = new PostTableAdapter();
        public List<String> Post = new List<String>();
        int id = 0;

        public InserterEmployeer()
        {
            InitializeComponent();
            DataInserter.ItemsSource = db.GetData();
      
            IdPost.ItemsSource = post.GetData();
            IdPost.DisplayMemberPath = "Post_Name";
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataInserter.SelectedItem as DataRowView != null)
            {
                object name = (DataInserter.SelectedItem as DataRowView).Row[1];
                object surname = (DataInserter.SelectedItem as DataRowView).Row[2];
                object middlename = (DataInserter.SelectedItem as DataRowView).Row[3];
                object id =  (DataInserter.SelectedItem as DataRowView).Row[4];

                Name.Text = name.ToString();
                Surname.Text = surname.ToString();
                MiddleName1.SelectedText = middlename.ToString();
                IdPost.Text = id.ToString();
            }
            else
            {
                MessageBox.Show("Не трогайте пустые строки :( ");
            }
           
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Surname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MiddleName1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void IdPost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           
           
        }
        private void SaveAndBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            object id = (IdPost.SelectedItem as DataRowView).Row[0];
            db.Insert(Name.Text, Surname.Text, MiddleName1.Text, Convert.ToInt32(id));
            MainWindow window = new MainWindow();
            window.Show();
            Close();
            }
            catch
            {
                MainWindow window = new MainWindow();
                window.Show();
                Close();
            }
        }

        private void UpdateAndBack_Click(object sender, RoutedEventArgs e)
        {

          
            object orId = (DataInserter.SelectedItem as DataRowView).Row[0];
            object id = (IdPost.SelectedItem as DataRowView).Row[0];

            db.UpdateQuery(Name.Text, Surname.Text, MiddleName1.Text, Convert.ToInt32(id), Convert.ToInt32(orId));
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }
    }
}
