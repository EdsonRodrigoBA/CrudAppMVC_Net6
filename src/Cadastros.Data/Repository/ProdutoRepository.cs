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
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(CadastrosDbContext db) : base(db)
        {
        }

        public async Task<Produto> ObterProdutoFornecedor(Guid Id)
        {
            return await _db.produtos.AsNoTracking().Include(f => f.Fornecedor).FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedores()
        {
            return await _db.produtos.AsNoTracking().Include(f => f.Fornecedor)
                   .OrderBy(p => p.Nome).ToListAsync();
        }
    }
}
