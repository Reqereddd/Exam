using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для ChangeTicket.xaml
    /// </summary>
    public partial class ChangeTicket : Window
    {
        Заявка ticket = new Заявка();
        public ChangeTicket(Заявка заявка)
        {
            if (заявка != null) ticket = заявка;
            DataContext = ticket;
            InitializeComponent();
            id_ticket.Text = ticket.id_заявки.ToString();
            id_client.Text = ticket.id_клиента.ToString();
            description.Text = ticket.Описание_заявки.ToString();
            opendate.Text = ticket.Дата_открытия.ToString();
            if(ticket.Итоговая_стоимость != null)
                cost.Text = ticket.Итоговая_стоимость.ToString();
            if (ticket.Дата_закрытия == null)
            {
                closedate.Text = DateTime.Now.ToShortDateString();
            }
            else
            {
                closedate.Text = ticket.Дата_закрытия.ToString();
            }
            id_equipment.Text = ticket.id_оборудования.ToString();
            id_defect.Text = ticket.id_неисправности.ToString();
            id_priority.ItemsSource = Demo_exEntities.GetContext().Приоритет.OrderBy(x=>x.Приоритет1).Select(x=>x.Приоритет1).ToList();
            id_employee.ItemsSource = Demo_exEntities.GetContext().Сотрудник.OrderBy(x => x.Фамилия).Select(x => x.Фамилия).ToList();
            id_status.ItemsSource = Demo_exEntities.GetContext().Статус.OrderBy(x => x.Наименование_статуса).Select(x => x.Наименование_статуса).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DeteiledTicket deteiledTicket = new DeteiledTicket(ticket);
            deteiledTicket.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (cost.Text != "")
            {
                ticket.Итоговая_стоимость = decimal.Parse(cost.Text.Trim());
            }
            if(id_priority.Text != "")
            {
                ticket.Приоритет = id_priority.SelectedIndex + 1;
            }
            if (id_employee.Text != "")
            {
                ticket.id_исполнителя = id_employee.SelectedIndex + 1;
            }
            ticket.Дата_закрытия = DateTime.ParseExact(DateTime.Parse(closedate.Text).ToShortDateString(), "dd'.'MM'.'yyyy", CultureInfo.InvariantCulture);
            if(id_status.Text != "")
            {
                ticket.id_статуса = id_status.SelectedIndex + 1;
            }
            try
            {
                Demo_exEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно обновлены!");
                ManagerWindow managerWindow = new ManagerWindow();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка, проверьте введенные данные!");
            }
            
        }
    }
}
