using System;

namespace Library.Business.Models
{
    public abstract class Entity
    {
        /*
         * Classe do tipo abstract só pode ser herdada.
         *
         * Definindo um Id do tipo Guid para suas entidades filhas.
         */

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}