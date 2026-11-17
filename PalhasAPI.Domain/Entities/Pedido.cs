using PalhasAPI.Domain.Enum;

namespace PalhasAPI.Domain.Entities
{
    public class Pedido
    {
        public Guid Id { get; private set; }
        public string Numero { get; private set; }
        public Guid ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public StatusPedido Status { get; private set; }
        public decimal Subtotal { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal Total { get; private set; }
        public string? Observacoes { get; private set; }


        // Navegação
        public ICollection<ItemPedido> Itens { get; private set; } = [];
        public ICollection<Pagamento> Pagamentos { get; private set; } = [];


        public Pedido(string numero, Guid clienteId, string? observacoes)
        {
            Id = Guid.NewGuid();
            Numero = numero;
            ClienteId = clienteId;
            CriadoEm = DateTime.UtcNow;
            Status = StatusPedido.Pendente ;
            Subtotal = 0;
            Desconto = 0;
            Total = 0;
            Observacoes = observacoes;
        }
    }
}
