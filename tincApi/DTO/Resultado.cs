namespace tincApi.DTO
{
    public class Resultado : Organizacao
    {
        public int ID { get; set; }
        public virtual Prova Prova { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}