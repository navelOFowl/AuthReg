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
    }
}
