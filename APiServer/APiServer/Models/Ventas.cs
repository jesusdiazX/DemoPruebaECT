namespace APiServer.Models
{
    public class Ventas
    {
        public string descripcion { get; set; }   
        public int articuloId { get; set; }

        public decimal Precio { get; set; }
      //  public int artCienteId { get; set; }
        public string imagen { get; set; }
        public decimal stock  { get; set; }
    }
}
