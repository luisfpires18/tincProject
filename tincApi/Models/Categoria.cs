using System;
using System.Collections.Generic;
using tincApi.Models.Enum;

namespace tincApi.Models
{

    public class Categoria : Organizacao
    {
        public int ID { get; set; }

        public Genero Genero { get; set; }

        public Atleta TipoAtleta { get; set; }

        public int Vencedores { get; set; }

        public int IdadeMin { get; set; }

        public int IdadeMax { get; set; }

        public int ProvaID { get; set; }

        // Navigation;
        public virtual Prova Prova { get; set; }
        public virtual ICollection<Inscricao> Inscricoes { get; set; }
        public virtual ICollection<Resultado> Resultados { get; set; }
    }
}