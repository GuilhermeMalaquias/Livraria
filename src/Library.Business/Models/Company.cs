using System.Collections.Generic;

namespace Library.Business.Models
{
    public class Company : Entity
    {
        /*
         * Definindo model e suas propriedades de navegação 
         */
        public string Name { get; set; }
        public string Document { get; set; }
        public TypePerson TypePerson { get; set; }
        
        public IEnumerable<Book> Books { get; set; }
        
    }
}