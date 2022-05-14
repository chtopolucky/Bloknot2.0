using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Bloknot2._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        Bloknot bloknot;

        public MainWindow()
        {
            InitializeComponent();
            bloknot = new Bloknot(richTextBox);
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (bloknot.CheckingIsModified() == false) return;
            bloknot.CreateNewFile();
            this.Title = bloknot.NameFile;
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bloknot.Modified = true;
        }

        private void newWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            if (bloknot.CheckingIsModified() == false) return;
            if (bloknot.Open() == false) return;
            this.Title = bloknot.NameFile;
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            bloknot.ASaveBloknot();
            this.Title = bloknot.NameFile;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (bloknot.CheckingIsModified() == false) return;
            this.Close();
        }

        private void StatusBar_Click(object sender, RoutedEventArgs e)
        {
            if (statusBar.Visibility == Visibility.Visible)
            {
                statusBar.Visibility = Visibility.Collapsed;
                richTextBox.Margin = new Thickness(0, 0, 0, 0);
            }
            else
            {
                statusBar.Visibility = Visibility.Visible;
                richTextBox.Margin = new Thickness(0, 0, 0, 22);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (bloknot.NameFile == "")
            {
                bloknot.ASaveBloknot();
                this.Title = bloknot.NameFile;
            }
            else
            {
                bloknot.Save();
            }
            this.Title = bloknot.NameFile;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Undo();
        }

        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Cut();
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Copy();
        }

        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Paste();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Selection.Text = "";
        }
        private void SelectAll_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.SelectAll();
        }
        private void ChangeLines_Click(object sender, RoutedEventArgs e)
        {
            Task task = new Task(richTextBox);
            task.Show();
        }
        DispatcherTimer timer;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.IsEnabled = true;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            time.Text = d.ToString("HH:mm:ss");
            data.Text = d.ToString("dd:MM:yyyy");
        }
    }
}
