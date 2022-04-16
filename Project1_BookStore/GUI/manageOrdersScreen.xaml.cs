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
using Microsoft.Win32;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;

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

        
        List<OrderDTO> listOrders = OrderBUS.findAllOrder();

        int _totalItems = 0;
        int _currentPage = 1;
        int _totalPages = 0;
        int _rowsPerPage = 3;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = Context;
            
            _totalItems = listOrders.Count;
            Context.countOrder = _totalItems;
            _totalPages = _totalItems / _rowsPerPage +
                    (_totalItems % _rowsPerPage == 0 ? 0 : 1);

            currentPagingText.Content = $"{_currentPage}/{_totalPages}";

            orderList.ItemsSource = listOrders.Skip((_currentPage - 1) * _rowsPerPage)
                                    .Take(_rowsPerPage)
                                    .ToList();
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

        private void exportData_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(orderList.Items.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Tệp PDF (*.pdf)|*.pdf";
                save.FileName = "Danh sách đơn hàng";

                bool errMessage = false;
                if (save.ShowDialog() == true)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            errMessage = true;
                            MessageBox.Show("Không thể lưu tập tin vào ổ đĩa " + ex.Message);
                        }
                    }
                    else
                    {
                        //do nothing
                    }

                    if (!errMessage)
                    {
                        try
                        {
                            //creating iTextSharp Table from the DataTable data
                            PdfPTable pdfPTable = new PdfPTable(6);
                            pdfPTable.DefaultCell.Padding = 20;
                            pdfPTable.WidthPercentage = 100;
                            pdfPTable.DefaultCell.BorderWidth = 1;
                            pdfPTable.HorizontalAlignment = Element.ALIGN_CENTER;

                            //adding header columns
                            pdfPTable.AddCell(new PdfPCell(new Phrase("STT")));
                            pdfPTable.AddCell(new PdfPCell(new Phrase("Mã đơn hàng")));
                            pdfPTable.AddCell(new PdfPCell(new Phrase("Khách hàng")));
                            pdfPTable.AddCell(new PdfPCell(new Phrase("Tổng tiền")));
                            pdfPTable.AddCell(new PdfPCell(new Phrase("Ngày tạo")));
                            pdfPTable.AddCell(new PdfPCell(new Phrase("Người lập HĐ")));

                            // adding all rows
                            int i = 1;
                            foreach (var item in listOrders)
                            {
                                OrderDTO order = (OrderDTO)item;
                                pdfPTable.AddCell(new PdfPCell(new Phrase((i++).ToString())));
                                pdfPTable.AddCell(new PdfPCell(new Phrase(order.ordersID)));
                                pdfPTable.AddCell(new PdfPCell(new Phrase(order.cusPhoneNumber)));
                                pdfPTable.AddCell(new PdfPCell(new Phrase(order.ordersPrices.ToString())));
                                pdfPTable.AddCell(new PdfPCell(new Phrase(order.ordersTime.ToString())));
                                pdfPTable.AddCell(new PdfPCell(new Phrase(order.accUsername)));
                            }

                            //Exporting to PDF
                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                                PdfWriter.GetInstance(document, fileStream);
                                document.Open();
                                document.AddHeader("Title", "Danh sách đơn hàng");
                                document.AddLanguage("vi-VN");
                                document.AddTitle("Title");
                                document.AddCreationDate();

                                BaseFont viFont = BaseFont.CreateFont();
                                Font head = new Font(viFont, 12f, Font.NORMAL, BaseColor.BLUE);
                                Font normal = new Font(viFont, 10f, Font.NORMAL, BaseColor.BLACK);
                                Font underline = new Font(viFont, 10f, Font.UNDERLINE, BaseColor.BLACK);

                                document.Add(new Phrase("\t\t\t\t\t\t\t\t\t\t\t\tDANH SÁCH ĐƠN HÀNG\n\n\n", head));

                                document.Add(pdfPTable);
                                document.Close();
                                fileStream.Close();
                            }

                            MessageBox.Show("Xuất dữ liệu thành công!",
                                            "Xuất dữ liệu", 
                                            MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xuất dữ liệu!", 
                                            "Xuất dữ liệu", 
                                            MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    //do nothing
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu!", 
                                "Xuất dữ liệu", 
                                MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void nextPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _currentPage++;
            if (_currentPage <= _totalPages)
            {
                currentPagingText.Content = $"{_currentPage}/{_totalPages}";

                orderList.ItemsSource = listOrders.Skip((_currentPage - 1) * _rowsPerPage)
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

                orderList.ItemsSource = listOrders.Skip((_currentPage - 1) * _rowsPerPage)
                                        .Take(_rowsPerPage)
                                        .ToList();
            }
            else
            {
                _currentPage++;
            }
        }
    }
}
