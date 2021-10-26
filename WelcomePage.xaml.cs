using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        List<Lessons> Search;
        List<Lessons> Less = new List<Lessons>();
        public WelcomePage()
        {
            InitializeComponent();
            using (StreamReader sr = new StreamReader("Data.csv"))
            {
                while (sr.EndOfStream != true)
                {
                    string[] Arr = sr.ReadLine().Split(';');
                    Less.Add(new Lessons() { cour = Arr[0], them = Arr[1], speak = Arr[2], data = Arr[3], price = Arr[4], site = Arr[5] });
                }
            }
            dgLess.ItemsSource = Less;
            cbCourse.IsChecked = true;
            cbTheme.IsChecked = true;
            cbSpeak.IsChecked = true;
            cbData.IsChecked = true;
            cbPrice.IsChecked = true;
            cbSite.IsChecked = true;
        }

        private void cbCourse_Checked(object sender, RoutedEventArgs e)
        {
            Cours.Visibility = Visibility.Visible;
        }

        private void cbTheme_Checked(object sender, RoutedEventArgs e)
        {
            Theme.Visibility = Visibility.Visible;
        }

        private void cbSpeak_Checked(object sender, RoutedEventArgs e)
        {
            Speak.Visibility = Visibility.Visible;
        }

        private void cbData_Checked(object sender, RoutedEventArgs e)
        {
            Data.Visibility = Visibility.Visible;
        }

        private void cbPrice_Checked(object sender, RoutedEventArgs e)
        {
            Price.Visibility = Visibility.Visible;
        }

        private void cbSite_Checked(object sender, RoutedEventArgs e)
        {
            Site.Visibility = Visibility.Visible;
        }

        private void cbCourse_Unchecked(object sender, RoutedEventArgs e)
        {
            Cours.Visibility = Visibility.Hidden;
        }

        private void cbTheme_Unchecked(object sender, RoutedEventArgs e)
        {
            Theme.Visibility = Visibility.Hidden;
        }

        private void cbSpeak_Unchecked(object sender, RoutedEventArgs e)
        {
            Speak.Visibility = Visibility.Hidden;
        }

        private void cbData_Unchecked(object sender, RoutedEventArgs e)
        {
            Data.Visibility = Visibility.Hidden;
        }

        private void cbPrice_Unchecked(object sender, RoutedEventArgs e)
        {
            Price.Visibility = Visibility.Hidden;
        }

        private void cbSite_Unchecked(object sender, RoutedEventArgs e)
        {
            Site.Visibility = Visibility.Hidden;
        }

        private void buttSearch_Click(object sender, RoutedEventArgs e)
        {
            Search = new List<Lessons>();
            if (rbCourse.IsChecked == true)
            {
                for (int i = 0; i < Less.Count; i++)
                {
                    if (tbSearch.Text == Less[i].cour)
                    {
                        Lessons search = new Lessons
                        {
                            cour = Less[i].cour,
                            them = Less[i].them,
                            speak = Less[i].speak,
                            data = Less[i].data,
                            price = Less[i].price,
                            site = Less[i].site,
                        };
                        Search.Add(search);
                    }
                }
            }
            if (rbSite.IsChecked == true)
            {
                for (int i = 0; i < Less.Count; i++)
                {
                    if (tbSearch.Text == Less[i].site)
                    {
                        Lessons search = new Lessons
                        {
                            cour = Less[i].cour,
                            them = Less[i].them,
                            speak = Less[i].speak,
                            data = Less[i].data,
                            price = Less[i].price,
                            site = Less[i].site,
                        };
                        Search.Add(search);
                    }
                }
            }
            try
            {
                dgLess.ItemsSource = Search;
            }
            catch
            {
                MessageBox.Show("Проверьте ввод", "Не найдено!");
            }
        }

        private void buttClear_Click(object sender, RoutedEventArgs e)
        {
            FrameCl.mainFrame.Navigate(new WelcomePage());
        }

        private void buttExit_Click(object sender, RoutedEventArgs e)
        {
            FrameCl.mainFrame.Navigate(new Default());
        }
    }
}

