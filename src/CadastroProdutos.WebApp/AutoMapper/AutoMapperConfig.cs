using AutoMapper;
using CadastroProdutos.WebApp.ViewModels;
using Cadastros.Business.Models;

namespace CadastroProdutos.WebApp.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();


        }
    }
}
