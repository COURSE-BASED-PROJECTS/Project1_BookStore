using Project1_BookStore.DTO;
using Project1_BookStore.BUS;
using Project1_BookStore.GUI;
using Project1_BookStore.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace Project1_BookStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        public class MainWindowContext:INotifyPropertyChanged
        {
            public int soldBooks { get; set; } = 0;
            public int ongoingBooks { get; set; } = 0;
            public int newOrders { get; set; } = 0;

            public string username { get; set; }
            public Icons _icons { get; set; } = new Icons();

            public event PropertyChangedEventHandler? PropertyChanged;
        }
        public MainWindow()
        {
            InitializeComponent();
            reDownButton.Visibility = Visibility.Collapsed;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            AppConfig.SetValue("LastScreen", "GUI/mainwindow.xaml");
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

        MainWindowContext itemMainWindow = new MainWindowContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listDataDated.ItemsSource = AddLinkImg.addLinkstoBook(BookBUS.findTop5()); 

            itemMainWindow.soldBooks = BookBUS.countBookSold();
            itemMainWindow.ongoingBooks = BookBUS.findAllBook().Count;
            itemMainWindow.newOrders = OrderBUS.findAllOrder().Count;

            //itemMainWindow.username = AppConfig.GetValue(AppConfig.Username);
            this.DataContext = itemMainWindow;
            userName.Content = LoginWindow.getUsername();
            user.Content = LoginWindow.getUsername();
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

        private void Grid_MouseDown_AnalysicRevenue(object sender, MouseButtonEventArgs e)
        {
            var screen = new analysicRevenue();
            screen.Show();
            this.Close();
        }
        private void Grid_MouseDown_Setting(object sender, MouseButtonEventArgs e)
        {
            var screen = new settingScreen();
            screen.Show();
            this.Close();
        }

        private void signOut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var result = MessageBox.Show("Bạn muốn đăng xuất khỏi hệ thống?",
                    "Xác Nhận Đăng Xuất",
                    MessageBoxButton.YesNoCancel,
                    MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                AppConfig.SetValue(AppConfig.Username, "null");

                var screen = new LoginWindow();
                screen.Show();
                this.Close();
            }
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = datePicker.SelectedDate;
            string formatted = "";
            if (selectedDate.HasValue)
            {
                formatted = selectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            }
            itemMainWindow.ongoingBooks = BookBUS.findAllBook().Count;
            itemMainWindow.soldBooks = BookBUS.countBookSoldInDate(formatted);
            itemMainWindow.newOrders = OrderBUS.countOrderInDate(formatted);

        }

    }
}
