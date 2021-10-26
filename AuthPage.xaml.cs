using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AuthReg
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        string path = "Users.csv";
        List<Users> Users = new List<Users>();
        public AuthPage()
        {
            InitializeComponent();
        }

        private void buttAuthPage_Click(object sender, RoutedEventArgs e)
        {
            int passCode = tbPassAuth.Password.GetHashCode();
            Пользователи User = Base.DB.Пользователи.FirstOrDefault(x => x.Логин == tbLogAuth.Text && x.Пароль == passCode);
            if (User != null)
            {
                if (User.Администратор == true)
                {
                    MessageBox.Show("Добро пожаловать на борт, капитан " + User.Имя + "!", "Авторизация");
                    FrameCl.mainFrame.Navigate(new AdminMenu());
                }
                else
                {
                    MessageBox.Show("Здравствуйте, " + User.Имя + "!", "Авторизация");
                    FrameCl.mainFrame.Navigate(new WelcomePage());
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден, повторите ввод или зарегистрируйтесь!", "Авторизация");
            }
        }

        private void cancelAuthPage_Click(object sender, RoutedEventArgs e)
        {
            FrameCl.mainFrame.Navigate(new Default());
        }
    }
}
