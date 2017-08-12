using System;

namespace tincApi.DTO
{
    public class Pedido
    {
        public int ID { get; set; }

        public string TipoPedido { get; set; }
        public string Assunto { get; set; }
        public DateTime DataPedido { get; set; }
    }
}
