﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Demo_exEntities : DbContext
    {
        private static Demo_exEntities context;
        public Demo_exEntities()
            : base("name=Demo_exEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        public static Demo_exEntities GetContext()
        {
            if (context == null)
                context = new Demo_exEntities();
            return context;


        }

        public virtual DbSet<Запчасть> Запчасть { get; set; }
        public virtual DbSet<Заявка> Заявка { get; set; }
        public virtual DbSet<Клиент> Клиент { get; set; }
        public virtual DbSet<Неисправность> Неисправность { get; set; }
        public virtual DbSet<Оборудование> Оборудование { get; set; }
        public virtual DbSet<Приоритет> Приоритет { get; set; }
        public virtual DbSet<Роль> Роль { get; set; }
        public virtual DbSet<Сотрудник> Сотрудник { get; set; }
        public virtual DbSet<Статус> Статус { get; set; }
    }
}