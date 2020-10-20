using AccountingSystemDAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace AccountingSystemDAL.EF
{
    class DataInitializer : CreateDatabaseIfNotExists<AccountingSystem>
    {

        protected override void Seed(AccountingSystem context)
        {

            var categories = new List<Category>
            {
                new Category{ CategoryId = Guid.NewGuid(), Name = "Развлечения"},
                new Category{ CategoryId = Guid.NewGuid(), Name = "Коммунальные платежи"},
                new Category{ CategoryId = Guid.NewGuid(), Name = "Автомобиль"},
                new Category{ CategoryId = Guid.NewGuid(), Name = "Продукты"},
                new Category{ CategoryId = Guid.NewGuid(), Name = "Непредвиденные расходы"},
            };
            categories.ForEach(x => context.Categories.Add(x));

            var recipients = new List<Recipient>
            {
                new Recipient{ RecipientId = Guid.NewGuid(), Name = "Булочная №3" },
                new Recipient{ RecipientId = Guid.NewGuid(), Name = "Перекресток" },
                new Recipient{ RecipientId = Guid.NewGuid(), Name = "Автосервис №1" },
                new Recipient{ RecipientId = Guid.NewGuid(), Name = "Кинотеатр Мираж-Синема" },
            };
            recipients.ForEach(x => context.Recipients.Add(x));

            //var users = new List<User>
            //{
            //    new User{ UserId = Guid.NewGuid(), WinUserName = "max", FirstName = "Петр", LastName="Иванов", IsAdmin = true, Balance = 100},
            //    new User{ UserId = Guid.NewGuid(), WinUserName = "fox", FirstName = "Евгения", LastName="Морская",IsAdmin=false, Balance = 50},
            //    new User{ UserId = Guid.NewGuid(), WinUserName = "stas",  FirstName = "Стас", LastName="Вареников", IsAdmin=false, Balance = 90},
            //    new User{ UserId = Guid.NewGuid(), WinUserName = "ygin", FirstName = "Честер", LastName="Юджин",IsAdmin=false, Balance = 120},
            //};
            //users.ForEach(x => context.Users.Add(x));

            //var transactions = new List<Data>();
            //{
            //    transactions.Add(new Data
            //    {
            //        DataId = Guid.NewGuid(),
            //        UserId = users[0].UserId,
            //        CategoryId = categories[0].CategoryId,
            //        Date = DateTime.Now,
            //        Description = "потрачено((",
            //        OpType = Data.OperationType.Расходы,
            //        RecipientId = recipients[2].RecipientId,
            //        TransactionAmount = 5,
            //        BalanceAfterTransact = users[0].Balance - 5
            //    });
            //    users[0].Balance -= 5;
            //    transactions.Add(new Data
            //    {
            //        DataId = Guid.NewGuid(),
            //        UserId = users[0].UserId,
            //        CategoryId = categories[1].CategoryId,
            //        Date = DateTime.Now,
            //        Description = "опять потрачено((",
            //        OpType = Data.OperationType.Расходы,
            //        RecipientId = recipients[0].RecipientId,
            //        TransactionAmount = 10,
            //        BalanceAfterTransact = users[0].Balance - 10
            //    });
            //    users[0].Balance -= 10;
            //    transactions.Add(new Data
            //    {
            //        DataId = Guid.NewGuid(),
            //        UserId = users[0].UserId,
            //        CategoryId = categories[2].CategoryId,
            //        Date = DateTime.Now,
            //        Description = "снова потрачено((",
            //        OpType = Data.OperationType.Расходы,
            //        RecipientId = recipients[1].RecipientId,
            //        TransactionAmount = 20,
            //        BalanceAfterTransact = users[0].Balance - 20
            //    });
            //    users[0].Balance -= 20;

            //};
            //transactions.ForEach(x => context.Transactions.Add(x));

            context.SaveChanges();
        }
    }
}
