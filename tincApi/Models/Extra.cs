using System;

namespace tincApi.Models
{
    public class Extra : Organizacao
    {
        public int ID { get; set; }

        public float Preco { get; set; }

        public virtual Evento Evento { get; set; }
    }
}