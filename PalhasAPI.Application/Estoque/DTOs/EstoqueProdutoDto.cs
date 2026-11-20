

namespace PalhasAPI.Application.Estoque.DTOs
{
    public class EstoqueProdutoDto
    {
        public Guid ProdutoId { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public int EstoqueAtual { get; set; }
        public int EstoqueMinimo { get; set; }
        public bool AbaixoDoMinimo { get; set; }
    }
}
