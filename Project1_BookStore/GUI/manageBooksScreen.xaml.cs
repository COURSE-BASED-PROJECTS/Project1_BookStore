﻿using Project1_BookStore.DTO;
using Project1_BookStore.BUS;
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
            reDownButton.Visibility = Visibility.Collapsed;
        }

        public class manageBooksContext:INotifyPropertyChanged
        { 
            public Icons _icons { get; set; } = new Icons();
            public int countBook { get; set; } =  0;

            public event PropertyChangedEventHandler? PropertyChanged;
        }

        manageBooksContext Context = new manageBooksContext();
        BindingList<BookDTO> allBookContext = new BindingList<BookDTO>(AddLinkImg.addLinkstoBook(BookBUS.findAllBook()));
        BindingList<BookDTO> nearOutOfBookContext = new BindingList<BookDTO>(AddLinkImg.addLinkstoBook(BookBUS.findTop5()));
        BindingList<BookDTO> bestSellerBookContext = new BindingList<BookDTO>(AddLinkImg.addLinkstoBook(BookBUS.findBestSellerBook()));

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void maxButton_Click(object sender, RoutedEventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Normal:
                    reDownButton.Visibility = Visibility.Visible;
                    maxButton.Visibility = Visibility.Collapsed;
                    this.WindowState = WindowState.Maximized;
                    break;
                case WindowState.Maximized:
                    maxButton.Visibility = Visibility.Visible;
                    reDownButton.Visibility = Visibility.Collapsed;
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
            allBooks.ItemsSource = allBookContext;
            nearOutOfBooks.ItemsSource = nearOutOfBookContext;
            bestSellerBooks.ItemsSource = bestSellerBookContext;
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
            if(screen.ShowDialog() == true)
            {
                var book = screen._newBook;

                //Add new book to temporary system
                allBookContext.Add(book);

                if(book.bookQuantity < 5)
                {
                    nearOutOfBookContext.Add(book);
                }
                Context.countBook = allBookContext.Count;


                //Add new book to database
                BookBUS.InsertBook(book);
                MessageBox.Show("Thêm mới thành công!");
            }

        }

        private void uploadDataScreen(object sender, RoutedEventArgs e)
        {
            var screen = new uploadDataScreen();
            screen.ShowDialog();
        }

        private void signOut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var result = MessageBox.Show("Bạn muốn đăng xuất khỏi hệ thống?",
                    "Xác Nhận Đăng Xuất",
                    MessageBoxButton.YesNoCancel,
                    MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                var screen = new LoginWindow();
                screen.Show();
                this.Close();
            }
        }
    }
}
