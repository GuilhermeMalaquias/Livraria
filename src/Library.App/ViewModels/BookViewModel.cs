using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Library.App.Extension;
using Microsoft.AspNetCore.Http;

namespace Library.App.ViewModels
{
    public class BookViewModel
    {
        [Required]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [Display(Name = "Titulo")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O {0} é obrigatório conter de {2} a {1} caracteres.")]
        public string Title { get; set; }
        public string Image { get; set; }
        [DisplayName("Imagem do Produto")]
        public IFormFile ImageFile { get; set; }
        
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "O {0} é obrigatório conter {1} caracteres.")]
        public string ISBN { get; set; }
        
        public DateTime PublicationDate { get; set; }
        
        [Required]
        [Currency]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "É obrigatório informar se o curso está {0}.")]
        [Display(Name = "Disponivel")]
        public bool Active { get; set; }
        
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [Display(Name = "Descricao")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "O {0} é obrigatório conter de {2} a {1} caracteres.")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [Display(Name = "Autor")]
        public Guid AuthorId { get; set; }
        public AuthorViewModel Author { get; set; }
        
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [Display(Name = "Genero")]
        public Guid GenreId { get; set; }
        public GenreViewModel Genre { get; set; }
        
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [Display(Name = "Editora")]
        public Guid CompanyId { get; set; }
        public CompanyViewModel Company { get; set; }

        //------------------------------------------
        //Definindo Propiedades de navegação
        public IEnumerable<AuthorViewModel> Authors { get; set; }
        public IEnumerable<GenreViewModel> Genres { get; set; }
        public IEnumerable<CompanyViewModel> Companies { get; set; }
        
    }
}