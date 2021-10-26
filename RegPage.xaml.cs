﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void buttRegPage_Click(object sender, RoutedEventArgs e)
        {
            string passCheck = tbPass.Password.ToString();

            if(passCheck.Length < 8) { MessageBox.Show("Длина пароля - минимум восемь символов, повторите ввод", "Пароль"); return; }
            Regex LAT = new Regex("(?=[A-Z])");
            bool LATmatch = LAT.IsMatch(passCheck);
            if (LATmatch != true) { MessageBox.Show("В пароле должна быть минимум одна заглавная латинская буква, повторите ввод", "Пароль"); return; }
            Regex lat = new Regex("(?=[a-z])");
            MatchCollection latMC = lat.Matches(passCheck);
            if (latMC.Count < 3) { MessageBox.Show("Количество строчных латинских букв в пароле должно быть не меньше трех, повторите ввод", "Пароль"); return; }
            Regex cif = new Regex("(?=[0-9])");
            MatchCollection cifMC = cif.Matches(passCheck);
            if(cifMC.Count < 2) { MessageBox.Show("Количество цифр в пароле должно быть не меньше двух, повторите ввод", "Пароль"); return; }
            Regex spec = new Regex("(?=[#?!@$%^&*-])");
            bool specMatch = spec.IsMatch(passCheck);
            if (specMatch != true) { MessageBox.Show("В пароле должен быть минимум один специальный символ (#?!@$%^&*-), повторите ввод", "Пароль"); return; }

            int sex = 1;
            if(rbMan.IsChecked == true)
            {
                sex = 1;
            }
            if (rbWoman.IsChecked == true)
            {
                sex = 2;
            }
            int pasCode = tbPass.Password.GetHashCode();
            Пользователи UserRg = new Пользователи() { Имя = tbName.Text, Фамилия = tbSur.Text, Логин = tbLog.Text, Пароль = pasCode, Пол = sex, Администратор = false};
            Base.DB.Пользователи.Add(UserRg);
            Base.DB.SaveChanges();
            MessageBox.Show("Регистрация успешна!", "Регистрация");
        }

        private void cancelRegPage_Click(object sender, RoutedEventArgs e)
        {
            FrameCl.mainFrame.Navigate(new Default());
        }
    }
}
