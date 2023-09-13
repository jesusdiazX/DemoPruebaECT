using APiServer.Models;

namespace APiServer.Logic
{
    public interface ICatalogo
    {
        public List<Catalogo> lista();
        Task SendEmailAsync(string email, string subject, string message);

    }
}
