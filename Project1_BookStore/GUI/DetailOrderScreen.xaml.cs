using Project1_BookStore.BUS;
using Project1_BookStore.DTO;
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
    /// Interaction logic for DetailOrderScreen.xaml
    /// </summary>
    public partial class DetailOrderScreen : Window
    {
        public OrderDTO _detail { get; set; }
        public DetailOrderScreen()
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
            idOrder.DataContext = _detail;
            total.DataContext = _detail;
            id.DataContext = _detail;
            customer.DataContext = CustomerBUS.findCustomerByID(_detail.cusPhoneNumber);
            infoOrderBasic.DataContext = _detail;
            GridContent.ItemsSource = OrderDetailBUS.findOrderDetailByOrderID(_detail.ordersID);

            this.DataContext = _icons;
            //this.WindowState = WindowState.Maximized;
        }

        private void deleteOrder(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa đơn hàng {_detail.ordersID}", "Xác nhận", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                OrderBUS.DeleteOrder(_detail.ordersID);

                MessageBox.Show("Xóa thành công");
                DialogResult = true;
            }
            else
            {
            }
        }
    }
}
