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

namespace AuthReg
{
    /// <summary>
    /// Логика взаимодействия для EditWin.xaml
    /// </summary>
    public partial class EditWin : Window
    {
        Пользователи _user;
        public EditWin(Пользователи user)
        {
            InitializeComponent();
            _user = user;
            tbNewName.Text = user.Имя;
            tbNewSurname.Text = user.Фамилия;
            tbNewLogin.Text = user.Логин;
        }

        private void buttSend_Click(object sender, RoutedEventArgs e)
        {
            _user.Имя = tbNewName.Text;
            _user.Фамилия = tbNewSurname.Text;
            _user.Логин = tbNewLogin.Text;
            _user.Пароль = tbNewPass.GetHashCode();
            Base.DB.SaveChanges();
            MessageBox.Show("Данные обнавлены!", "Личный кабинет", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            this.Close();
        }
    }
}
