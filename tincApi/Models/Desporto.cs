using System;
using System.Collections.Generic;

namespace tincApi.Models
{
    public class Desporto : Organizacao
    {
        public int ID { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}