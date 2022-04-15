using Project1_BookStore.DTO;
using Project1_BookStore.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for manageOrdersScreen.xaml
    /// </summary>
    public partial class manageOrdersScreen : Window
    {
        public manageOrdersScreen()
        {
            InitializeComponent();
            reDownButton.Visibility = Visibility.Collapsed;
        }

        public class manageOrderContext : INotifyPropertyChanged
        {
            public Icons _icons { get; set; } = new Icons();
            public int countOrder { get; set; } = 0;

            public event PropertyChangedEventHandler? PropertyChanged;
        }

        manageOrderContext Context = new manageOrderContext();

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
            this.DataContext = Context;
            Context.countOrder = OrderBUS.findAllOrder().Count;
            orderList.ItemsSource = OrderBUS.findAllOrder();
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

        private void addNewOrder(object sender, RoutedEventArgs e)
        {
            var screen = new addNewOrderScreen();
            screen.Show();
        }
    }
}
