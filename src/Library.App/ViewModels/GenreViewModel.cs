using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.App.ViewModels
{
    public class GenreViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Genero")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O {0} é obrigatório conter de {2} a {1} caracteres.")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Descricao")]
        [StringLength(300, MinimumLength = 2, ErrorMessage = "O {0} é obrigatório conter de {2} a {1} caracteres.")]
        public string Description { get; set; }
        
        public IEnumerable<BookViewModel> Books { get; set; }
    }
}