using System.Collections.Generic;

namespace Library.Business.Models
{
    public class Genre : Entity
    {
        /*
         * Definindo model e suas propriedades de navegação 
         */
        public string Name { get; set; }
        public string Description { get; set; }
        
        public IEnumerable<Book> Books { get; set; }
    }
}