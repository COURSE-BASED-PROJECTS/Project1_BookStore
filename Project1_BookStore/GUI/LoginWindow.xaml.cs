﻿using Project1_BookStore.DTO;
using Project1_BookStore.BUS;
using Project1_BookStore.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace Project1_BookStore
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>

    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            reDownButton.Visibility = Visibility.Collapsed;
        }
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

        Icons _icons = new Icons();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = _icons;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            var username = (userTextBox.Text).Trim();

            var password = passTextBox.Password;
            
            var check = UserBUS.findUser(username, password);

            if (check == false)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu sai!",
                    "Lỗi đăng nhập",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                var entropy = "123";
                AppConfig.SetValue(AppConfig.Username, username);
                AppConfig.SetValue(AppConfig.Password, password);
                AppConfig.SetValue(AppConfig.Entropy, entropy);
                var screen = new MainWindow();
                screen.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                screen.Show();
                this.Close();
            }

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                var username = (userTextBox.Text).Trim();

                var password = passTextBox.Password;

                var check = UserBUS.findUser(username, password);

                if (check == false)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu sai!",
                        "Lỗi đăng nhập",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                else
                {
                    var entropy = "123";
                    AppConfig.SetValue(AppConfig.Username, username);
                    AppConfig.SetValue(AppConfig.Password, password);
                    AppConfig.SetValue(AppConfig.Entropy, entropy);
                    var screen = new MainWindow();
                    screen.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    screen.Show();
                    this.Close();
                }
            }
        }
    }
}
