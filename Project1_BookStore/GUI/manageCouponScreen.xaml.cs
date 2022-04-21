﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using Project1_BookStore.BUS;
using Project1_BookStore.DTO;
using Project1_BookStore.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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
            userName.Content = AppConfig.GetValue(AppConfig.Username);
            user.Content = AppConfig.GetValue(AppConfig.Username);
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

            _rowsPerPage = settingScreen.getRowPerPageManageCouponScreen(); 
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
            AppConfig.SetValue("LastScreen", "GUI/manageCouponScreen.xaml");
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
            var selected = (PromotionDTO)couponList.SelectedItem;
            screen._promotion = (PromotionDTO)selected.Clone();

            if(screen.ShowDialog() == true)
            {
                listPromotions[(_currentPage-1)*_rowsPerPage + couponList.SelectedIndex] = (PromotionDTO)screen._promotion.Clone();

                _totalItems = listPromotions.Count;
                _totalPages = _totalItems / _rowsPerPage +
                        (_totalItems % _rowsPerPage == 0 ? 0 : 1);

                currentPagingText.Content = $"{_currentPage}/{_totalPages}";

                couponList.ItemsSource = listPromotions.Skip((_currentPage - 1) * _rowsPerPage)
                                        .Take(_rowsPerPage)
                                        .ToList();
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


        private void exportData_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (listPromotions.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Tệp PDF (*.pdf)|*.pdf";
                save.FileName = "Danh sách khuyến mãi";

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
                            //define base font for PDF document
                            string vifontPath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\times.ttf";
                            BaseFont viFont = BaseFont.CreateFont(vifontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                            Font title = new Font(viFont, 20f, Font.NORMAL, BaseColor.BLUE);
                            Font header = new Font(viFont, 12f, Font.BOLD, BaseColor.BLACK);
                            Font normal = new Font(viFont, 10f, Font.NORMAL, BaseColor.BLACK);
                            Font underline = new Font(viFont, 10f, Font.UNDERLINE, BaseColor.BLACK);

                            //creating iTextSharp Table from the DataTable data
                            PdfPTable pdfPTable = new PdfPTable(7);
                            int[] intTblWidth = { 7, 15, 15, 7, 22, 22, 12};
                            pdfPTable.SetWidths(intTblWidth);
                            pdfPTable.WidthPercentage = 100;
                            pdfPTable.DefaultCell.BorderWidth = 1;
                            pdfPTable.HorizontalAlignment = Element.ALIGN_CENTER;

                            //adding header columns
                            PdfPCell pdfPCell = new PdfPCell(new Phrase("STT", header));
                            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfPTable.AddCell(pdfPCell);

                            PdfPCell pdfPCell2 = new PdfPCell(new Phrase("Mã khuyến mãi", header));
                            pdfPCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfPTable.AddCell(pdfPCell2);

                            PdfPCell pdfPCell3 = new PdfPCell(new Phrase("Tên khuyến mãi", header));
                            pdfPCell3.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfPTable.AddCell(pdfPCell3);

                            PdfPCell pdfPCell4 = new PdfPCell(new Phrase("Chiết khấu (%)", header));
                            pdfPCell4.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfPTable.AddCell(pdfPCell4);

                            PdfPCell pdfPCell5 = new PdfPCell(new Phrase("Ngày bắt đầu", header));
                            pdfPCell5.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfPTable.AddCell(pdfPCell5);

                            PdfPCell pdfPCell6 = new PdfPCell(new Phrase("Ngày kết thúc", header));
                            pdfPCell6.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfPTable.AddCell(pdfPCell6);

                            PdfPCell pdfPCell7 = new PdfPCell(new Phrase("Trạng thái", header));
                            pdfPCell7.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfPTable.AddCell(pdfPCell7);

                            // adding all rows
                            int i = 1;
                            foreach (var item in listPromotions)
                            {
                                PromotionDTO coupon = (PromotionDTO)item;

                                PdfPCell pdfPCell9 = new PdfPCell(new Phrase((i++).ToString(), normal));
                                pdfPCell9.HorizontalAlignment = Element.ALIGN_CENTER;
                                pdfPTable.AddCell(pdfPCell9);

                                PdfPCell pdfPCell10 = new PdfPCell(new Phrase(coupon.promoID, normal));
                                pdfPCell10.HorizontalAlignment = Element.ALIGN_CENTER;
                                pdfPTable.AddCell(pdfPCell10);

                                PdfPCell pdfPCell11 = new PdfPCell(new Phrase(coupon.promoName, normal));
                                pdfPCell11.HorizontalAlignment = Element.ALIGN_CENTER;
                                pdfPTable.AddCell(pdfPCell11);

                                PdfPCell pdfPCell12 = new PdfPCell(new Phrase(Math.Round(coupon.promoDiscount*100, 2).ToString(), normal));
                                pdfPCell12.HorizontalAlignment = Element.ALIGN_CENTER;
                                pdfPTable.AddCell(pdfPCell12);

                                PdfPCell pdfPCell13 = new PdfPCell(new Phrase(coupon.promoStartTime.ToString(), normal));
                                pdfPCell13.HorizontalAlignment = Element.ALIGN_CENTER;
                                pdfPTable.AddCell(pdfPCell13);

                                PdfPCell pdfPCell14 = new PdfPCell(new Phrase(coupon.promoEndTime.ToString(), normal));
                                pdfPCell14.HorizontalAlignment = Element.ALIGN_CENTER;
                                pdfPTable.AddCell(pdfPCell14);

                                PdfPCell pdfPCell15;
                                
                                if (coupon.promoStatus == true)
                                {
                                    pdfPCell15 = new PdfPCell(new Phrase("Đang áp dụng", normal));
                                }
                                else
                                {
                                    pdfPCell15 = new PdfPCell(new Phrase("Hết hiệu lực", normal));
                                }

                                pdfPCell15.HorizontalAlignment = Element.ALIGN_CENTER;
                                pdfPTable.AddCell(pdfPCell15);
                            }

                            //Exporting to PDF
                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                                PdfWriter.GetInstance(document, fileStream);

                                document.Open();
                                document.AddHeader("Title", "Danh sách khuyến mãi");
                                document.AddLanguage("vi-VN");
                                document.AddTitle("Danh sách khuyến mãi");
                                document.AddCreationDate();

                                var titleDoc = new Phrase("DANH SÁCH KHUYẾN MÃI", title);

                                document.Add(titleDoc);

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

    }
}
