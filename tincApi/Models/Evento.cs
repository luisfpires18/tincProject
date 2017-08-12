using System;
using System.Collections.Generic;

namespace tincApi.Models
{
    public class Evento : Organizacao
    {
        public int ID { get; set; }

        public string Local { get; set; }

        public string Website { get; set; }

        public DateTime DataEvento { get; set; }

        public string Foto { get; set; }

        public string Ficheiro { get; set; }

        public bool Inscricoes { get; set; }

        public virtual Desporto Desporto { get; set; }

        public virtual ICollection<Prova> Provas { get; set; }

        public virtual ICollection<Extra> Extras { get; set; }

    }
}