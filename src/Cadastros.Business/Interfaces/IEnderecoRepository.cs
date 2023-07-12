using Cadastros.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastros.Business.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<Endereco> ObterEnderecoPorFornecedo(Guid fornecedorId);
    }
}
