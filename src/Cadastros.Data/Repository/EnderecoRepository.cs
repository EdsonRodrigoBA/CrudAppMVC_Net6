using Cadastros.Business.Interfaces;
using Cadastros.Business.Models;
using Cadastros.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastros.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(CadastrosDbContext db) : base(db)
        {
        }

        public async Task<Endereco> ObterEnderecoPorFornecedo(Guid fornecedorId)
        {
            return await _db.enderecos.AsNoTracking()
                            .FirstOrDefaultAsync(p => p.FornecedorId == fornecedorId);

        }
    }
}
