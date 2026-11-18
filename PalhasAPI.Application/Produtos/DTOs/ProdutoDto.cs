

namespace PalhasAPI.Application.Produtos.DTOs
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal CustoProducao { get; set; }
        public string Unidade { get; set; } = string.Empty;
        public int EstoqueAtual { get; set; }
        public int EstoqueMinimo { get; set; }
        public bool Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
