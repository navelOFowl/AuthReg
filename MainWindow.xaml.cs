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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameCl.mainFrame = mainFrame;
            FrameCl.mainFrame.Navigate(new Default());
            Base.DB = new DataBase();
        }

        private void buttAuth_Click(object sender, RoutedEventArgs e)
        {
            FrameCl.mainFrame.Navigate(new AuthPage());
        }

        private void buttReg_Click(object sender, RoutedEventArgs e)
        {
            FrameCl.mainFrame.Navigate(new RegPage());
        }
    }
}
