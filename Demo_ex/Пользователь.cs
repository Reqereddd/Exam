//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo_ex
{
    using System;
    using System.Collections.Generic;
    
    public partial class Пользователь
    {
        private string surname;
        private string name;
        private string patronymic;
        private DateTime date;
        private string login;
        private string firstPass;
        private string email;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Пользователь()
        {
            this.Заявка = new HashSet<Заявка>();
        }

        public Пользователь(string surname, string name, string patronymic, DateTime date, string login, string firstPass, string email)
        {
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.date = date;
            this.login = login;
            this.firstPass = firstPass;
            this.email = email;
        }

        public int id_пользователя { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public System.DateTime Дата_рождения { get; set; }
        public string Логин { get; set; }
        public string Пароль { get; set; }
        public string Почта { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Заявка> Заявка { get; set; }
    }
}
