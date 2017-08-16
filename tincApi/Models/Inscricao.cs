using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using tincApi.Models.Enum;

namespace tincApi.Models
{

    public class Inscricao
    {

        public int ID { get; set; }

        public TShirt Tamanho { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
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