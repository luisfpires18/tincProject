﻿using System;
using System.Collections.Generic;

namespace tincApi.DTO
{
    public class Pessoa
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Contacto { get; set; }

        public string Genero { get; set; }
        public string Cidade { get; set; }
        public string Nacionalidade { get; set; }
        public DateTime DataNascimento { get; set; }

        public string Foto { get; set; }

        public virtual ICollection<Inscricao> Inscricoes { get; set; }
       // public virtual ICollection<Management> Managements { get; set; }
        public virtual Equipa Equipa { get; set; }


    }
}