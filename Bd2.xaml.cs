﻿using System;
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
using Praktika1._1.DataBaseInfoTableAdapters;


namespace Praktika1._1
{
    /// <summary>
    /// Логика взаимодействия для Bd2.xaml
    /// </summary>
    public partial class Bd2 : Window
    {
        EmployeeViewTableAdapter View = new EmployeeViewTableAdapter();
        PostTableAdapter post = new PostTableAdapter();
        EmployeeTableAdapter Employee = new EmployeeTableAdapter();
        public Bd2()
        {

            InitializeComponent();
            Kamen.ItemsSource = View.GetData();
            ComboInfo.ItemsSource = post.GetData();
            ComboInfo.DisplayMemberPath = "Post_Name";

        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            if (Kamen.SelectedItem as DataRowView != null)
            {
                object id = (Kamen.SelectedItem as DataRowView).Row[0];
                post.DeleteQuery(Convert.ToInt32(id));
                Kamen.ItemsSource = post.GetData();
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

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            InserterPost window = new InserterPost();
            window.Show();
            Close();
        }

        private void Kamen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboInfo.SelectedItem != null)
            {
                Kamen.ItemsSource = View.Filter((ComboInfo.SelectedItem as DataRowView)[1].ToString());
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Kamen.ItemsSource = View.GetData();

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Kamen.ItemsSource = Employee.GetDataBy3(Searcher.Text);
        }

        private void Searcher_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
