using Project1_BookStore.BUS;
using Project1_BookStore.DTO;
using Project1_BookStore.Utils;
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
    /// Interaction logic for manageCouponScreen.xaml
    /// </summary>
    public partial class manageCouponScreen : Window, INotifyPropertyChanged
    {
        public manageCouponScreen()
        {
            InitializeComponent();
            reDownButton.Visibility = Visibility.Collapsed;
        }

        public class manageCouponContext : INotifyPropertyChanged
        {
            public Icons _icons { get; set; } = new Icons();
            public int countCoupon { get; set; } = 0;

            public event PropertyChangedEventHandler? PropertyChanged;
        }

        manageCouponContext Context = new manageCouponContext();
        BindingList<PromotionDTO> listPromotions = new BindingList<PromotionDTO>(PromotionBUS.findAllPromotion());

        int _totalItems = 0;
        int _currentPage = 1;
        int _totalPages = 0;
        int _rowsPerPage = 3;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Context.countCoupon = listPromotions.Count;
            this.DataContext = Context;

            _rowsPerPage = Int32.Parse(AppConfig.GetValue(AppConfig.RowPerPageManageCouponScreen)); 
            _totalItems = listPromotions.Count;
            _totalPages = _totalItems / _rowsPerPage +
                    (_totalItems % _rowsPerPage == 0 ? 0 : 1);

            currentPagingText.Content = $"{_currentPage}/{_totalPages}";

            couponList.ItemsSource = listPromotions.Skip((_currentPage - 1) * _rowsPerPage)
                                    .Take(_rowsPerPage)
                                    .ToList();
            //couponList.ItemsSource = listPromotions;
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

        private void addNewCoupon(object sender, RoutedEventArgs e)
        {
            var screen = new addNewCouponScreen();

            if (screen.ShowDialog() == true)
            {
                var promotion = screen._promotion;
                listPromotions.Add(promotion);

                Context.countCoupon = listPromotions.Count;
                couponList.ItemsSource = listPromotions.Skip((_currentPage - 1) * _rowsPerPage)
                                    .Take(_rowsPerPage)
                                    .ToList();
            }
        }

        private void modifyItem(object sender, RoutedEventArgs e)
        {
            var screen = new modifyCouponScreen();
            screen._promotion = (PromotionDTO)couponList.SelectedItem;

            if(screen.ShowDialog() == true)
            {
                listPromotions[couponList.SelectedIndex] = screen._promotion;
            }
        }

        private void nextPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _currentPage++;
            if (_currentPage <= _totalPages)
            {
                currentPagingText.Content = $"{_currentPage}/{_totalPages}";

                couponList.ItemsSource = listPromotions.Skip((_currentPage - 1) * _rowsPerPage)
                                        .Take(_rowsPerPage)
                                        .ToList();
            }
            else
            {
                _currentPage--;
            }
        }

        private void previousPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _currentPage--;
            if (_currentPage > 0)
            {
                currentPagingText.Content = $"{_currentPage}/{_totalPages}";

                couponList.ItemsSource = listPromotions.Skip((_currentPage - 1) * _rowsPerPage)
                                        .Take(_rowsPerPage)
                                        .ToList();
            }
            else
            {
                _currentPage++;
            }
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

        private void deleteItem(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự có muốn tắt khuyến mãi","Xác nhận", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                // Do not close the window    
                PromotionDTO item = (PromotionDTO)couponList.SelectedItem;

                item.promoStatus = false;
                listPromotions.Remove(item);
                PromotionBUS.UpdatePromotion(item);

                MessageBox.Show($"Tắt khuyến mãi {item.promoID}: {item.promoName} thành công!!!");
            }
            else
            {
                // do nothing
            }

            
        }
    }
}
