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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo_ex
{

    public partial class RegistrationWindow : Window
    {
        private DateTime Date;

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void ToSignIn_Click(object sender, RoutedEventArgs e)
        {
            string Name = RegName.Text.Trim();
            string Surname = RegSurname.Text.Trim();
            string Patronymic = RegPatronymic.Text.Trim();
            if (RegBornDate.Text != "")
            {
                 Date = DateTime.ParseExact(RegBornDate.Text, "dd'.'MM'.'yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                MessageBox.Show("Введите дату рождения");
            }
            string Email = RegEmail.Text.Trim().ToLower();
            string Login = RegLogin.Text.Trim();
            string FirstPass = RegPass.Password.Trim();
            string SecondPass = RegRepeatPass.Password.Trim();
            string RegType = this.RegType.Text.ToString();
            if ((Name.Length < 1) || (Surname.Length < 1) || (Patronymic.Length < 1) || Email.Length < 1 || (Login.Length < 1) || (FirstPass.Length < 1) || (SecondPass.Length < 1))
            {
                MessageBox.Show("Заполните все поля!");
            }

            else if (!Email.Contains("@") || !Email.Contains("."))
            {
                MessageBox.Show("Email введен некорректно!");
            }


            else if (FirstPass != SecondPass)
            {
                MessageBox.Show("Введенные пароли должны быть одинаковыми!");

            }
            else
            {
                if (RegType == "Клиент" && Date != null)
                {
                    try
                    {
                        Клиент user = new Клиент(Surname, Name, Patronymic, Date, Login, FirstPass, Email);
                        Demo_exEntities.GetContext().Клиент.Add(user);
                        Demo_exEntities.GetContext().SaveChanges();
                        MessageBox.Show("Клиент успешно зарегестрирован");
                        this.Close();
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else if (RegType == "Работник" && Date != null)
                {
                    try
                    {
                        Сотрудник user = new Сотрудник(Surname, Name, Patronymic, Date, Login, FirstPass, Email, 1);
                        Demo_exEntities.GetContext().Сотрудник.Add(user);
                        Demo_exEntities.GetContext().SaveChanges();
                        MessageBox.Show("Работник успешно зарегестрирован");
                        this.Close();
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else if (RegType == "Менеджер" && Date != null)
                {
                    try
                    {
                        Сотрудник user = new Сотрудник(Surname, Name, Patronymic, Date, Login, FirstPass, Email, 2);
                        Demo_exEntities.GetContext().Сотрудник.Add(user);
                        Demo_exEntities.GetContext().SaveChanges();
                        MessageBox.Show("Менеджер успешно зарегестрирован");
                        this.Close();
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }

                }
                else
                {
                    MessageBox.Show("Введите дату рождения");
                }
            }
        }

        private void ToRegistration_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
