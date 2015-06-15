using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Migration.Context
{
    public class PollPlusMigrationContext : DbContext
    {
        DbSet<Categoria> Categoria { get; set; }
        DbSet<Documento> Documento { get; set; }
        DbSet<Empresa> Empresa { get; set; }
        DbSet<Enquete> Enquete { get; set; }
        DbSet<Geolocalizacao> Geolocalizacao { get; set; }
        DbSet<Mensagem> Mensagem { get; set; }
        DbSet<Plataforma> Plataforma { get; set; }
        DbSet<Usuario> Usuario { get; set; }
        DbSet<Voucher> Voucher { get; set; }
        DbSet<Pergunta> Pergunta { get; set; }
        DbSet<Resposta> Resposta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //TODO: Mapeamentos necessários
        }

        public PollPlusMigrationContext()
            : base("MaisConnectionString")
        { }
    }
}
