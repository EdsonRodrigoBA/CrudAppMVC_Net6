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
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(CadastrosDbContext db) : base(db)
        {
        }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid Id)
        {
            return await _db.fornecedores.AsNoTracking().Include(f => f.Endereco).FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid Id)
        {
            return await _db.fornecedores.AsNoTracking().
                Include(f => f.Endereco)
                .Include(p => p.Produtos)
                .FirstOrDefaultAsync(p => p.Id == Id);
        }
    }
}
