﻿using Project1_BookStore.BUS;
using Project1_BookStore.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace Project1_BookStore.GUI
{
    /// <summary>
    /// Interaction logic for manageBooksScreen.xaml
    /// </summary>
    public partial class manageBooksScreen : Window
    {
        public manageBooksScreen()
        {
            InitializeComponent();
        }

        public class manageBooksContext:INotifyPropertyChanged
        { 
            public Icons _icons { get; set; } = new Icons();
            public int countBook { get; set; } =  0;

            public event PropertyChangedEventHandler? PropertyChanged;
        }

        manageBooksContext Context = new manageBooksContext();


        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void maxButton_Click(object sender, RoutedEventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Normal:
                    this.WindowState = WindowState.Maximized;
                    break;
                case WindowState.Maximized:
                    this.WindowState = WindowState.Normal;
                    break;
            }
        }

        private void minButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Context.countBook = BookBUS.findAllBook().Count;

            this.DataContext = Context;
            allBooks.ItemsSource = AddLinkImg.addLinkstoBook(BookBUS.findAllBook());
            nearOutOfBooks.ItemsSource = AddLinkImg.addLinkstoBook(BookBUS.findTop5());
            bestSellerBooks.ItemsSource = AddLinkImg.addLinkstoBook(BookBUS.findBestSellerBook());
        }

        private void Grid_MouseDown_ManageProduct(object sender, MouseButtonEventArgs e)
        {
            var screen = new manageBooksScreen();
            screen.Show();
            this.Close();
        }

        private void Grid_MouseDown_ManageOrder(object sender, MouseButtonEventArgs e)
        {
            var screen = new manageOrdersScreen();
            screen.Show();
            this.Close();
        }

        private void Grid_MouseDown_ManageCoupon(object sender, MouseButtonEventArgs e)
        {
            var screen = new manageCouponScreen();
            screen.Show();
            this.Close();
        }

        private void Grid_MouseDown_Setting(object sender, MouseButtonEventArgs e)
        {
            var screen = new settingScreen();
            screen.Show();
            this.Close();
        }

        private void Grid_MouseDown_MainWindow(object sender, MouseButtonEventArgs e)
        {
            var screen = new MainWindow();
            screen.Show();
            this.Close();
        }

        private void addNewBook(object sender, RoutedEventArgs e)
        {
            var screen = new addNewBookScreen();
            screen.Show();
        }

        private void uploadDataScreen(object sender, RoutedEventArgs e)
        {
            var screen = new uploadDataScreen();
            screen.ShowDialog();
        }
    }
}
