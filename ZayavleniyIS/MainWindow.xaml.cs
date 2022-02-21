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

namespace ZayavleniyIS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_auth_click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(logintextBox.Text))
            {
                if (!String.IsNullOrEmpty(passwordBox.Password))
                {
                    IQueryable<sotrudniki> sotrudniki_list = Entities.GetContext().sotrudniki.Where(p => p.Логин == logintextBox.Text && p.Пароль == passwordBox.Password);
                    if (sotrudniki_list.Count() == 1)
                    {
                        MessageBox.Show("Добро пожаловать," + sotrudniki_list.First().Имя);
                        Main window = new Main(sotrudniki_list.First());
                        window.Owner = this;
                        window.Show();
                        this.Hide();
                    }
                    else MessageBox.Show("Неверный логин или пароль!");
                }
            }
        }
    }
}
