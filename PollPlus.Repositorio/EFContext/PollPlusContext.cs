using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Repositorio.EFContext
{
    public class PollPlusContext<T> : DbContext where T : class
    {
        public DbSet<T> DBEntity { get; set; }

        public PollPlusContext() : base("name=MaisConnectionString") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
