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
    /// Логика взаимодействия для dobavlenie.xaml
    /// </summary>
    public partial class dobavlenie : Window
    {
        public dobavlenie()
        {
            InitializeComponent();  
        }

        //private void dobname_Click(object sender, RoutedEventArgs e)
        //{
        //    dobavlenieName dobavlenieName = sender as dobavlenieName;
        //    dobavlenieName dn = new dobavlenieName();
        //    dn.Owner = this;
        //    dn.Show();
        //}

        private void Dobname_Click(object sender, RoutedEventArgs e)
        {
            dobavlenieName dobavlenieName = sender as dobavlenieName;
            dobavlenieName dn = new dobavlenieName();
            dn.Owner = this;
            dn.Show();
        }
    //    StringBuilder errors = new StringBuilder();

    //        if (textBox.Text == null)
    //            errors.AppendLine("Укажите Наименование");
    //        if (textBox1.Text == null)
    //            errors.AppendLine("Срок");
    //        if (textBox1_Copy.Text == null)
    //            errors.AppendLine("Дата заакрытия");
    //        if (textBox1_Copy1 == null)
    //            errors.AppendLine("Заявитель");
    //        ///if
    //        if (errors.Length > 0)

    //        {
    //            MessageBox.Show(errors.ToString());
    //            return;
    //        }
    //Entities.GetContext().Zayvleniy.Add(new Zayvleniy()
    //{
    //    Наименование = textBox.Text,
    //            //id_свойств = id_combobox.SelectedItem as svoistva_zayvleni
    //        });
    //        Entities.GetContext().svoistva_zayvleni.Add(new svoistva_zayvleni()
    //{
    //    срок = textBox1.Text,
    //        });
    //        Entities.GetContext().rehennie_zayvleniy.Add(new rehennie_zayvleniy()
    //{
    //    Дата = textBox1_Copy.Text,
    //        });
    //        Entities.GetContext().zayvitel.Add(new zayvitel()
    //{
    //    Фамилия = textBox1_Copy1.Text,
    //        });
    //        Entities.GetContext().SaveChanges();
    //((Main)this.Owner).UpdateData();
    //MessageBox.Show("Данные успешно добавлены!");
    //        this.Close();
    //}

}
}
