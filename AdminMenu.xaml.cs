using System.Windows;
using System.Windows.Controls;

namespace AuthReg
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class AdminMenu : Page
    {
        private Пользователи _user;
        public AdminMenu(Пользователи user)
        {
            InitializeComponent();
            _user = user;
            FrameCl.AdminFrame = AdminFrame;
        }

        private void buttUserShow_Click(object sender, RoutedEventArgs e)
        {
            FrameCl.AdminFrame.Navigate(new adUsers());
        }

        private void buttExit_Click(object sender, RoutedEventArgs e)
        {
            FrameCl.mainFrame.Navigate(new Default());
        }

        private void buttLess_Click(object sender, RoutedEventArgs e)
        {
            FrameCl.AdminFrame.Navigate(new adShow());
        }

        private void buttSpeaks_Click(object sender, RoutedEventArgs e)
        {
            FrameCl.AdminFrame.Navigate(new adSpCs());
        }

        private void buttCreateEdit_Click(object sender, RoutedEventArgs e)
        {
            FrameCl.AdminFrame.Navigate(new createEdit());
        }

        private void buttCab_Click(object sender, RoutedEventArgs e)
        {
            FrameCl.mainFrame.Navigate(new UserCabinet(_user, true));
        }
    }
}
