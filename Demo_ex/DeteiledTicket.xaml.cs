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
    /// </summary>
    public partial class DeteiledTicket : Window
    {
        Заявка ticket = new Заявка();
        public DeteiledTicket(Заявка заявка)
        {
            if (заявка != null) ticket = заявка;
            DataContext = ticket;
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow managerWindow = new ManagerWindow();
            managerWindow.Show();
            this.Close();

        }

        private void DeleteTicket_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Demo_exEntities.GetContext().Заявка.Remove(ticket);
                Demo_exEntities.GetContext().SaveChanges();
                MessageBox.Show("Заявка успешно удалена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateReport_Click(object sender, RoutedEventArgs e)
        {
            CreateReport createReport = new CreateReport((sender as Button).DataContext as Заявка);
            createReport.Show();
            this.Close();
        }

        private void ChangeTicket_Click(object sender, RoutedEventArgs e)
        {
            ChangeTicket changeTicket = new ChangeTicket(ticket);
            changeTicket.Show();
            this.Close();
        }
    }
}
