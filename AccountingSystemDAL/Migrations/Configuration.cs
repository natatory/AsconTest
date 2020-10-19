namespace AccountingSystemDAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using Model;

    internal sealed class Configuration : DbMigrationsConfiguration<AccountingSystemDAL.EF.AccountingSystem>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AccountingSystemDAL.EF.AccountingSystem context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            
        }
    }
}
