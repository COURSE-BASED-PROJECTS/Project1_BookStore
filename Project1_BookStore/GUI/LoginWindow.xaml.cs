using Project1_BookStore.DTO;
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
using BCrypt.Net;

namespace Project1_BookStore
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>

    public partial class LoginWindow : Window
    {
        public int countWrongPass { get; set; } = 0;
        private static string Username { get; set; } = AppConfig.GetValue(AppConfig.Username);

        public static string getUsername()
        {
            return Username;
        }


        public LoginWindow()
        {
            InitializeComponent();
            reDownButton.Visibility = Visibility.Collapsed;
        }
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            AppConfig.SetValue("LastScreen", "GUI/loginWindow.xaml");
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
            // Check username password trong Appconfig với DB
            // AppConfig lưu password đã hash. 
            // kiểm tra password trong AppConfig có bằng với password lấy lên từ DB
            // Gọi hàm getHashedPasswordByUsername trong UserBUS
            // Nếu đúng mới làm tiếp, sai thì ở lại màn hình Login

            //var lastsScreen = AppConfig.GetValue(AppConfig.LastScreen);
            //// Lấy dữ liệu trongAppConfig xem ngta chọn gì -> xử lí
            //if (!lastsScreen.Equals("LoginScreen"))
            //{
            //    //xử lí màn hình
            //}
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            var username = (userTextBox.Text).Trim();

            var rawpassword = passTextBox.Password;

            var check = UserBUS.findUser(username, rawpassword);

            if (check == false)
            {
                this.countWrongPass += 1;
                if (this.countWrongPass < 3)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu sai!",
                        "Lỗi đăng nhập",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show($"Bạn đã nhập sai {this.countWrongPass} lần !!!",
                        "Lỗi đăng nhập",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
            else
            {
                this.countWrongPass = 0;
                AppConfig.SetValue(AppConfig.Username, username);
                Username = username;
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

                var rawpassword = passTextBox.Password;

                var check = UserBUS.findUser(username, rawpassword);

                if (check == false)
                {
                    this.countWrongPass += 1;
                    if (this.countWrongPass < 3)
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu sai!",
                            "Lỗi đăng nhập",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Bạn đã nhập sai {this.countWrongPass} lần !!!",
                            "Lỗi đăng nhập",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                }
                else
                {
                    this.countWrongPass = 0;
                    AppConfig.SetValue("Username", username);
                    
                    Username = username;

                    var screen = new MainWindow();
                    screen.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    screen.Show();
                    this.Close();
                }
            }
        }
    }
}
