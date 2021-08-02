using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.App.ViewModels
{
    public class AuthorViewModel
    {
        [Required]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [Display(Name = "Nome")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O {0} é obrigatório conter de {2} a {1} caracteres.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [Display(Name = "Documento")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O {0} é obrigatório conter de {2} a {1} caracteres.")]
        public string Document { get; set; }
        
        [DisplayName("Tipo")]
        public int TypePerson { get; set; }
        
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [Display(Name = "Sobre")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "O {0} é obrigatório conter de {2} a {1} caracteres.")]
        public string About { get; set; }
        
        public IEnumerable<BookViewModel> Books { get; set; }
    }
}