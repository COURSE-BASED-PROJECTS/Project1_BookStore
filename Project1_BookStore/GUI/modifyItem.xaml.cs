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

namespace Project1_BookStore
{
    /// <summary>
    /// Interaction logic for modifyItem.xaml
    /// </summary>
    public partial class modifyItem : Window
    {
        public TypeOfBookDTO editedType { get; set; }
        public string id { get; set; } = "Binding";
        public modifyItem(TypeOfBookDTO type)
        {
            InitializeComponent();
            
            reDownButton.Visibility = Visibility.Collapsed;

            editedType = (TypeOfBookDTO)type.Clone();
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
            DataContext = editedType;
            DataContext = id;
            DataContext = new Icons();  
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (!TypeOfBookBUS.UpdateTypeOfBook(editedType))
            {
                MessageBox.Show("Cập nhật không thành công!",
                                "Cập nhập thể loại sách",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //MessageBox.Show("Cập nhật thành công!",
            //                "Cập nhật thể loại sách",
            //                MessageBoxButton.OK, MessageBoxImage.Information);

            DialogResult = true;
        }

        private void nameType_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
