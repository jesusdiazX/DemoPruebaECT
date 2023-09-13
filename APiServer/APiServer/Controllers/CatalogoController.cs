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

            // gestor.EnviarCorreo(dato.Email, "Prueba", "Esto Es un prueba",false);
            _catalogo
           .SendEmailAsync(dato.Email, "Asunto", "Mensaje");
          

        }







    }
}
