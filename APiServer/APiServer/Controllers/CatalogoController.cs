using APiServer.Logic;
using APiServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace APiServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogoController : ControllerBase
    {


        private readonly ICatalogo _catalogo;
   
        public CatalogoController(ICatalogo cat)
        {
            _catalogo = cat;


        }


        [HttpGet]
        [Route("GetEstados")]
        public List<Models.Catalogo> Get()
        {
            var ls = _catalogo.lista();

            return ls.ToList();
        }


        [HttpPost]
        [Route("EnviarCorreo")]
        public void EnviarCorreo(Datos dato)
        {
            SmtpCorreo gestor = new SmtpCorreo();

            string html = "<body style=\"background-color:grey\">\r\n  <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"\r\n " +
                "        width=\"550\" bgcolor=\"white\" style=\"border:2px solid black\">\r\n      <tbody>\r\n          <tr>\r\n       " +
                "       <td align=\"center\">\r\n                  <table align=\"center\" border=\"0\" cellpadding=\"0\" \r\n            " +
                "             cellspacing=\"0\" class=\"col-550\" width=\"550\">\r\n                      <tbody>\r\n                  " +
                "        <tr>\r\n                              <td align=\"center\" style=\"background-color: #4cb96b;\r\n        " +
                "                                 height: 50px;\">\r\n\r\n                        " +
                "          <a href=\"#\" style=\"text-decoration: none;\">\r\n                         " +
                "             <p style=\"color:white;\r\n                                                font-weight:bold;\">\r\n         " +
                "                                 Green Leaves\r\n                                      </p>\r\n                               " +
                "   </a>\r\n                              </td>\r\n                          </tr>\r\n                      </tbody>\r\n                  </table>\r\n              </td>\r\n          </tr>\r\n        \r\n\r\n          <tr style=\"display: inline-block;\">\r\n              <td style=\"height: 150px;\r\n                         padding: 20px;\r\n                         border: none; \r\n     " +
                "                    border-bottom: 2px solid #361B0E;\r\n                         background-color: white;\">\r\n                  \r\n                  <h4 style=\"text-align: left;\r\n                             align-items: center;\">\r\n                      Estimado : <span> "+dato.nombre+" </span>\r\n    " +
                "             </h4>\r\n                  <p class=\"data\" \r\n          " +
                "           style=\"text-align: justify-all;\r\n                            align-items: center; \r\n                            font-size: 15px;\r\n                            padding-bottom: 12px;\">\r\n                     Hemos recibido sus datos y nos pondremos en contacto con usted en la \r\n                     brevedad posible. Enviaremos un correo con información a su cuenta: \r\n             " +dato.Email +" "+
                "     </p>\r\n                  <p>\r\n                    Atte.\r\n                   \r\n                </p>\r\n                <p>\r\n                 Green Leaves\r\n                 \r\n              </p>\r\n              <p>"+dato.CiudadEstado+ " a "+dato.Fecha  +"</p>\r\n              </td>\r\n          </tr>\r\n      </tbody>\r\n  </table>\r\n</body>";
            // gestor.EnviarCorreo(dato.Email, "Prueba", "Esto Es un prueba",false);
            _catalogo
           .SendEmailAsync(dato.Email, "Asunto", html);
          

        }







    }
}
