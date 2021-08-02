using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.App.Extension;
using Microsoft.AspNetCore.Mvc;
using Library.App.ViewModels;
using Library.Business.Interface;
using Library.Business.Models;
using Microsoft.AspNetCore.Authorization;

namespace Library.App.Controllers
{
    [Authorize]
    public class GenreController : Controller
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreController(IGenreRepository genreRepository,
                               IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        #region ListarGenero
        [Route("lista-de-generos")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<GenreViewModel>>(await _genreRepository.GetAll()));
        }
        #endregion
        #region DetalhesGenero
        [Route("detalhes-do-genero/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {

            var genreViewModel = await GetGenreBooks(id);
            if (genreViewModel == null) return NotFound();

            return View(genreViewModel);
        }
        #endregion
        #region AdicionarGenero
        [ClaimsAuthorize("Genre", "Create")]
        [Route("criar-genero")]
        public IActionResult Create()
        {
            return View();
        }
        [ClaimsAuthorize("Genre", "Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("criar-genero")]
        public async Task<IActionResult> Create(GenreViewModel genreViewModel)
        {
            if (!ModelState.IsValid) return View(genreViewModel);

            await _genreRepository.Create(_mapper.Map<Genre>(genreViewModel));
            return RedirectToAction("Index");

        }
        #endregion
        #region EditarGenero
        [ClaimsAuthorize("Genre", "Edit")]
        [Route("editar-genero/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {

            var genreViewModel = await GetGenreBooks(id);
            if (genreViewModel == null) return NotFound();

            return View(genreViewModel);
        }

        [ClaimsAuthorize("Genre", "Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar-genero/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id, GenreViewModel genreViewModel)
        {
            if (id != genreViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(genreViewModel);

            await _genreRepository.Update(_mapper.Map<Genre>(genreViewModel));
            return RedirectToAction("Index");

        }
        #endregion
        #region MetodosPrivados
        private async Task<GenreViewModel> GetGenre(Guid id)
        {
            var genre = _mapper.Map<GenreViewModel>(await _genreRepository.GetById(id));
            return genre;
        }

        private async Task<GenreViewModel> GetGenreBooks(Guid id)
        {
            var genre = _mapper.Map<GenreViewModel>(await _genreRepository.GetGenreBooks(id));
            return genre;
        }
        #endregion


    }
}
