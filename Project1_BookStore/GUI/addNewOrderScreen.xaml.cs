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
    /// Interaction logic for addNewOrderScreen.xaml
    /// </summary>
    public partial class addNewOrderScreen : Window
    {

        
        public addNewOrderScreen()
        {
            InitializeComponent();
            reDownButton.Visibility = Visibility.Collapsed;

            nameCus_StackPanel.Visibility = Visibility.Collapsed;
            phone_StackPanel.Visibility = Visibility.Collapsed;
            addCustomer.Visibility = Visibility.Collapsed;
        }
        public class addOrderContext : INotifyPropertyChanged
        {
            public Icons _icons { get; set; } = new Icons();
            public decimal totalPrice { get; set; } = 0;

            public event PropertyChangedEventHandler? PropertyChanged;
        }

        addOrderContext Context = new addOrderContext();
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

        private string orderID { get; set; }
        private List<BookDTO> allBooks = new List<BookDTO>();
        private List<CustomerDTO> allCustomers = CustomerBUS.findAllCustomer();

        public List<string> options { get; set; } = new List<string>() { "Khách", "Khách hàng mới" };
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            allBooks = BookBUS.findAllBook();
            listOfBook.ItemsSource = allBooks;

            orderID = CreateOrderID.generatedID();
            orderIDText.Text = orderID;

            foreach (var customer in allCustomers)
                options.Add(customer.cusName);

            listOfCus.ItemsSource = options;

            this.DataContext = Context;
            //this.WindowState = WindowState.Maximized;
        }

        private void save(object sender, RoutedEventArgs e)
        {

        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        class Order : INotifyPropertyChanged
        {
            public string bookName { get; set; }
            public string bookAuthor { get; set; }
            public decimal bookPrice { get; set; }
            public int amount { get; set; }
            public string promoName { get; set; }
            public decimal priceDiscount { get; set; }
            public decimal priceCurrent { get; set; }

            public event PropertyChangedEventHandler? PropertyChanged;
        }

        BindingList<Order> orders = new BindingList<Order>();

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            int index = listOfBook.SelectedIndex;

            var book = allBooks[index];

            var promoForBook = PromotionBUS.findBestPromotion(book.tobID);
            var order = new Order();
            if (promoForBook != null)
            {
                order = new Order()
                {
                    bookName = book.bookName,
                    bookAuthor = book.bookAuthor,
                    bookPrice = book.bookPrice,
                    amount = 1,
                    promoName = promoForBook.promoName,
                    priceDiscount = -(decimal)promoForBook.promoDiscount/100 * book.bookPrice,
                    priceCurrent = book.bookPrice - (decimal)promoForBook.promoDiscount/100 * book.bookPrice
                };
            } else
            {
                order = new Order()
                {
                    bookName = book.bookName,
                    bookAuthor = book.bookAuthor,
                    bookPrice = book.bookPrice,
                    amount = 1,
                    promoName = "",
                    priceDiscount = 0,
                    priceCurrent = book.bookPrice
                };
            }
            int indexOfOrder = orders.ToList().FindIndex(item => order.bookName == item.bookName);
            if (indexOfOrder != -1)
            {
                orders[indexOfOrder].amount += 1;
                orders[indexOfOrder].priceDiscount = ((decimal)promoForBook.promoDiscount / 100 * book.bookPrice) * orders[indexOfOrder].amount;

                orders[indexOfOrder].priceCurrent = (book.bookPrice - (decimal)promoForBook.promoDiscount / 100 * book.bookPrice) * orders[indexOfOrder].amount;
            }
            else
            {
                orders.Add(order);
            }

            Context.totalPrice += order.priceCurrent;
            
            listBookOrder.ItemsSource = orders;
        }

        private void deleteItem(object sender, RoutedEventArgs e)
        {

        }

        private void QuantityNumericHandler(object sender, TextChangedEventArgs e)
        {
            bool enteredLetter = false;
            Queue<char> text = new Queue<char>();
            foreach (var ch in this.quantityBook.Text)
            {
                if (char.IsDigit(ch))
                {
                    text.Enqueue(ch);
                }
                else
                {
                    enteredLetter = true;
                }
            }

            if (enteredLetter)
            {
                StringBuilder sb = new StringBuilder();
                while (text.Count > 0)
                {
                    sb.Append(text.Dequeue());
                }

                this.quantityBook.Text = sb.ToString();
                this.quantityBook.SelectionStart = this.quantityBook.Text.Length;
            }
        }

        private void listOfCus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listOfCus.SelectedIndex == 1)
            {
                nameCus_StackPanel.Visibility = Visibility.Visible;
                phone_StackPanel.Visibility = Visibility.Visible;
                addCustomer.Visibility = Visibility.Visible;
            }
            else
            {
                nameCus_StackPanel.Visibility = Visibility.Collapsed;
                phone_StackPanel.Visibility = Visibility.Collapsed;
                addCustomer.Visibility = Visibility.Collapsed;
            }
        }
    }
}
