namespace PalhasAPI.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string Nome{ get; private set; }
        public string? Telefone{ get; private set; }
        public bool Ativo { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public string? Observacoes { get; private set; }

        public ICollection<Pedido> Pedidos { get; private set; } = [];

        public Cliente(string nome, string? telefone, string? observacoes)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Telefone = telefone;
            Ativo = true;
            CriadoEm = DateTime.UtcNow;
            Observacoes = observacoes;
        }

        public void Atualizar(string nome, string? telefone, string? observacoes)
        {
            Nome = nome;
            Telefone = telefone ?? Telefone;
            Observacoes = observacoes ?? Observacoes;
        }
    }
}
