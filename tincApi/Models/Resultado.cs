using System;

namespace tincApi.Models
{
    public class Resultado
    {
        public int ID { get; set; }
        public int PessoaID { get; set; }
        public int CategoriaID { get; set; }

        // Navigation;
        public virtual Pessoa Pessoa { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}