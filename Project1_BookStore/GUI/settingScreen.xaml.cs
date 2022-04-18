using Project1_BookStore.DTO;
using Project1_BookStore.Utils;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for settingScreen.xaml
    /// </summary>
    public partial class settingScreen : Window
    {
        public settingScreen()
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
        List<int> numOfBookList = new List<int>(new int[] { 5, 10, 15, 25, 50, 100 });
        List<int> numOfList = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 25, 50, 100 });

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = _icons;
            user.Content = AppConfig.GetValue(AppConfig.Username);

            numOfBook.ItemsSource = numOfBookList;
            numOfBook.SelectedIndex = 0;

            numOfOrder.ItemsSource = numOfList;
            numOfOrder.SelectedIndex = 3;

            numOfPromotion.ItemsSource = numOfList;
            numOfPromotion.SelectedIndex = 3;

            //this.WindowState = WindowState.Maximized;
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

        private void Grid_MouseDown_AnalysicRevenue(object sender, MouseButtonEventArgs e)
        {
            var screen = new analysicRevenue();
            screen.Show();
            this.Close();
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

        private void save (object sender, RoutedEventArgs e)
        {

        }
    }
}
