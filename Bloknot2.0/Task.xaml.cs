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

namespace Bloknot2._0
{
    /// <summary>
    /// Логика взаимодействия для Task.xaml
    /// </summary>
    public static class ext
    {
        public static void SetText(this RichTextBox richTextBox, string text)
        {
            richTextBox.Document.Blocks.Clear();
            richTextBox.Document.Blocks.Add(new Paragraph(new Run(text)));
        }
        public static string GetText(this RichTextBox richTextBox)
        {
            return new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
        }
    }
    public partial class Task : Window
    {
        public RichTextBox taskText = null;
        public Task(RichTextBox richTextBox)
        {
            taskText = richTextBox;
            InitializeComponent();
        }

        private void Rearrange_Click(object sender, RoutedEventArgs e)
        {
            string[] lines = taskText.GetText().Split("\n".ToCharArray());
            string richText = "";
            int num1;
            int num2;

            try
            {
                num1 = Convert.ToInt32(Strok1.Text) - 1;
                num2 = Convert.ToInt32(Strok2.Text) - 1;
            }
            catch
            {
                MessageBox.Show("Введите номера строк");
                return;
            }
            try
            {
                string s = lines[num1];
                lines[num1] = lines[num2];
                lines[num2] = s;
            }
            catch
            {
                MessageBox.Show("У вас нет таких строк");
                return;
            }
            foreach (string item in lines)
            {
                richText += item + "\n";
            }
            taskText.SetText(richText);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
