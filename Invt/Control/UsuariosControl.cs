using Invt.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invt.Control
{
    public class UsuariosControl
    {
        static protected string sql = ConfigurationManager.ConnectionStrings["Invt.Properties.Settings.Conexion"].ToString();
        public static ArrayList UsuariosRecuperar(Hashtable ht)
        {
            
            SqlConnection sqlConnection1 = new SqlConnection(sql);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            ArrayList ar = new ArrayList();
            cmd.CommandText = "SELECT * FROM "+ ht["usuarios"];
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.
            while (reader.Read())
            {
                UsuariosBO obj = new UsuariosBO();
                obj.usuarioID = int.Parse(reader["usuarioID"].ToString());
                obj.Nombre = reader["nombre"].ToString();
                obj.password = reader["password"].ToString();
                ar.Add(obj);
            }
            sqlConnection1.Close();
            return ar;
        }
        public static ArrayList UsuarioRecuperaEspecifico(Hashtable ht)
        {
            UsuariosBO obj = new UsuariosBO();
            SqlConnection sqlConnection1 = new SqlConnection(sql);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            ArrayList ar = new ArrayList();
            cmd.CommandText = "SELECT * FROM " + ht["usuarios"] + " where nombre = " + ht["Nombre"]+"  ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.
            while (reader.Read())
            {
                obj.usuarioID = int.Parse(reader["usuarioID"].ToString());
                obj.Nombre = reader["nombre"].ToString();
                obj.password = reader["password"].ToString();
                ar.Add(obj);
            }
            sqlConnection1.Close();
            return ar;
        }

    }
}
