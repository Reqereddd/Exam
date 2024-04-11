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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            HelloUser.Text = "Здравствуйте, " + Repository.user.Имя.ToString();
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
            if (SearchBar.Text != "   Поиск заявки. . .")
            {


                if (Filter.SelectedIndex != 0)
                {
                    Tickets.ItemsSource = Demo_exEntities.GetContext().Заявка.Where(x => x.id_статуса == Filter.SelectedIndex && DbFunctions.Like(x.Оборудование.Наименование_оборудования, SearchBar.Text.ToString() + "%") && x.id_клиента == Repository.user.id_клиента).ToList();
                }
                else
                {
                    Tickets.ItemsSource = Demo_exEntities.GetContext().Заявка.Where(x => x.id_клиента == Repository.user.id_клиента && DbFunctions.Like(x.Оборудование.Наименование_оборудования, SearchBar.Text.ToString() + "%")).ToList();
                }
            }
            else
            {
                if (Filter.SelectedIndex != 0)
                {
                    Tickets.ItemsSource = Demo_exEntities.GetContext().Заявка.Where(x => x.id_статуса == Filter.SelectedIndex && x.id_клиента == Repository.user.id_клиента).ToList();
                }
                else
                {
                    Tickets.ItemsSource = Demo_exEntities.GetContext().Заявка.Where(x => x.id_клиента == Repository.user.id_клиента).ToList();
                }
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
                    Tickets.ItemsSource = Demo_exEntities.GetContext().Заявка.Where(x => DbFunctions.Like(x.Оборудование.Наименование_оборудования, SearchBar.Text.ToString() + "%") && (x.id_статуса == Filter.SelectedIndex) && (x.id_клиента == Repository.user.id_клиента)).ToList();
                }
                else
                {
                    Tickets.ItemsSource = Demo_exEntities.GetContext().Заявка.Where(x => DbFunctions.Like(x.Оборудование.Наименование_оборудования, SearchBar.Text.ToString() + "%")&& (x.id_клиента == Repository.user.id_клиента)).ToList();
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
                    Tickets.ItemsSource = Demo_exEntities.GetContext().Заявка.Where(x => DbFunctions.Like(x.Оборудование.Наименование_оборудования, SearchBar.Text.ToString() + "%") && (x.id_статуса == Filter.SelectedIndex) && (x.id_клиента == Repository.user.id_клиента)).ToList();
                }
                else
                {
                    Tickets.ItemsSource = Demo_exEntities.GetContext().Заявка.Where(x => DbFunctions.Like(x.Оборудование.Наименование_оборудования, SearchBar.Text.ToString() + "%")&& (x.id_клиента == Repository.user.id_клиента)).ToList();
                }
            }
        }

        private void CreateTicket_Click(object sender, RoutedEventArgs e)
        {
            CreateTicket createTicket = new CreateTicket();
            createTicket.Show();
            this.Close();
            
        }
    }
}
