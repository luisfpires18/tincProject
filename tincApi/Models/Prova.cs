using System;
using System.Collections.Generic;

namespace tincApi.Models
{
    public class Prova : Organizacao
    {
        public int ID { get; set; }
        public float Distancia { get; set; }
        public int EventoID { get; set; }

        // Navigation;
        public virtual Evento Evento { get; set; }
        public virtual ICollection<Categoria> Categorias { get; set; }
    }
}