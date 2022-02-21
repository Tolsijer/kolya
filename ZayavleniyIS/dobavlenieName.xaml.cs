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
    /// Логика взаимодействия для dobavlenieName.xaml
    /// </summary>
    public partial class dobavlenieName : Window
    {
        public dobavlenieName()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (textBox.Text == null)
                errors.AppendLine("Укажите Наименование");
            if (comboBox.SelectedItem == null)
                errors.AppendLine("Укажите id");
            if (errors.Length >0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            Entities.GetContext().Zayvleniy.Add(new Zayvleniy()
            {
                //Наименование = textBox.Text,
                //id_свойств = (int)comboBox.SelectedItem
                //id_свойств = id_combobox.SelectedItem as svoistva_zayvleni
            });
            Entities.GetContext().SaveChanges();
            ((Main)this.Owner).UpdateData();
            MessageBox.Show("Данные успешно добавлены!");
            this.Close();
        }
    }
}
