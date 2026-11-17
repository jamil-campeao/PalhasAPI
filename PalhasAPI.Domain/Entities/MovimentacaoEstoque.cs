using PalhasAPI.Domain.Enum;

namespace PalhasAPI.Domain.Entities
{
    public class MovimentacaoEstoque
    {
        public Guid Id { get; private set; }
        public Guid ProdutoId { get; private set; }
        public Produto Produto { get; private set; }
        public TipoMovimentacao Tipo { get; private set; }
        public int Quantidade { get; private set; }
        public string Motivo { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public Guid? PedidoId { get; private set; }

        public MovimentacaoEstoque(Guid produtoId, TipoMovimentacao tipo, int quantidade, string motivo, Guid? pedidoId)
        {
            Id = Guid.NewGuid();
            ProdutoId = produtoId;
            Tipo = tipo;
            Quantidade = quantidade;
            Motivo = motivo;
            CriadoEm = DateTime.UtcNow;
            PedidoId = pedidoId;
        }
    }
}
