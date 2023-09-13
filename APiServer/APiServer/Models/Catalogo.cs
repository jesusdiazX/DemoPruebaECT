namespace APiServer.Models
{
    public class Catalogo
    {
        public string clave { get; set; }
        public string Descripcion { get; set; }
    }

    public class Datos
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Fecha { get; set; }

        public string CiudadEstado { get; set; }
    }

    public class EmailSenderOptions
    {
        public int Port { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool EnableSsl { get; set; }
        public string Host { get; set; }
    }
}
