namespace PollPlus.Migration.Migrations
{
    using PollPlus.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PollPlus.Migration.Context.PollPlusMigrationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PollPlus.Migration.Context.PollPlusMigrationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Set<Categoria>().Add(new Categoria { Nome = "Esportes" });
            context.Set<Categoria>().Add(new Categoria { Nome = "Política" });
            context.Set<Categoria>().Add(new Categoria { Nome = "Ciência" });
        }
    }
}
