using Cadastros.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastros.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("enderecos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Logradouro).IsRequired().HasColumnType("varchar(500)");
            builder.Property(x => x.Numero).IsRequired().HasColumnType("varchar(20)");
            builder.Property(x => x.Complemento).IsRequired().HasColumnType("varchar(350)");
            builder.Property(x => x.Cep).IsRequired().HasColumnType("varchar(350)");
            builder.Property(x => x.Bairro).IsRequired().HasColumnType("varchar(350)");
            builder.Property(x => x.Cidade).IsRequired().HasColumnType("varchar(350)");
            builder.Property(x => x.Estado).IsRequired().HasColumnType("varchar(350)");





        }
    }

}
