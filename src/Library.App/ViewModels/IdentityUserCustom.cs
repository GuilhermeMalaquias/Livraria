using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Library.App.ViewModels
{
    public class IdentityUserCustom : IdentityUser
    {
        /*
         * Estendendo o IdentityUser
         */
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [Display(Name = "Nome")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O {0} deve conter de {2} a {1} caracteres.")]
        public string FirstName { get; set; }

        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "A {0} é obrigatória.")]
        [Display(Name = "Cidade")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "A {0} deve conter de {2} a {1} caracteres.")]
        public string City { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [Display(Name = "Bairro")]
        [StringLength(120, MinimumLength = 2, ErrorMessage = "O {0} deve conter de {2} a {1} caracteres.")]
        public string District { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [Display(Name = "UF")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O {0} deve conter de {2} a {1} caracteres.")]
        public string UF { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [Display(Name = "CEP")]
        [StringLength(9, MinimumLength = 8, ErrorMessage = "O {0} deve conter de {2} a {1} caracteres.")]
        public string PostalCode { get; set; }
    }
}
