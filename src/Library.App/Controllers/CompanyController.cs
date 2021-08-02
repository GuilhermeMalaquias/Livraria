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
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository companyRepository,
                                 IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        #region ListaEditora
        [Route("lista-de-editoras")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CompanyViewModel>>(await _companyRepository.GetAll()));
        }
        #endregion
        #region DetalhesEditora
        [Route("detalhes-da-editora/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var companyViewModel = await GetCompanyBooks(id);
            if (companyViewModel == null) return NotFound();

            return View(companyViewModel);
        }
        #endregion
        #region AdicionarEditora
        [ClaimsAuthorize("Company", "Create")]
        [Route("criar-editora")]
        public IActionResult Create()
        {
            return View();
        }
        [ClaimsAuthorize("Company", "Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("criar-editora")]
        public async Task<IActionResult> Create(CompanyViewModel companyViewModel)
        {
            if (!ModelState.IsValid) return View(companyViewModel);

            await _companyRepository.Create(_mapper.Map<Company>(companyViewModel));
            return RedirectToAction("Index");

        }
        #endregion
        #region EditarEditora
        [ClaimsAuthorize("Company", "Edit")]
        [Route("editar-editora/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {

            var companyViewModel = await GetCompanyBooks(id);
            if (companyViewModel == null) return NotFound();

            return View(companyViewModel);
        }

        [ClaimsAuthorize("Company", "Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar-editora/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id, CompanyViewModel companyViewModel)
        {
            if (id != companyViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(companyViewModel);
            await _companyRepository.Update(_mapper.Map<Company>(companyViewModel));
            return RedirectToAction("Index");

        }
        #endregion
        #region MetodosPrivados
        private async Task<CompanyViewModel> GetCompany(Guid id)
        {
            var company = _mapper.Map<CompanyViewModel>(await _companyRepository.GetById(id));
            return company;
        }
        private async Task<CompanyViewModel> GetCompanyBooks(Guid id)
        {
            var company = _mapper.Map<CompanyViewModel>(await _companyRepository.GetCompanyBooks(id));
            return company;
        }
        #endregion
    }
}
