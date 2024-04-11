using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ex
{

    internal class Repository
    {
        public static Сотрудник employee;
        public static Клиент user;
        public static void UserAutorization(string Login, string Pass)
        {
            user = Demo_exEntities.GetContext().Клиент.Where(b => b.Логин == Login && b.Пароль == Pass).FirstOrDefault();
        }

        public static void EmployeeAuthorization(string Login, string Pass)
        {
            employee = Demo_exEntities.GetContext().Сотрудник.Where(b => b.Логин == Login && b.Пароль == Pass).FirstOrDefault();
        }
    }
}
