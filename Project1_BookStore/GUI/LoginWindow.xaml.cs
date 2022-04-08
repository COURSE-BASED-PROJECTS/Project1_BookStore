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

            var user = UserBUS.findUser(username);

            if (user == null)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu sai!",
                    "Lỗi đăng nhập",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            } else
            {
                /*var passwordInBytes = Encoding.UTF8.GetBytes(password);

                var entropy = new byte[20];
                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(entropy);
                }
                var entropyBase64 = Convert.ToBase64String(entropy);

                var cypherText = ProtectedData.Protect(passwordInBytes, entropy,
                    DataProtectionScope.CurrentUser);
                var cypherTextBase64 = Convert.ToBase64String(cypherText);

                AppConfig.SetValue(AppConfig.Username, username);
                AppConfig.SetValue(AppConfig.Password, cypherTextBase64);
                AppConfig.SetValue(AppConfig.Entropy, entropyBase64);*/
                if (password.Equals(user.password))
                {
                    var screen = new MainWindow();
                    screen.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    screen.Show();
                    this.Close();
                } else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu sai!",
                    "Lỗi đăng nhập",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                }
            }

        }
    }
}
