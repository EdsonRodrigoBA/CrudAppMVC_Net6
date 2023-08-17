using Microsoft.AspNetCore.Mvc;
using CadastroProdutos.WebApp.ViewModels;
using Cadastros.Business.Interfaces;
using AutoMapper;
using Cadastros.Business.Models;

namespace CadastroProdutos.WebApp.Controllers
{
    public class FornecedoresController : BaseController
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;


        public FornecedoresController(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var retorno = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return View(retorno);
                         
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var FornecedorViewModel = await ObterFornecedorEndereco(id);
            if (FornecedorViewModel == null)
            {
                return NotFound();
            }


            return View(FornecedorViewModel);
        }

        // GET: Fornecedores/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(fornecedorViewModel);

            }
            fornecedorViewModel.Id = Guid.NewGuid();

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            await _fornecedorRepository.Adicionar(fornecedor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var FornecedorViewModel = await ObterFornecedorProdutosEndereco(id);

            if (FornecedorViewModel == null)
            {
                return NotFound();
            }

            return View(FornecedorViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,FornecedorViewModel fornecedorViewModel)
        {
            if (id != fornecedorViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(fornecedorViewModel);

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            await _fornecedorRepository.Atualizar(fornecedor);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(Guid id)
        {

            var fornecedorViewModel = await ObterFornecedorEndereco(id);
            if (fornecedorViewModel == null)
            {
                return NotFound();
            }


            return View(fornecedorViewModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorEndereco(id);
            if (fornecedorViewModel == null)return NotFound();

            await _fornecedorRepository.Remover(id);
            return RedirectToAction(nameof(Index));
        }


        private async Task<FornecedorViewModel> ObterFornecedorEndereco(Guid Id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorEndereco(Id));
        }

        private async Task<FornecedorViewModel> ObterFornecedorProdutosEndereco(Guid Id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(Id));
        }
    }
}
