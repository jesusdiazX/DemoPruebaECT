using APiServer.Models;
using System.Net.Mail;

namespace APiServer.Logic
{
    public class SmtpCorreo
    {
        private SmtpClient cliente;
        private static IConfiguration Configuration { get; set; }
        private MailMessage email;

        public void EnviarCorreo(string destinatario, string asunto, string mensaje, bool esHtlm = false)
        {
            email = new MailMessage(Configuration["user"], destinatario, asunto, mensaje);
            email.IsBodyHtml = esHtlm;
            cliente.Send(email);
        }
    }


}
