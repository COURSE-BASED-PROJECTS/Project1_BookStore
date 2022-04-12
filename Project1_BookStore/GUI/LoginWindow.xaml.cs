using Project1_BookStore.BUS;
using Project1_BookStore.Utils;
using System;
using System.Collections.Generic;
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
    public class Icons
    {
        public string pathCloseBtn { get; set; } = "/Resource/Images/Icons/close.png";
        public string pathClosePressedBtn { get; set; } = "/Resource/Images/Icons/close-pressed.png";
        public string pathMaxBtn { get; set; } = "/Resource/Images/Icons/maximize.png";
        public string pathMaxPressedBtn { get; set; } = "/Resource/Images/Icons/maximize-pressed.png";
        public string pathMinBtn { get; set; } = "/Resource/Images/Icons/minimize.png";
        public string pathMinePressedBtn { get; set; } = "/Resource/Images/Icons/minimize-pressed.png";
        public string logo { get; set; } = "/Resource/Images/Icons/logo.png";
        public string upload { get; set; } = "/Resource/Images/Icons/upload.png";
        public string modify { get; set; } = "/Resource/Images/Icons/modify.png";
        public string plus { get; set; } = "/Resource/Images/Icons/plus-square.png";
        public string minus { get; set; } = "/Resource/Images/Icons/minus.png";
        public string arrow_left { get; set; } = "/Resource/Images/Icons/left-arrow.png";
        public string arrow_right { get; set; } = "/Resource/Images/Icons/right-arrow.png";
        public string setting { get; set; } = "/Resource/Images/Icons/info.png";
        public string bell { get; set; } = "/Resource/Images/Icons/bell.png";
        public string sign_out { get; set; } = "/Resource/Images/Icons/sign-out.png";



    }


    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
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
                    var screen = new MainWindow();
                    screen.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    screen.Show();
                    this.Close();
                }
            }
        }
    }
}
