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
using System.Windows.Shapes;

namespace ZayavleniyIS
{
    /// <summary>
    /// Логика взаимодействия для zayava.xaml
    /// </summary>
    public partial class zayava : Window
    {
        public zayava()
        {
            InitializeComponent();
            dataGrid.ItemsSource = Entities.GetContext().View_1.ToList();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Deletezayavenie_Click(object sender, RoutedEventArgs e)
        {
            if(dataGrid.SelectedItem != null)
            {
                int id = ((View_1)dataGrid.SelectedItem).Номер_заявления;
                Zayvleniy zayvleniy = Entities.GetContext().Zayvleniy.Where(p => p.Номер_заявления == id).FirstOrDefault();
                Entities.GetContext().Zayvleniy.Remove(zayvleniy);
                Entities.GetContext().SaveChanges();
                Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dataGrid.ItemsSource = Entities.GetContext().View_1.ToList();
            }
        }
    }
}
