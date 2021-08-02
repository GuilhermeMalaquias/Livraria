using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Library.App.Extension;
using Microsoft.AspNetCore.Mvc;
using Library.App.ViewModels;
using Library.Business.Interface;
using Library.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Library.App.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly UserManager<IdentityUserCustom> _userManager;

        public BookController(IBookRepository bookRepository,
                              IMapper mapper,
                              IAuthorRepository authorRepository,
                              IGenreRepository genreRepository,
                              ICompanyRepository companyRepository,
                              UserManager<IdentityUserCustom> userManager)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
            _companyRepository = companyRepository;
            _userManager = userManager;
        }

        #region ListaLivros
        [HttpGet]
        [Route("lista-de-livros")]
        public async Task<IActionResult> Index(string filter, string filterDesc)
        {
            if (!string.IsNullOrEmpty(filterDesc))
            {
                return View(_mapper.Map<IEnumerable<BookViewModel>>(await _bookRepository.GetBooksAuthorsGenresCompaniesDecreasing(await UserIsInRole("Admin") || await UserIsInRole("Manager"))));
            }

            if (!string.IsNullOrEmpty(filter))
            {
                return View(_mapper.Map<IEnumerable<BookViewModel>>(await _bookRepository.FindBook(filter, await UserIsInRole("Admin") || await UserIsInRole("Manager"))));
            }
            else
            {
                return View(_mapper.Map<IEnumerable<BookViewModel>>(await _bookRepository.GetBooksAuthorsGenresCompanies(await UserIsInRole("Admin") || await UserIsInRole("Manager"))));
            }
        }
        #endregion
        #region DetalhesLivro
        [Route("detalhes-do-livro")]
        public async Task<IActionResult> Details(Guid id)
        {

            var bookViewModel = await GetBook(id);
            if (bookViewModel == null) return NotFound();

            return View(bookViewModel);
        }
        #endregion
        #region DetalhesCompleto
        [Route("detalhe-completo-do-livro")]
        public async Task<IActionResult> AllDetails(Guid id)
        {

            var bookViewModel = await GetBook(id);
            if (bookViewModel == null) return NotFound();

            return View("MostrarTudo", bookViewModel);
        }
        #endregion
        #region AdicionarLivro
        [ClaimsAuthorize("Book", "Create")]
        [Route("criar-livro")]
        public async Task<IActionResult> Create()
        {
            var book = await GetDependencies(new BookViewModel());
            return View(book);
        }
        [ClaimsAuthorize("Book", "Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("criar-livro")]
        public async Task<IActionResult> Create(BookViewModel bookViewModel)
        {
            bookViewModel = await GetDependencies(bookViewModel);
            if (!ModelState.IsValid) return View(bookViewModel);

            var imgPrefixo = Guid.NewGuid() + "_";
            if (!await UploadFile(bookViewModel.ImageFile, imgPrefixo)) return View(bookViewModel);
            bookViewModel.Image = imgPrefixo + bookViewModel.ImageFile.FileName;

            await _bookRepository.Create(_mapper.Map<Book>(bookViewModel));
            return RedirectToAction("Index");
        }
        #endregion
        #region EditarLivro
        [ClaimsAuthorize("Book", "Edit")]
        [Route("editar-livro/{id:guid}")]
        
        public async Task<IActionResult> Edit(Guid id)
        {
            var bookViewModel = await GetBook(id);
            if (bookViewModel == null) return NotFound();
            
            return View(bookViewModel);
        }
        
        [ClaimsAuthorize("Book", "Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar-livro/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id,  BookViewModel bookViewModel)
        {
            if (id != bookViewModel.Id) return NotFound();

            var book = await GetBook(id);

            bookViewModel.Author = book.Author;
            bookViewModel.Genre = book.Genre;
            bookViewModel.Company = book.Company;
            bookViewModel.Image = book.Image;
            
            
            if (!ModelState.IsValid) return View(bookViewModel);

            if (bookViewModel.ImageFile != null)
            {
                var imgPrefixo = Guid.NewGuid() + "_";

                if (!await UploadFile(bookViewModel.ImageFile, imgPrefixo))
                {
                    return View(bookViewModel);
                }

                book.Image = imgPrefixo + bookViewModel.ImageFile.FileName;
            }
            /*
             * Criando variável auxiliar para evitar que o usuario tente trocar de alguma forma os Ids
             * de Autor, Genero ou Editora(Company)
             */
            book.Active = bookViewModel.Active;
            book.Description = bookViewModel.Description;
            book.Title = bookViewModel.Title;
            book.Price = bookViewModel.Price;
            
            await _bookRepository.Update(_mapper.Map<Book>(book));
            return RedirectToAction("Index");
        }
        #endregion
        #region ExcluirLivro
        [ClaimsAuthorize("Book", "Delete")]
        [Route("excluir-livro/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var bookViewModel = await GetBook(id);
            if (bookViewModel == null) return NotFound();

            return View(bookViewModel);
        }


        [ClaimsAuthorize("Book", "Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("excluir-livro/{id:guid}")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bookViewModel = await GetBook(id);
            if (bookViewModel == null) return NotFound();
            await _bookRepository.Delete(bookViewModel.Id);
            return RedirectToAction("Index");
        }
        #endregion
        #region MetodosPrivados
        private async Task<BookViewModel> GetBook(Guid id)
        {
            var book = _mapper.Map<BookViewModel>(await _bookRepository.GetBookAuthorsGenresCompanies(id));
            return book;
        }
        /*
         * Populando as Propiedades de navegação a fim de autilizar para a criação de um novo livro
         */
        private async Task<BookViewModel> GetDependencies(BookViewModel book)
        {
            book.Authors = _mapper.Map<IEnumerable<AuthorViewModel>>(await _authorRepository.GetAll());
            book.Genres = _mapper.Map<IEnumerable<GenreViewModel>>(await _genreRepository.GetAll());
            book.Companies = _mapper.Map<IEnumerable<CompanyViewModel>>(await _companyRepository.GetAll());
            return book;
        }
        /*
         * Metodo para fazer o upload da imagem de capa do Book
         * Definindo um prefixo unico e granvando na propiedade Imagem no model do livro
         * A fim de chamá-lo na view.
         */
        private async Task<bool> UploadFile(IFormFile file, string imgPrefixo)
        {
            if (file.Length <= 0 || file == null) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory()
                                    + "/wwwroot/image/book", imgPrefixo + file.FileName);
            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError("", "Ja existe uma arquivo com esse nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return true;
        }
        /*
         * Pegando usuário logado e verificando sua role.
         */
        private async Task<bool> UserIsInRole(string role)
        {
            var user = await _userManager.GetUserAsync(User);

            if (!await _userManager.IsInRoleAsync(user, role))
            {
                return false;
            }

            return true;
        }
        #endregion

    }
}
