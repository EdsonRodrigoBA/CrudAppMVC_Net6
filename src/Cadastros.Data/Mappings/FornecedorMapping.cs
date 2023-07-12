using Cadastros.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastros.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("fornecedores");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(500)");
            builder.Property(x => x.Documento).IsRequired().HasColumnType("varchar(1000)");

            builder.HasOne(f => f.Endereco).WithOne(e => e.Fornecedor);
            builder.HasMany(f => f.Produtos).WithOne(p => p.Fornecedor).HasForeignKey(fk => fk.FornecedorId);

        }
    }

}
