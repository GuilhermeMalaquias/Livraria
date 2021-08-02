using AutoMapper;
using Library.Business.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Library.App.Extension;
using Microsoft.AspNetCore.Mvc;
using Library.App.ViewModels;
using Library.Business.Models;
using Microsoft.AspNetCore.Authorization;

namespace Library.App.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepository authorRepository,
                                IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        #region ListaAutores
        [Route("lista-de-autores")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<AuthorViewModel>>(await _authorRepository.GetAll()));
        }
        #endregion
        #region DetalhesAutores
        [Route("detalhes-do-autor/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {

            var authorViewModel = await GetAuthorBooks(id);
            if (authorViewModel == null) return NotFound();

            return View(authorViewModel);
        }
        #endregion
        #region AdicionarAutor
        [ClaimsAuthorize("Author", "Create")]
        [Route("criar-autor")]
        public IActionResult Create()
        {
            return View();
        }
        [ClaimsAuthorize("Author", "Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("criar-autor")]
        public async Task<IActionResult> Create(AuthorViewModel authorViewModel)
        {
            if (!ModelState.IsValid) return View(authorViewModel);

            var author = _mapper.Map<Author>(authorViewModel);
            await _authorRepository.Create(author);

            return RedirectToAction("Index");

        }
        #endregion
        #region EditarAutor
        [ClaimsAuthorize("Author", "Edit")]
        [Route("editar-autor/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var authorViewModel = await GetAuthorBooks(id);
            if (authorViewModel == null) return NotFound();

            return View(authorViewModel);
        }
        [ClaimsAuthorize("Author", "Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar-autor/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id, AuthorViewModel authorViewModel)
        {
            if (id != authorViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return NotFound();
            await _authorRepository.Update(_mapper.Map<Author>(authorViewModel));
            return RedirectToAction("Index");
        }
        #endregion
        #region MetodosPrivados
        private async Task<AuthorViewModel> GetAuthor(Guid id)
        {
            var produto = _mapper.Map<AuthorViewModel>(await _authorRepository.GetById(id));
            return produto;
        }
        private async Task<AuthorViewModel> GetAuthorBooks(Guid id)
        {
            return _mapper.Map<AuthorViewModel>(await _authorRepository.GetAuthorBooks(id));
        }
        #endregion

    }
}
