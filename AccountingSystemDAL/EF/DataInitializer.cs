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

            context.SaveChanges();
        }
    }
}
