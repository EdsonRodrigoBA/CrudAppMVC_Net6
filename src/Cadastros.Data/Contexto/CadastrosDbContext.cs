using Cadastros.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastros.Data.Contexto
{
    public class CadastrosDbContext : DbContext
    {
        public CadastrosDbContext(DbContextOptions options) : base(options)
        {
                
        }
         
        public DbSet<Produto> produtos { get; set; }
        public DbSet<Endereco> enderecos { get; set; }
        public DbSet<Fornecedor> fornecedores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CadastrosDbContext).Assembly);
            //desabilitar o ONCascade nos relacionamentos
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(300)");
            }
            base.OnModelCreating(modelBuilder); 
        }

    }
}
