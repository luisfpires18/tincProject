using System;
using System.Collections.Generic;

namespace tincApi.Models
{
    public class Categoria : Organizacao
    {
        public int ID { get; set; }

        public string Genero { get; set; }

        public string TipoAtleta { get; set; }

        public int Vencedores { get; set; }

        public int IdadeMin { get; set; }

        public int IdadeMax { get; set; }

        public virtual Prova Prova { get; set; }

        public virtual ICollection<Inscricao> Inscricoes { get; set; }
        public virtual ICollection<Resultado> Resultados { get; set; }
    }
}