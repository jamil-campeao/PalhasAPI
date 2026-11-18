
namespace PalhasAPI.Domain.Entities
{
    public class Produto
    {
        public Guid Id{ get; private set; }
        public string Nome { get; private set; }
        public string? Descricao { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public decimal CustoProducao { get; private set; }
        public string Unidade { get; private set; }
        public int EstoqueAtual { get; private set; }
        public int EstoqueMinimo { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime CriadoEm { get; private set; }

        public ICollection<ItemPedido> ItensPedido { get; private set; } = [];
        public ICollection<MovimentacaoEstoque> Movimentacoes { get; private set; } = [];


        public Produto(string nome, string? descricao, decimal precoVenda, decimal custoProducao, string unidade, int estoqueMinimo)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Descricao = descricao;
            PrecoVenda = precoVenda;
            CustoProducao = custoProducao;
            Unidade = unidade;
            EstoqueAtual = 0;
            EstoqueMinimo = estoqueMinimo;
            Ativo = true;
            CriadoEm = DateTime.UtcNow;
        }

        public void Atualizar(string nome, string? descricao, decimal precoVenda, decimal custoProducao, string unidade, int estoqueMinimo)
        {
            Nome = nome;
            Descricao = descricao ?? Descricao;
            PrecoVenda = precoVenda;
            CustoProducao = custoProducao;
            Unidade = unidade;
            EstoqueMinimo = estoqueMinimo;
        }
    }
}
