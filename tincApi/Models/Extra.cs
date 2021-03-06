﻿using System;
using System.Collections.Generic;

namespace tincApi.Models
{
    public class Extra : Organizacao
    {
        public int ID { get; set; }

        public float Preco { get; set; }

        public int EventoID { get; set; }

        // Navigation;
        public virtual Evento Evento { get; set; }

        public virtual ICollection<Inscricao> Inscricoes { get; set; }
    }
}