namespace PalhasAPI.Domain.Entities
{
    public class ItemPedido
    {
        public Guid Id { get; private set; }
        public Guid ProdutoId { get; private set; }
        public Produto Produto { get; private set; }
        public Guid PedidoId { get; private set; }
        public Pedido Pedido { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public decimal Subtotal { get; private set; }

        public ItemPedido(Guid produtoId, Guid pedidoId, int quantidade, decimal precoUnitario)
        {
            Id = Guid.NewGuid();
            ProdutoId = produtoId;
            PedidoId = pedidoId;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            Subtotal = quantidade * precoUnitario;
        }

    }
}
