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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AuthReg
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class AdminMenu : Page
    {
        public AdminMenu()
        {
            InitializeComponent();
            dgUsers.ItemsSource = Base.DB.Пользователи.ToList();
        }

        private void buttUserShow_Click(object sender, RoutedEventArgs e)
        {
            stMenu.Visibility = Visibility.Collapsed;
            stDgUsers.Visibility = Visibility.Visible;
        }

        private void buttExit_Click(object sender, RoutedEventArgs e)
        {
            FrameCl.mainFrame.Navigate(new Default());
        }

        private void buttShowExit_Click(object sender, RoutedEventArgs e)
        {
            stMenu.Visibility = Visibility.Visible;
            stDgUsers.Visibility = Visibility.Collapsed;
        }
    }
}
