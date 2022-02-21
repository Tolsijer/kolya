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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Redcator : Window
    {
        private int redactor;
        public Redcator(object rd)
        {
            InitializeComponent();
            redactor = (int)rd;
            var result = Entities.GetContext().Zayvleniy.Where(p => p.Номер_заявления == redactor);
            textBlock.Text += result.First().Наименование;
            textBlock1.Text += result.First().Номер_заявления;
        }

    }
}
