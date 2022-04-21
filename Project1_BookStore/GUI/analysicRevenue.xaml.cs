using LiveCharts;
using LiveCharts.Wpf;
using Project1_BookStore.BUS;
using Project1_BookStore.DTO;
using Project1_BookStore.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
    /// Interaction logic for analysicRevenue.xaml
    /// </summary>
    public partial class analysicRevenue : Window
    {
        public analysicRevenue()
        {
            InitializeComponent();
            reDownButton.Visibility = Visibility.Collapsed;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            AppConfig.SetValue("LastScreen", "GUI/analysicRevenue.xaml");
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

        private List<string> getDaysAgo(int n)
        {
            List<string> getDaysAgo = new List<string>();

            for (int i = n; i >= 1; i--)
            {
                DateTime nDaysAgo = DateTime.Today.AddDays(-i);
                getDaysAgo.Add(nDaysAgo.ToString("dd/MM/yyyy"));
            }

            return getDaysAgo;
        }

        private ChartValues<double> getBookSold(int n)
        {
            ChartValues<double> result = new ChartValues<double>();
            List<string> getDays = getDaysAgo(n);

            for (int i = 0; i < n; i++)
            {
                result.Add(OrderBUS.countBookSold(getDays[i]));
            }

            return result;
        }

        private ChartValues<double> RevenueInYear()
        {
            ChartValues<double> result = new ChartValues<double>();

            for (int i = 1; i <= 12; i++)
            {
                result.Add(OrderBUS.countRevenueByMonth("0" + i.ToString()));
            }

            return result;
        }

        Icons _icons = new Icons();
        PointShapeLine revenue = new PointShapeLine();
        PointShapeLine quantity = new PointShapeLine();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            user.Content = App.Username;

            today.Content = DateTime.Now.ToString("dd/MM/yyyy");
            this.DataContext = _icons;
            getDaysAgo(5);

            revenue.SeriesCollection = new SeriesCollection()
            {
                new LineSeries
                {
                    Title = "Doanh thu",
                    Values = RevenueInYear(),
                }
            };
            quantity.SeriesCollection = new SeriesCollection()
            {
                new LineSeries
                {
                    Title = "Doanh số",
                    Values = getBookSold(10),
                    PointForeground = Brushes.Orange,
                }
            };
            revenue.Labels = new[] { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5",
            "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"};

            var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");

            revenue.YFormatter = value => String.Format(info, "{0:c}", value);

            quantity.Labels = getDaysAgo(10).ToArray();
            //quantity.YFormatter = value => value.ToString("C");

            revenueChart.DataContext = revenue;
            quantityChart.DataContext = quantity;
        }

        private void daysSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int index = daysSelection.SelectedIndex;

            if (index == 0 && quantity.SeriesCollection != null)
            {
                quantity.Labels = getDaysAgo(5).ToArray();
                quantity.SeriesCollection[0].Values = getBookSold(5);
                quantityChart.DataContext = quantity;
            }
            else if (index == 1 && quantity.SeriesCollection != null)
            {
                quantity.Labels = getDaysAgo(10).ToArray();
                quantity.SeriesCollection[0].Values = getBookSold(10);
                quantityChart.DataContext = quantity;
            }
        }

    }
}
