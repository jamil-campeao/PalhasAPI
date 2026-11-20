
namespace PalhasAPI.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entidade, Guid id) : base($"{entidade} com id '{id}' não foi encontrado.") { }
    }
}
