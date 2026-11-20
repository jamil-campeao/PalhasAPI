

namespace PalhasAPI.Domain.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string mensagem) : base(mensagem) { }
    }
}
