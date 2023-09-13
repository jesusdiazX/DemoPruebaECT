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
                Credentials = new NetworkCredential(Options.Email,Options.Password)
               
      
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

            MailMessage message0 = new MailMessage();
            message0.To.Add(new MailAddress(email));
            message0.From= new MailAddress("mail.com");
            message0.Subject = "Prueba de llenado de formulario";
            message0.Body = "Bienvenidos a la  prueba";
           

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(Options.Email,Options.Password);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
           // smtpClient.Send(message0);
            return Cliente.SendMailAsync(message0);
        }
    }
}

