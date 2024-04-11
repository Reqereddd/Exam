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

namespace Demo_ex
{
    /// <summary>
    /// Логика взаимодействия для CreateReport.xaml
    /// </summary>
    public partial class CreateReport : Window
    {
        Заявка ticket = new Заявка();

        public CreateReport(Заявка заявка)
        {
            InitializeComponent();
            if (заявка != null) ticket = заявка;
            DataContext = ticket;
            id_client.Text += ticket.id_клиента;
            id_defect.Text += ticket.id_неисправности;
            id_employee.Text += ticket.id_исполнителя;
            id_equipment.Text += ticket.id_оборудования;
            id_status.Text += ticket.id_статуса;
            id_ticket.Text += ticket.id_заявки;
            ticket_description.Text += ticket.Описание_заявки;
            status.Text += ticket.Статус.Наименование_статуса;
            priority.Text += ticket.Приоритет1.Приоритет1;
            client.Text += ticket.Клиент.Имя + " " + ticket.Клиент.Фамилия + " " + ticket.Клиент.Отчество;
            employee.Text += ticket.Сотрудник.Имя + " " + ticket.Сотрудник.Фамилия + " " + ticket.Сотрудник.Отчество;
            opendate.Text += ticket.Дата_открытия;
            if (ticket.Дата_закрытия != null)
            {
                closedate.Text += ticket.Дата_открытия;
            }
            else {
                closedate.Text += "--.--.----";
            }
            defect.Text += ticket.Неисправность.Неисправность1;
            equipment.Text += ticket.Оборудование.Наименование_оборудования + " " + ticket.Оборудование.Серийный_номер + " " + ticket.Оборудование.Запчасть;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DeteiledTicket deteiledTicket = new DeteiledTicket(ticket);
            deteiledTicket.Show();
            this.Close();
        }
    }
}
