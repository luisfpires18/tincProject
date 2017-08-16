using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tincApi.Models
{
    public class Evento : Organizacao
    {
        public int ID { get; set; }

        public string Local { get; set; }

        public string Website { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data do Evento")]
        public DateTime DataEvento { get; set; }

        public string Foto { get; set; }

        public string Ficheiro { get; set; }

        public bool Inscricoes { get; set; }

        [Display(Name = "Desporto")]
        public int DesportoID { get; set; }

        // Navigation Attributes;

        public virtual Desporto Desporto { get; set; }

        public virtual ICollection<Prova> Provas { get; set; }

        public virtual ICollection<Extra> Extras { get; set; }

    }
}