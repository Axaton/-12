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
using System.Windows.Threading;

namespace Практическая__12
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

        private void SectionCalculation_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(valueAx1.Text) || string.IsNullOrEmpty(valueAy1.Text) || string.IsNullOrEmpty(valueBx1.Text) ||
                string.IsNullOrEmpty(valueBy1.Text) || string.IsNullOrEmpty(valueCx1.Text) || string.IsNullOrEmpty(valueCy1.Text))
            {
                MessageBox.Show("Введите данные!");
            }
            else
            {
                double resultSectionAC, resultSectionBC;

                resultSectionAC = Math.Sqrt(Math.Pow(int.Parse(valueCx1.Text) - int.Parse(valueAx1.Text), 2) +
                    Math.Pow(int.Parse(valueCy1.Text) - int.Parse(valueAy1.Text), 2));
                sectionAC.Text = resultSectionAC.ToString();

                resultSectionBC = Math.Sqrt(Math.Pow(int.Parse(valueCx1.Text) - int.Parse(valueBx1.Text), 2) +
                    Math.Pow(int.Parse(valueCy1.Text) - int.Parse(valueBy1.Text), 2));
                sectionBC.Text = resultSectionBC.ToString();

                sum.Text = (resultSectionAC + resultSectionBC).ToString();

                valueAx1.Focus();
            }
        }

        private void CalculateMinutes_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(seconds.Text))
            {
                MessageBox.Show("Введите данные!");
            }
            else
            minutes.Text = (int.Parse(seconds.Text) % 3600 / 60).ToString();
            seconds.Focus();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime now = DateTime.Now;
            Data.Text = now.ToString("D");

            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void TaskInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Даны три точки A, B, C на числовой оси. Найти длины отрезков AC и BC и их сумму.\n" +
               "С начала суток прошло N секунд(N — целое).Найти количество полных минут, прошедших сначала последнего часа.", "Задание");
        }

        private void DeveloperInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Харенко Кирилл  ИСП-34", "Разработчик", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void valueTextChange_TextChanged(object sender, TextChangedEventArgs e)
        {
            minutes.Clear();
            sectionAC.Clear();
            sectionBC.Clear();
            sum.Clear();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            valueAx1.Clear();
            valueAy1.Clear();
            valueCx1.Clear();
            valueCy1.Clear();
            valueBx1.Clear();
            valueBy1.Clear();
            sectionAC.Clear();
            sectionBC.Clear();
            sum.Clear();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
