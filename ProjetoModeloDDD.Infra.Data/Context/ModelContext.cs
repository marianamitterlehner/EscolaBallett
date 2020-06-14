using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.Context
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base("ProjetoModeloDDD")
        {
        }

        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Noticia> Noticias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Usuario>()
            //            .HasOptional(u => u.Assinatura)
            //            .WithRequired(ass => ass.Usuario);
        }

        public override int SaveChanges()
        {
            try
            {
                foreach (
                    var entry in
                        ChangeTracker.Entries()
                            .Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                        entry.Property("Liberado").CurrentValue = true;
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("DataCadastro").IsModified = false;
                        entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;

                    }

                    if (entry.State == EntityState.Deleted)
                    {
                        entry.Property("Excluido").CurrentValue = true;
                        entry.Property("Liberado").CurrentValue = false;
                        entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
                    }
                }

                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                    );
            }
            catch (DbUpdateException ex)
            {
                var sb = new StringBuilder();
                sb.AppendFormat("{0} failed validation\n", ex.InnerException);
                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                    );
            }
            catch (UpdateException ex)
            {
                var sb = new StringBuilder();
                sb.AppendFormat("{0} failed validation\n", ex.InnerException);
                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb, ex
                    );
            }

            catch (SqlException ex)
            {
                var sb = new StringBuilder();
                sb.AppendFormat("{0} failed validation\n", ex.InnerException);
                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb, ex
                    );
            }
        }

    }
}
