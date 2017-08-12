using System.Collections.Generic;

namespace tincApi.DTO
{
    public class Prova : Organizacao
    {
        public int ID { get; set; }
        public float Distancia { get; set; }
        public float Preco { get; set; }
        public virtual Evento Evento { get; set; }
        public virtual ICollection<Categoria> Categorias { get; set; }
        public virtual ICollection<Resultado> Resultados { get; set; }
    }
}