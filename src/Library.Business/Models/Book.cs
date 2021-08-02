using System;

namespace Library.Business.Models
{
    public class Book : Entity
    {
        /*
         * Definindo model e suas propriedades de navegação 
         */
        public string Title { get; set; }
        public string Image { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }
        
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}