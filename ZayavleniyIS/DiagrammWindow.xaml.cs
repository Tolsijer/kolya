using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Word = Microsoft.Office.Interop.Word;

namespace ZayavleniyIS
{
    /// <summary>
    /// Логика взаимодействия для DiagrammWindow.xaml
    /// </summary>
    public partial class DiagrammWindow : Window
    {
        public DiagrammWindow()
        {
            InitializeComponent();

            chart.Titles.Add("Данные по заявкам");
            chart.ChartAreas.Add(new ChartArea("Default"));
            chart.Series.Add(new Series("Количество записей")
            {
                ChartType = SeriesChartType.Column
            });
            List<int> info_zapis = new List<int>();
            List<String> count_extra = new List<String>();
            foreach (Zayvleniy buy in Entities.GetContext().Zayvleniy)
            {
                info_zapis.Add(buy.Номер_заявления);
                count_extra.Add(buy.Наименование);
            }


            chart.Series["Количество записей"].Points.DataBindXY(info_zapis, count_extra);



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word document(*.docx) |*.docx";
            // if (saveFileDialog.ShowDialog()==true)
            object oMissing = System.Reflection.Missing.Value;
            //Создание документа
            Word.Application word_app = new Word.Application();
            word_app.Visible = true;
            Word.Document doc = word_app.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            //Добовление заголовка
            Word.Paragraph par_zag = doc.Content.Paragraphs.Add(ref oMissing);
            par_zag.Range.Text = "Отчёт";
            par_zag.Range.Font.Color = Word.WdColor.wdColorBlack;
            par_zag.Range.Font.Bold = 1;
            par_zag.Range.Font.Size = 14f;
            par_zag.Range.Font.Name = "Times New Roman";
            par_zag.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            par_zag.Range.InsertParagraphAfter();
            //Добовление таблицы
            Word.Paragraph table_par = doc.Content.Paragraphs.Add(ref oMissing);
            Word.Table table = doc.Content.Tables.Add(table_par.Range, Entities.GetContext().svoistva_zayvleni.Count() + 1, 3, ref oMissing, ref oMissing);
            table.Range.Font.Size = 12f;
            table.Range.Font.Bold = 0;
            table.Rows[1].Range.Font.Bold = 1;
            table.Cell(1, 1).Range.Text = "Сотрудник";
            table.Cell(1, 2).Range.Text = "вид";
            table.Cell(1, 3).Range.Text = "статус";
            table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            for (int i = 0; i < Entities.GetContext().svoistva_zayvleni.Count(); i++)
            {
                for (int j = 1; j <= table.Columns.Count; j++)
                {
                    switch (j)
                    {
                        case 1:
                            table.Cell(i + 2, j).Range.Text = Entities.GetContext().svoistva_zayvleni.ToList()[i].sotrudniki.Фамилия.ToString();
                            break;
                        case 2:
                            table.Cell(i + 2, j).Range.Text = Entities.GetContext().svoistva_zayvleni.ToList()[i].вид.ToString();
                            break;
                        case 3:
                            table.Cell(i + 2, j).Range.Text = Entities.GetContext().svoistva_zayvleni.ToList()[i].статус.ToString();
                            break;

                    }
                }
            }
            doc.SaveAs2(saveFileDialog.FileName = "Product Report", ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
        }
    }
}
