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

namespace Demo_ex
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Клиент user;
        public static Сотрудник employee;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            string Login = AuthLogin.Text.ToLower().Trim();
            string Pass = AuthPass.Password.ToLower().Trim();

            Repository.UserAutorization(Login, Pass);
            Repository.EmployeeAuthorization(Login, Pass);
            if (Login.Length < 3 || Pass.Length < 3)//проверка данных на минимальную  длинну
            {
                MessageBox.Show("Заполните все поля!");//всплывающее сообщение,если данные введены некорректно
                AuthLogin.ToolTip = "Поле введено не корректно";
                AuthPass.ToolTip = "Поле введено не корректно";
            }
            else
            {
                if (Repository.user != null)
                {
                    UserWindow userWindow = new UserWindow();//окрытие окна клиента
                    userWindow.Show();
                    this.Close();
                }
                else
                {
                    if (Repository.employee != null)
                    {
                        if (Repository.employee.id_роли == 1)
                        {
                            ManagerWindow managerWindow = new ManagerWindow();
                            managerWindow.Show();
                            this.Close();
                        }
                        else
                        {
                            if (Repository.employee.id_роли == 2)
                            {
                                EmployeeWindow employeeWindow = new EmployeeWindow();//открытие окна работника-специалиста
                                employeeWindow.Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка авторизации");
                            }

                        }

                    }
                    else
                    {
                        MessageBox.Show("Ошибка авторизации");
                    }

                }

            }
        }

        private void ToRegistration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();//открытие окна работника-специалиста
            registrationWindow.Show();
            this.Close();
        }
        }
}
