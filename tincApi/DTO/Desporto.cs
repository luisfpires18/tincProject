using System.Collections.Generic;

namespace tincApi.DTO
{
    public class Desporto : Organizacao
    {
        public int ID { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}