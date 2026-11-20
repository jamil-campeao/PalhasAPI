

using PalhasAPI.Domain.Enum;

namespace PalhasAPI.Application.Estoque.DTOs
{
    public class MovimentacaoDto
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public int Quantidade { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public DateTime CriadoEm { get; set; }
    }
}
