using Invt.Model;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Invt.Control
{
    public class ArticulosControl
    {
        static protected string sql = ConfigurationManager.ConnectionStrings["Invt.Properties.Settings.Conexion"].ToString();

        public static void ArticuloInsertar(ArticulosBO articulo)
        {
            SqlConnection sqlConnection1 = new SqlConnection(sql);
            SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT articulos (codigo, nombre, descripcion  ) " +
                "VALUES ("+"'"+articulo.Codigo+"' , '"+articulo.Nombre+"' , '"+articulo.Descripcion+"');";
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();

            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
        }
    }
}
