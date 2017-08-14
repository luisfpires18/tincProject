using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
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
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Pedido> Pedido { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles).WithMany(r => r.Users)
                .Map(t => t.MapLeftKey("UserID")
                    .MapRightKey("RoleID")
                    .ToTable("UserRole"));

            modelBuilder.Entity<User>()
                .HasMany(u => u.Pessoas).WithMany(p => p.Users)
                .Map(t => t.MapLeftKey("UserID")
                    .MapRightKey("PessoaID")
                    .ToTable("Gestao"));

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute()));

        }
        
    }
}