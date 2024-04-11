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
    /// Логика взаимодействия для CreateTicket.xaml
    /// </summary>
    public partial class CreateTicket : Window
    {
        public CreateTicket()
        {
            InitializeComponent();
            Оборудование.ItemsSource = Demo_exEntities.GetContext().Оборудование.OrderBy(x=> x.Наименование_оборудования).Select(x=>x.Наименование_оборудования).ToList();
            Неисправность.ItemsSource = Demo_exEntities.GetContext().Неисправность.OrderBy(x=> x.Неисправность1).Select(x=>x.Неисправность1).ToList();
        }

        private void CreateTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            int eqtype = Оборудование.SelectedIndex + 1;
            int deftype = Неисправность.SelectedIndex + 1;
            string desc = Description.Text;
            DateTime dateTime = DateTime.ParseExact(DateTime.Today.ToShortDateString(), "dd'.'MM'.'yyyy", CultureInfo.InvariantCulture);
            int clientid = Repository.user.id_клиента;
            Заявка заявка = new Заявка(desc, dateTime, eqtype, deftype, clientid, null, null, null, null, null);
            try
            {
                Demo_exEntities.GetContext().Заявка.Add(заявка);
                Demo_exEntities.GetContext().SaveChanges();
                MessageBox.Show("Заявка успешно отправлена!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.Show();
            this.Close();

        }
    }
}
