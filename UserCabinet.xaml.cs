using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Логика взаимодействия для UserCabinet.xaml
    /// </summary>
    public partial class UserCabinet : Page
    {
        private bool _tumbler;
        private Пользователи _user;
        private string _path;
        private ФотоПользователя _userPic;
        public UserCabinet(Пользователи User, bool tumbler)
        {
            InitializeComponent();
            _tumbler = tumbler;
            _user = User;
            tbName.Text = _user.Имя;
            tbSurname.Text = _user.Фамилия;
            tbLogin.Text = _user.Логин;
            if (User.ФотоПользователя != null && User.ФотоПользователя.Фото != null)
            {
                byte[] binArr = User.ФотоПользователя.Фото;
                BitmapImage bmUserPic = new BitmapImage();
                using (MemoryStream ms = new MemoryStream(binArr))
                {
                    bmUserPic.BeginInit();
                    bmUserPic.StreamSource = ms;
                    bmUserPic.CacheOption = BitmapCacheOption.OnLoad;
                    bmUserPic.EndInit();
                }
                UserPic.Source = bmUserPic;
            }
        }

        private void ButtEditClick(object sender, RoutedEventArgs e)
        {
            EditWin editWin = new EditWin(_user);
            editWin.ShowDialog();
            FrameCl.mainFrame.Navigate(new UserCabinet(_user, _tumbler));
        }

        private void PicEditClick(object sender, RoutedEventArgs e)
        {
            ФотоПользователя picture = Base.DB.ФотоПользователя.FirstOrDefault(x => x.IDUser == _user.IDUser);
            if (picture == null)
            {
                _userPic = new ФотоПользователя();
                _userPic.IDUser = _user.IDUser;
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();
                _path = OFD.FileName;
                System.Drawing.Image sdImage = System.Drawing.Image.FromFile(_path);
                ImageConverter imageConverter = new ImageConverter();
                byte[] binArr = (byte[])imageConverter.ConvertTo(sdImage, typeof(byte[]));
                _userPic.Фото = binArr;
                Base.DB.ФотоПользователя.Add(_userPic);
                Base.DB.SaveChanges();
                MessageBox.Show("Фото добавлено в профиль!", "Личный кабинет", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();
                _path = OFD.FileName;
                System.Drawing.Image sdImage = System.Drawing.Image.FromFile(_path);
                ImageConverter imageConverter = new ImageConverter();
                byte[] binArr = (byte[])imageConverter.ConvertTo(sdImage, typeof(byte[]));
                picture.Фото = binArr;
                Base.DB.SaveChanges();
                MessageBox.Show("Фото обновлено!", "Личный кабинет", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            FrameCl.mainFrame.Navigate(new UserCabinet(_user, _tumbler));
        }

        private void ButtExitClick(object sender, RoutedEventArgs e)
        {
            if (_tumbler == true)
            {
                FrameCl.mainFrame.Navigate(new AdminMenu(_user));
            }
            else
            {
                FrameCl.mainFrame.Navigate(new Default());
            }
        }
    }
}
