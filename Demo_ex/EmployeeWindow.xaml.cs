using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Demo_ex
{
    /// <summary>
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public EmployeeWindow()
        {
            InitializeComponent();
            HelloUser.Text = "Здравствуйте, " + Repository.employee.Имя.ToString();
            Tickets.ItemsSource = Demo_exEntities.GetContext().Заявка.ToList();
        }
        private void SearchBar_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBar.Text == "   Поиск заявки. . .")
            {
                SearchBar.Text = "";
            }
           
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Filter.SelectedIndex != 0)
            {
                Tickets.ItemsSource = Demo_exEntities.GetContext().Заявка.Where(x => x.id_статуса == Filter.SelectedIndex).ToList();
            }
            else
            {
                Tickets.ItemsSource = Demo_exEntities.GetContext().Заявка.ToList();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
            
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {

            if (SearchBar.Text != "   Поиск заявки. . .")
            {
                if (Filter.SelectedIndex != 0)
                {
                    Tickets.ItemsSource = Demo_exEntities.GetContext().Заявка.Where(x => DbFunctions.Like(x.Клиент.Фамилия, SearchBar.Text.ToString() + "%") && x.id_статуса == Filter.SelectedIndex).ToList();
                }
                else
                {
                    Tickets.ItemsSource = Demo_exEntities.GetContext().Заявка.Where(x => DbFunctions.Like(x.Клиент.Фамилия, SearchBar.Text.ToString() + "%")).ToList();
                }
            }
            else
            {
                MessageBox.Show("Начните вводить ключевое слово.");
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchBar.Text != "   Поиск заявки. . .")
            {
                if (Filter.SelectedIndex != 0)
                {
                    Tickets.ItemsSource = Demo_exEntities.GetContext().Заявка.Where(x => DbFunctions.Like(x.Клиент.Фамилия, SearchBar.Text.ToString() + "%") && x.id_статуса == Filter.SelectedIndex).ToList();
                }
                else
                {
                    Tickets.ItemsSource = Demo_exEntities.GetContext().Заявка.Where(x => DbFunctions.Like(x.Клиент.Фамилия, SearchBar.Text.ToString() + "%")).ToList();
                }
            }
        }
    }
}
