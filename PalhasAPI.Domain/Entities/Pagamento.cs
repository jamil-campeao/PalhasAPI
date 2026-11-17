using PalhasAPI.Domain.Enum;

namespace PalhasAPI.Domain.Entities
{
    public class Pagamento
    {
        public Guid Id { get; private set; }
        public Guid PedidoId { get; private set; }
        public Pedido Pedido { get; private set; }
        public decimal Valor { get; private set; }
        public FormaPagamento Forma { get; private set; }
        public StatusPagamento Status { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public DateTime? PagoEm { get; set; }
        public DateTime? VencimentoEm { get; set; }

        public Pagamento(Guid pedidoId, decimal valor, FormaPagamento forma, DateTime? vencimentoEm)
        {
            Id = Guid.NewGuid();
            PedidoId = pedidoId;
            Valor = valor;
            Forma = forma;
            Status = forma == FormaPagamento.Fiado ? StatusPagamento.Pendente : StatusPagamento.Pago;
            CriadoEm = DateTime.UtcNow;
            PagoEm = forma != FormaPagamento.Fiado ? DateTime.UtcNow : null;
            VencimentoEm = vencimentoEm;
        }
    }
}
