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
    public partial class manageBooksScreen : Window, INotifyPropertyChanged
    {
        public int tabIndex { get; set; } = -1;
        public manageBooksScreen()
        {
            InitializeComponent();
            reDownButton.Visibility = Visibility.Collapsed;
        }

        public class manageBooksContext:INotifyPropertyChanged
        { 
            public Icons _icons { get; set; } = new Icons();
            public int countBook { get; set; } =  0;

            public decimal maxPrice { get; set; } = 0;

            public event PropertyChangedEventHandler? PropertyChanged;
        }

        manageBooksContext Context = new manageBooksContext();
        BindingList<BookDTO> allBookContext = new BindingList<BookDTO>(AddLinkImg.addLinkstoBook(BookBUS.findAllBook()));
        BindingList<BookDTO> nearOutOfBookContext = new BindingList<BookDTO>(AddLinkImg.addLinkstoBook(BookBUS.findTop5()));
        BindingList<BookDTO> bestSellerBookContext = new BindingList<BookDTO>(AddLinkImg.addLinkstoBook(BookBUS.findBestSellerBook()));

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            AppConfig.SetValue("LastScreen", "GUI/manageBooksScreen.xaml");
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
            public BindingList<BookDTO> Books { get; set; }
        }

        BindingList<Tab> tabs = new BindingList<Tab>();

        class ViewModel : INotifyPropertyChanged
        {
            public BindingList<BookDTO> Books { get; set; } = new BindingList<BookDTO>();
            public BindingList<BookDTO> SelectedBooks { get; set; } = new BindingList<BookDTO>();

            public event PropertyChangedEventHandler PropertyChanged;
        }


        ViewModel _vm = new ViewModel();

        int _totalItems = 0;
        int _currentPage = 1;
        int _totalPages = 0;
        int _rowsPerPage = 10;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Context.countBook = BookBUS.findAllBook().Count;

            this.DataContext = Context;
            userName.Content = AppConfig.GetValue(AppConfig.Username);
            user.Content = AppConfig.GetValue(AppConfig.Username);
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

        private void Grid_MouseDown_AnalysicRevenue(object sender, MouseButtonEventArgs e)
        {
            var screen = new analysicRevenue();
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
                Books = new BindingList<BookDTO>()
            };
            tabs.Add(Tab1);
            tabs.Add(Tab2);
            tabs.Add(Tab3);
            tabs.Add(Tab4);
            int i = tabControl.SelectedIndex;
            if (i >= 0 && i != this.tabIndex)
            {
                this.tabIndex = tabControl.SelectedIndex;
                // Thay đổi view model
                _vm.Books = tabs[i].Books;

                _rowsPerPage = settingScreen.getRowPerPageManageBookScreen();
                _currentPage = 1; // Quay lại trang đầu tiên

                _vm.SelectedBooks = new BindingList<BookDTO> (_vm.Books
                    .Skip((_currentPage - 1) * _rowsPerPage)
                    .Take(_rowsPerPage)
                    .ToList());


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
                _vm.SelectedBooks = new BindingList<BookDTO>(_vm.Books
                    .Skip((_currentPage - 1) * _rowsPerPage)
                    .Take(_rowsPerPage)
                    .Take(_rowsPerPage)
                    .ToList());

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
                _vm.SelectedBooks = new BindingList<BookDTO>(_vm.Books
                    .Skip((_currentPage - 1) * _rowsPerPage)
                    .Take(_rowsPerPage)
                    .Take(_rowsPerPage)
                    .ToList());

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
                if (screen.isDeleted == false)
                {
                    _vm.Books[allBooks.SelectedIndex + _rowsPerPage * (_currentPage - 1)] = screen._book;
                    _vm.SelectedBooks = new BindingList<BookDTO>(_vm.Books
                        .Skip((_currentPage - 1) * _rowsPerPage)
                        .Take(_rowsPerPage)
                        .Take(_rowsPerPage)
                        .ToList());

                    // ép cập nhật giao diện
                    tabs[0].Name.ItemsSource = _vm.SelectedBooks;
                }
                else
                {

                    _vm.Books.Remove(_vm.Books[allBooks.SelectedIndex + _rowsPerPage * (_currentPage - 1)]);
                    _vm.SelectedBooks = new BindingList<BookDTO>(_vm.Books
                        .Skip((_currentPage - 1) * _rowsPerPage)
                        .Take(_rowsPerPage)
                        .Take(_rowsPerPage)
                        .ToList());

                    // ép cập nhật giao diện
                    tabs[0].Name.ItemsSource = _vm.SelectedBooks;
                }

                
            }
            
        }
        

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            string keyword = searchBox.Text;
            if (e.Key == Key.Enter && !keyword.Equals(""))
            {
                tabControl.SelectedIndex = 3;

                tabs[3].Books = new BindingList<BookDTO>(AddLinkImg.addLinkstoBook(BookBUS.findBookByName(keyword)));
                _vm.Books = tabs[3].Books;

                _rowsPerPage = Int32.Parse(AppConfig.GetValue(AppConfig.RowPerPageManageBookScreen));
                _currentPage = 1; // Quay lại trang đầu tiên

                _vm.SelectedBooks = new BindingList<BookDTO>(_vm.Books
                    .Skip((_currentPage - 1) * _rowsPerPage)
                    .Take(_rowsPerPage)
                    .Take(_rowsPerPage)
                    .ToList());


                // Tính toán lại thông số phân trang
                _totalItems = _vm.Books.Count;
                _totalPages = _totalItems / _rowsPerPage +
                    (_totalItems % _rowsPerPage == 0 ? 0 : 1);

                currentPagingText.Content = $"{_currentPage}/{_totalPages}";


                // ép cập nhật giao diện
                tabs[3].Name.ItemsSource = _vm.SelectedBooks;

                // cập nhật tổng sản phẩm từng tab
                Context.countBook = _totalItems;

                Context.maxPrice = findMaxPrice(tabs[3].Books);
                slider.Value = Decimal.ToInt32(Context.maxPrice);
            }

        }

        private decimal findMaxPrice(BindingList<BookDTO> books)
        {
            var max = books[0].bookPrice;
            for (int i = 1; i < books.Count; i++)
            {
                if (books[i].bookPrice > max)
                {
                    max = books[i].bookPrice;
                }
            }
            return max;
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double price = slider.Value;

            _vm.Books = filterBookByPrice(tabs[3].Books, price);

            

            _rowsPerPage = settingScreen.getRowPerPageManageBookScreen();

            _vm.SelectedBooks = new BindingList<BookDTO>(_vm.Books
                .Skip((_currentPage - 1) * _rowsPerPage)
                .Take(_rowsPerPage)
                .Take(_rowsPerPage)
                .ToList());


            // Tính toán lại thông số phân trang
            _totalItems = _vm.Books.Count;
            _totalPages = _totalItems / _rowsPerPage +
                (_totalItems % _rowsPerPage == 0 ? 0 : 1);

            if (_currentPage > _totalPages)
            {
                _currentPage--;
            }

            if (_currentPage == 0 && _totalPages > 0)
            {
                _currentPage = 1;
            }
            currentPagingText.Content = $"{_currentPage}/{_totalPages}";


            // ép cập nhật giao diện
            tabs[3].Name.ItemsSource = _vm.SelectedBooks;

            // cập nhật tổng sản phẩm từng tab
            Context.countBook = _totalItems;
        }

        private BindingList<BookDTO> filterBookByPrice(BindingList<BookDTO> books, double price)
        {
            var result = new BindingList<BookDTO>();
            for(int i = 0; i < books.Count; i++)
            {
                if (Decimal.ToDouble(books[i].bookPrice) <= price)
                {
                    result.Add(books[i]);
                }
            }
            return result;
        }
    }
}
