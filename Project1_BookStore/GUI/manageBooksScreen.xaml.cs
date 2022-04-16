using Project1_BookStore.DTO;
using Project1_BookStore.BUS;
using Project1_BookStore.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for manageBooksScreen.xaml
    /// </summary>
    public partial class manageBooksScreen : Window
    {
        public manageBooksScreen()
        {
            InitializeComponent();
            reDownButton.Visibility = Visibility.Collapsed;
        }

        public class manageBooksContext:INotifyPropertyChanged
        { 
            public Icons _icons { get; set; } = new Icons();
            public int countBook { get; set; } =  0;

            public event PropertyChangedEventHandler? PropertyChanged;
        }

        manageBooksContext Context = new manageBooksContext();
        List<BookDTO> allBookContext = new List<BookDTO>(AddLinkImg.addLinkstoBook(BookBUS.findAllBook()));
        List<BookDTO> nearOutOfBookContext = new List<BookDTO>(AddLinkImg.addLinkstoBook(BookBUS.findTop5()));
        List<BookDTO> bestSellerBookContext = new List<BookDTO>(AddLinkImg.addLinkstoBook(BookBUS.findBestSellerBook()));

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
        class Tab
        {
            public ListView Name { get; set; }
            public List<BookDTO> Books { get; set; }
        }

        List<Tab> tabs = new List<Tab>();

        class ViewModel : INotifyPropertyChanged
        {
            public List<BookDTO> Books { get; set; } = new List<BookDTO>();
            public List<BookDTO> SelectedBooks { get; set; } = new List<BookDTO>();

            public event PropertyChangedEventHandler PropertyChanged;
        }


        ViewModel _vm = new ViewModel();

        int _totalItems = 0;
        int _currentPage = 1;
        int _totalPages = 0;
        int _rowsPerPage = 10;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Context.countBook = BookBUS.findAllBook().Count;

            this.DataContext = Context;
            //_totalItems = allBookContext.Count;
            //_totalPages = _totalItems / _rowsPerPage +
            //        (_totalItems % _rowsPerPage == 0 ? 0 : 1);

            //allBooks.ItemsSource = allBookContext
            //                       .Skip((_currentPage - 1) * _rowsPerPage)
            //                       .Take(_rowsPerPage)
            //                       .ToList();
            //
            //currentPagingText.Content = $"{_currentPage}/{_totalPages}";
            //nearOutOfBooks.ItemsSource = nearOutOfBookContext;
            //bestSellerBooks.ItemsSource = bestSellerBookContext;
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

        private void addNewBook(object sender, RoutedEventArgs e)
        {
            var screen = new addNewBookScreen();
            if(screen.ShowDialog() == true)
            {
                var book = screen._newBook;

                //Add new book to temporary system
                allBookContext.Add(book);

                if(book.bookQuantity < 5)
                {
                    nearOutOfBookContext.Add(book);
                }
                Context.countBook = allBookContext.Count;


                //Add new book to database
                BookBUS.InsertBook(book);
                MessageBox.Show("Thêm mới thành công!");
            }

        }

        private void uploadDataScreen(object sender, RoutedEventArgs e)
        {
            var screen = new uploadDataScreen();
            screen.ShowDialog();
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

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Tab1 = new Tab()
            {
                Name = allBooks,
                Books = allBookContext
            };
            var Tab2 = new Tab()
            {
                Name = bestSellerBooks,
                Books = bestSellerBookContext
            };
            var Tab3 = new Tab()
            {
                Name = nearOutOfBooks,
                Books = nearOutOfBookContext
            };
            var Tab4 = new Tab()
            {
                Name = searchResult,
                Books = new List<BookDTO>()
            };
            tabs.Add(Tab1);
            tabs.Add(Tab2);
            tabs.Add(Tab3);
            tabs.Add(Tab4);
            int i = tabControl.SelectedIndex;
            if (i >= 0)
            {
                // Thay đổi view model
                _vm.Books = tabs[i].Books;

                _currentPage = 1; // Quay lại trang đầu tiên

                _vm.SelectedBooks = _vm.Books
                    .Skip((_currentPage - 1) * _rowsPerPage)
                    .Take(_rowsPerPage)
                    .ToList();


                // Tính toán lại thông số phân trang
                _totalItems = _vm.Books.Count;
                _totalPages = _totalItems / _rowsPerPage +
                    (_totalItems % _rowsPerPage == 0 ? 0 : 1);

                currentPagingText.Content = $"{_currentPage}/{_totalPages}";


                // ép cập nhật giao diện
                tabs[i].Name.ItemsSource = _vm.SelectedBooks;

                // cập nhật tổng sản phẩm từng tab
                Context.countBook = _totalItems;
            }
        }

        private void nextPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int i = tabControl.SelectedIndex;
            _currentPage++;
            if (_currentPage <= _totalPages)
            {
                _vm.SelectedBooks = _vm.Books
                    .Skip((_currentPage - 1) * _rowsPerPage)
                    .Take(_rowsPerPage)
                    .Take(_rowsPerPage)
                    .ToList();

                // ép cập nhật giao diện
                tabs[i].Name.ItemsSource = _vm.SelectedBooks;
                currentPagingText.Content = $"{_currentPage}/{_totalPages}";
            }
            else
            {
                _currentPage--;
            }
        }

        private void previousPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int i = tabControl.SelectedIndex;
            _currentPage--;
            if (_currentPage > 0)
            {
                _vm.SelectedBooks = _vm.Books
                        .Skip((_currentPage - 1) * _rowsPerPage)
                        .Take(_rowsPerPage)
                        .ToList();

                // ép cập nhật giao diện
                tabs[i].Name.ItemsSource = _vm.SelectedBooks;
                currentPagingText.Content = $"{_currentPage}/{_totalPages}";
            }
            else
            {
                _currentPage++;
            }
        }

        private void modifyTypeOfBook(object sender, RoutedEventArgs e)
        {
            var screen = new modifyTypeOfBook();
            screen.ShowDialog();
        }

        private void modifyItem(object sender, RoutedEventArgs e)
        {
            var book = (BookDTO)allBooks.SelectedItem;
            var screen = new DetailBookScreen(book);

            if (screen.ShowDialog() == true)
            {
                // write changed things here!
            }
        }
    }
}
