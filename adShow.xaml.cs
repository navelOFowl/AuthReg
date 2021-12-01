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
    /// Логика взаимодействия для adShow.xaml
    /// </summary>
    public partial class adShow : Page
    {
        List<Занятия> LessStart = Base.DB.Занятия.ToList();
        public adShow()
        {
            InitializeComponent();
            lvLess.ItemsSource = LessStart;
            tbCount.Text = "Найдено записей: " + LessStart.Count + "";
        }
        
        private void ButtDeleteClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender; 
            int lessInd = Convert.ToInt32(button.Uid); 
            Занятия lessDelete = Base.DB.Занятия.FirstOrDefault(x => x.IDLesson == lessInd); 
            Base.DB.Занятия.Remove(lessDelete); 
            Base.DB.SaveChanges();
            FrameCl.mainFrame.Navigate(new adShow()); 
            MessageBox.Show("Занятие удалено!", "Удаление", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        private void ButtEditClick(object sender, RoutedEventArgs e)
        {
            Button buttEdit = (Button)sender;  
            int lessId = Convert.ToInt32(buttEdit.Uid);  
            Занятия lessUpd = Base.DB.Занятия.FirstOrDefault(x => x.IDLesson == lessId); 
            FrameCl.AdminFrame.Navigate(new createEdit(lessUpd));
        }

        List<Занятия> LessFilter;
        private void Filter()
        {
            int index = cbFilter.SelectedIndex;
            if (index != 0)
            {
                LessFilter = LessStart.Where(x => x.IDLesson == index).ToList();
            }
            else
            {
                LessFilter = LessStart;
            }

            if (tbDateFilter != null)
            {
                LessFilter = LessFilter.Where(x => x.Дата == tbDateFilter.SelectedDate).ToList();
            }

            if (cbC.IsChecked == true)
            {
                LessFilter = LessFilter.Where(x => x.Курс == 2).ToList();
            }
            else
            {
                MessageBox.Show("ТЕСТ");
            }
            if (cbSharp.IsChecked == true)
            {
                LessFilter = LessFilter.Where(x => x.Курс == 1).ToList();
            }
            if (cbApp.IsChecked == true)
            {
                LessFilter = LessFilter.Where(x => x.Курс == 3).ToList();
            }
            if (cbGraph.IsChecked == true)
            {
                LessFilter = LessFilter.Where(x => x.Курс == 4).ToList();
            }
            if (cbTest.IsChecked == true)
            {
                LessFilter = LessFilter.Where(x => x.Курс == 5).ToList();
            }
            if (cbMath.IsChecked == true)
            {
                LessFilter = LessFilter.Where(x => x.Курс == 6).ToList();
            }
        }

        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void cbSharp_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void cbSharp_Unchecked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void cbC_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void cbC_Unchecked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void cbApp_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void cbApp_Unchecked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void cbGraph_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void cbGraph_Unchecked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void tbDateFilter_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void cbTest_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void cbTest_Unchecked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void cbMath_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void cbMath_Unchecked(object sender, RoutedEventArgs e)
        {
            Filter();
        }
    }
}
