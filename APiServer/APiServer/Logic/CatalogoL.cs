using APiServer.Dao;
using APiServer.Models;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;

namespace APiServer.Logic
{

    public class CatalogoL : ICatalogo
    {
        private SmtpClient Cliente { get; }
        
        private EmailSenderOptions Options { get; }

        public CatalogoL(IOptions<EmailSenderOptions> options)
        {
            Options = options.Value;
            Cliente = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("ejemplopruebadiaz@gmail.com", "rkjvpkwkjqhkydur")


        };
        }
        public List<Catalogo> lista()
        {
            var dao = new CatalogoDAO();

            return dao.GetCatalogo();
        }

    
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var correo = new MailMessage(from: Options.Email, to: email, subject: subject, body: message);
            correo.IsBodyHtml = true;

            return Cliente.SendMailAsync(correo);
        }
    }
}

