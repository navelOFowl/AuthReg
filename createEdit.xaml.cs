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
        int index = 0;
        public createEdit()
        {
            InitializeComponent();
            cbCourse.ItemsSource = Base.DB.Курсы.ToList();
            cbCourse.SelectedValuePath = "IDCourse";
            cbCourse.DisplayMemberPath = "НазваниеКурса";
        }
        private void buttCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch
            {

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
