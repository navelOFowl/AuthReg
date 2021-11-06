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
    /// Логика взаимодействия для adSpCs.xaml
    /// </summary>
    public partial class adSpCs : Page
    {
        public adSpCs()
        {
            InitializeComponent();
            lvSpCs.ItemsSource = Base.DB.Ведущие.ToList();
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<КурсыВедущих> TC = Base.DB.КурсыВедущих.Where(x => x.IDSpeak == index).ToList();
            string str = "";
            foreach (КурсыВедущих item in TC)
            {
                str += item.Курсы.НазваниеКурса.ToString() + "\n";
            }
            tb.Text = str;
        }
    }
}
