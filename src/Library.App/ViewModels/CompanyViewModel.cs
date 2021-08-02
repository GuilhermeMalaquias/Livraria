using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.App.ViewModels
{
    public class CompanyViewModel
    {
        [Required]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [Display(Name = "Editora")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O {0} é obrigatório conter de {2} a {1} caracteres.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [Display(Name = "Documento")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O {0} é obrigatório conter de {2} a {1} caracteres.")]
        public string Document { get; set; }
        
        [DisplayName("Tipo")]
        public int TypePerson { get; set; }
        
        public IEnumerable<BookViewModel> Books { get; set; }
        
    }
}