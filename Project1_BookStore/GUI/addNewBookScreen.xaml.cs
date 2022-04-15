using Microsoft.Win32;
using Project1_BookStore.BUS;
using Project1_BookStore.DTO;
using Project1_BookStore.Utils;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for addNewBookScreen.xaml
    /// </summary>
    public partial class addNewBookScreen : Window
    {
        public addNewBookScreen()
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
            this.DataContext = _icons;
            //this.WindowState = WindowState.Maximized;
        }

        private void save(object sender, RoutedEventArgs e)
        {
            var book = new BookDTO()
            {
                bookName = nameBook.Text,
                bookAuthor = authorBook.Text,
                bookPrice = int.Parse(priceBook.Text),
                bookPublishedYear = int.Parse(yearPublishBook.Text),
                bookQuantity = 10
            };

            MessageBox.Show("Thêm mới thành công");
        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        private void uploadImg(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Chọn hình ảnh";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                string workingDirectory = Environment.CurrentDirectory;
                string prjUri = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
                string binPath = AppDomain.CurrentDomain.BaseDirectory;
                string des = $"{prjUri}\\Resource\\Images\\BookCovers\\";
                string desBinPath = $"{binPath}\\Resource\\Images\\BookCovers\\";

                CopyImage.Copy(op.FileName, des,"A00"+ $"{BookBUS.findAllBook().Count + 1}" + ".jpg");
                CopyImage.Copy(op.FileName, desBinPath, "A00"+ $"{BookBUS.findAllBook().Count + 1}" + ".jpg");

                _icons.test = "\\Resource\\Images\\BookCovers\\A0040.jpg";
            }
        }
    }
}
