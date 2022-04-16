using Project1_BookStore.DTO;
using System;
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
using System.Windows.Shapes;

namespace Project1_BookStore.GUI
{
    /// <summary>
    /// Interaction logic for DetailBookScreen.xaml
    /// </summary>
    public partial class DetailBookScreen : Window
    {
        DetailBookScreenContext Context = new DetailBookScreenContext();
        public DetailBookScreen(BookDTO book)
        {
            InitializeComponent();
            reDownButton.Visibility = Visibility.Collapsed;
            Context._book = (BookDTO) book.Clone();
            Context._book.linkImg = $"/Resource/Images/BookCovers/{Context._book.bookID}.jpg";
        }

        class DetailBookScreenContext
        {
            public Icons _icons { get; set; } = new Icons();
            public BookDTO _book { get; set; }
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = Context;
        }
    }
}
