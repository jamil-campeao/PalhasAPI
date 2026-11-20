
using PalhasAPI.Domain.Enum;

namespace PalhasAPI.Application.Pedidos.DTOs
{
    public class PedidoDto
    {
        public Guid Id { get; set; }
        public string Numero { get; set; } = string.Empty;
        public Guid ClienteId { get; set; }
        public string NomeCliente { get; set; } = string.Empty;
        public StatusPedido Status { get; set; }
        public string StatusDescricao { get; set; } = string.Empty;
        public decimal Subtotal { get; set; }
        public decimal Desconto { get; set; }
        public decimal Total { get; set; }
        public string? Observacoes { get; set; }
        public DateTime CriadoEm { get; set; }
        public List<ItemPedidoDto> Itens { get; set; } = [];
    }
}
