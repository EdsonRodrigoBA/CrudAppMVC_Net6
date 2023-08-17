using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CadastroProdutos.WebApp.ViewModels;

namespace CadastroProdutos.WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CadastroProdutos.WebApp.ViewModels.FornecedorViewModel>? FornecedorViewModel { get; set; }
        public DbSet<CadastroProdutos.WebApp.ViewModels.ProdutoViewModel>? ProdutoViewModel { get; set; }
    }
}