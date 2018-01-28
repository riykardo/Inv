using Invt.Model;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Invt.Control
{
    public class ArticulosControl
    {
        static protected string sql = ConfigurationManager.ConnectionStrings["Invt.Properties.Settings.Conexion"].ToString();

        public static void ArticuloInsertar(ArticulosBO articulo)
        {
            SqlConnection sqlConnection1 = new SqlConnection(sql);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT articulos (codigo, nombre, descripcion  ) " +
                "VALUES ("+"'"+articulo.Codigo+"' , '"+articulo.Nombre+"' , '"+articulo.Descripcion+"');";
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();

            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
        }

        public static void ArticulosLeer()
        {
            SqlConnection conexion = new SqlConnection(sql);
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand();
            ArrayList list = new ArrayList();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from articulos";
            cmd.Connection = conexion;
            conexion.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ArticulosBO obj = new ArticulosBO();
                obj.ArticuloID = int.Parse(reader["articuloID"].ToString());
                obj.Codigo = reader["codigo"].ToString();
                obj.Nombre = reader["nombre"].ToString();
                obj.Descripcion = reader["Descripcion"].ToString();
                list.Add(obj);
            }
            conexion.Close();
            
        }

        public static void ArticulosModificar(ArticulosBO articulo)
        {
            SqlConnection sqlConnection1 = new SqlConnection(sql);
            SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE Articulos SET" + articulo.Codigo + " where  codigo = " + articulo.Codigo;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            try
            {
                // Create a new data adapter based on the specified query.
                SqlDataAdapter DataAdapter = new SqlDataAdapter(cmd.CommandText, sqlConnection1);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(DataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                DataAdapter.Fill(table);
                //bindingSource1.DataSource = table;

                // Resize the DataGridView columns to fit the newly loaded content.
                //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();


        }
    }
}
