using APiServer.Models;
using System.Data;
using System.Data.SqlClient;

namespace APiServer.Dao
{
    public class CatalogoDAO
    {
        dbConecxion conecta = new dbConecxion();
        public List<Catalogo> GetCatalogo()
        {
            List<Catalogo> product = new List<Catalogo>();
           
            SqlConnection connection = new SqlConnection(conecta.CadenaConecxionSQL());
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("GetspLocalidades", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
           

            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                Catalogo obj = new Catalogo();
                obj.clave = dr[0].ToString();
                obj.Descripcion = dr[1].ToString();
                product.Add(obj);
                    
               



            }


            return product;
        }
    }
}
