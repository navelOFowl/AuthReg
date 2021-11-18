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
        public adShow()
        {
            InitializeComponent();
            lvLess.ItemsSource = Base.DB.Занятия.ToList();
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
    }
}
