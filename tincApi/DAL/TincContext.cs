using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using tincApi.Models;

namespace tincApi.DAL
{
    public class TincContext : DbContext
    {
        public TincContext() : base("TincContext")
        {
            
        }

        public DbSet<Desporto> Desporto { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Extra> Extra { get; set; }
        public DbSet<Prova> Prova { get; set; }
        public DbSet<Resultado> Resultado { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Inscricao> Inscricao { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Equipa> Equipa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<tincApi.Models.Pedido> Pedidoes { get; set; }
    }
}