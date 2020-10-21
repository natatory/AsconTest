namespace AccountingSystemDAL.EF
{
    using System.Data.Entity;
    using AccountingSystemDAL.Model;

    public class AccountingSystem : DbContext
    {
        // Контекст настроен для использования строки подключения "AccountingSystem" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "AccountingSystemDAL.EF.AccountingSystem" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "AccountingSystem" 
        // в файле конфигурации приложения.
        public AccountingSystem()
            : base("name=AccountingSystem")
        {
            Database.SetInitializer(new DataInitializer());
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Data> Transactions { get; set; }
        public virtual DbSet<Recipient> Recipients { get; set; }
        //public virtual DbSet<Group> Groups { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}