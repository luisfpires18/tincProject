using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tincApi.Models;

namespace tincApi.ViewModels
{
    public class EventoData
    {
        public IEnumerable<Evento> Eventos { get; set; }
        public IEnumerable<Prova> Provas { get; set; }
        public IEnumerable<Extra> Extras { get; set; }
        public IEnumerable<Categoria> Categorias { get; set; }
        public IEnumerable<Inscricao> Inscricoes { get; set; }
    }
}