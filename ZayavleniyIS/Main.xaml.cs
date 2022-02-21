using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace ZayavleniyIS
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private sotrudniki sotrudniki;
        public Main(sotrudniki sotrudniki)
        {
            InitializeComponent();
            this.sotrudniki = sotrudniki;
            family_Label.Content = sotrudniki.Фамилия;
            name_label1.Content = sotrudniki.Имя;
            //if(!String.IsNullOrEmpty())
            update();
            if (!String.IsNullOrEmpty(sotrudniki.Номер_телефона))
            {
                try
                {
                    image_profiel.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath("image/" + sotrudniki.Номер_телефона)));
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void update()
        {
            Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            var join_massive = from svoistva_zayvleni in Entities.GetContext().svoistva_zayvleni
                               join rehennie_zayvleniy in Entities.GetContext().rehennie_zayvleniy on svoistva_zayvleni.id_свойств equals rehennie_zayvleniy.id_свойств
                               join zayvleniy in Entities.GetContext().Zayvleniy on svoistva_zayvleni.id_свойств equals zayvleniy.id_свойств
                               join Otzivi in Entities.GetContext().otzivi on rehennie_zayvleniy.id_отзыва equals Otzivi.id_отзыва
                               join Zayvitel in Entities.GetContext().zayvitel on Otzivi.id_заявителя equals Zayvitel.id_заявителя
                               select new
                               {
                                   zvlName = zayvleniy.Номер_заявления,
                                   Sroki = svoistva_zayvleni.срок,
                                   zkrt = rehennie_zayvleniy.Дата,
                                   Name = zayvleniy.Наименование,
                                   zayvitel123 = Zayvitel.Фамилия,
                                   zvl = zayvleniy.Номер_заявления

                               };
            dataGridZayvka.ItemsSource = join_massive.ToList();
        }

        internal void UpdateData()
        {
            throw new NotImplementedException();
        }

        private void Exit_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Show();
        }

        private void Label_MouseDoubleClock(object sender, MouseButtonEventArgs e)
        {
            Label label = sender as Label;
            Redcator redcator = new Redcator(label.Tag);
            redcator.Owner = this;
            redcator.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Redactirovanie rb = new Redactirovanie(Entities.GetContext().svoistva_zayvleni.Where(p => p.id_свойств == (int)button.Tag).First());
            rb.Owner = this;
            rb.Show();
        }

        private void Zayva_Click(object sender, RoutedEventArgs e)
        {
            zayava zayava = sender as zayava;
            zayava rb1 = new zayava();
            rb1.Owner = this;
            rb1.Show();
        }

        private void Button_svapfoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg*";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    File.Copy(openFileDialog.FileName, "image/" + System.IO.Path.GetFileName(openFileDialog.FileName), true);
                    sotrudniki.Номер_телефона = System.IO.Path.GetFileName(openFileDialog.FileName);
                    Entities.GetContext().SaveChanges();
                    Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    try
                    {
                        image_profiel.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath("image/" + sotrudniki.Номер_телефона)));

                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                catch (IOException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dobavlenie dobavlenie = sender as dobavlenie;
            dobavlenie rb2 = new dobavlenie();
            rb2.Owner = this;
            rb2.Show();
        }

        private void Diagramm_button1_Click(object sender, RoutedEventArgs e)
        {
            DiagrammWindow diagramm = new DiagrammWindow();
            diagramm.Show();


        }

        private void dataGridZayvka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
