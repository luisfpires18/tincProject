using System;
using System.Collections.Generic;

namespace tincApi.Models
{
    public enum TShirt { XXL = 6, XL = 5, L = 4, M = 3, S = 2, XS = 1, XXS = 0 }

    public class Inscricao
    {

        public int ID { get; set; }

        public TShirt Tamanho { get; set; }

        public DateTime DataInscricao { get; set; }

        public string RegistadoPor { get; set; }

        public bool Estado { get; set; }

        public string Notas { get; set; }

        public int CategoriaID { get; set; }

        public int PessoaID { get; set; }

        // Navigation;
        public virtual Categoria Categoria { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public virtual ICollection<Extra> Extras { get; set; }
    }
}