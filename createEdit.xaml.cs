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
    /// Логика взаимодействия для createEdit.xaml
    /// </summary>
    public partial class createEdit : Page
    {
        Занятия Lesson = new Занятия();
        int index = 0;
        bool createFlag;
        Занятия less;
        public createEdit()
        {
            InitializeComponent();
            cbCourse.ItemsSource = Base.DB.Курсы.ToList();
            cbCourse.SelectedValuePath = "IDCourse";
            cbCourse.DisplayMemberPath = "НазваниеКурса";
        }
        public createEdit(Занятия lessUpd)
        {
            InitializeComponent();
            cbCourse.ItemsSource = Base.DB.Курсы.ToList();
            cbCourse.SelectedValuePath = "IDCourse";
            cbCourse.DisplayMemberPath = "НазваниеКурса";

            less = lessUpd;

            tbTheme.Text = lessUpd.Тема;
            dpDate.SelectedDate = lessUpd.Дата;
            tbPrive.Text = lessUpd.Стоимость.ToString();
            if(lessUpd.Площадка == 1)
            {
                rbDiscord.IsChecked = true;
            }
            else
            {
                rbZoom.IsChecked = true;
            }
            cbCourse.SelectedIndex = (int)lessUpd.Курс - 1;
            cbSpeaker.SelectedIndex = (int)lessUpd.Ведущий - 1;
        }
        private void buttCreate_Click(object sender, RoutedEventArgs e)
        {
            if (cbSpeaker.SelectedItem == null)
            {
                MessageBox.Show("Ошибка! Проверьте ввод и повторите", "Создание занятия", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    int idSpeaker = 1;
                    switch (cbSpeaker.SelectedItem.ToString())
                    {
                        case "Мухина Л.В.":
                            idSpeaker = 1;
                            break;
                        case "Мухин Н.А.":
                            idSpeaker = 2;
                            break;
                        case "Дергачев Д.А.":
                            idSpeaker = 3;
                            break;
                        case "Тараканова Н.А.":
                            idSpeaker = 4;
                            break;
                    }
                    Lesson.Курс = cbCourse.SelectedIndex + 1;
                    Lesson.Тема = tbTheme.Text;
                    Lesson.Ведущий = idSpeaker;
                    Lesson.Дата = dpDate.SelectedDate;
                    Lesson.Стоимость = Int32.Parse(tbPrive.Text);
                    if (rbZoom.IsChecked == true) Lesson.Площадка = 2;
                    if (rbDiscord.IsChecked == true) Lesson.Площадка = 1;
                    Base.DB.Занятия.Add(Lesson);
                    Base.DB.SaveChanges();
                    MessageBox.Show("Занятие успешно создано!", "Создание занятия", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                catch
                {
                    MessageBox.Show("Ошибка! Проверьте ввод и повторите", "Создание занятия", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void lbCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbSpeaker.Items.Clear();
            index = cbCourse.SelectedIndex + 1;
            List<КурсыВедущих> CS = Base.DB.КурсыВедущих.Where(x => x.IDCourse == index).ToList();
            foreach(Ведущие Speaker in Base.DB.Ведущие)
            {
                if (CS.FirstOrDefault(x => x.IDSpeak == Speaker.IDSpeak) != null)
                {
                    cbSpeaker.Items.Add(Speaker.ФИОВедущего);
                }
            }    
        }
    }
}
