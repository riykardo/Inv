using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invt
{
    class Conexion
    {
        //propiedades privadas
        protected string sql = ConfigurationManager.ConnectionStrings["Invt.Properties.Settings.Conexion"].ToString();
        protected string tbl = "Usuarios";
        protected string sel;
        protected string ins;
        protected string upd;
        protected string del;
        protected bool err;
        protected string msg;
        protected int id;
        protected string nombre;
        protected string referencia;
        protected string selectTabla;
        protected ArrayList CamposTabla;
        //Constructores

        //public Base()
        //{
        //    this.declaracion();
        //}

        //public Base(int id)
        //{
        //    this.declaracion();
        //    this.Leer(id);
        //}
        //Propiedades Publicas
        public string Sql
        {
            get { return this.sql; }
        }
        public bool Err
        {
            get { return this.err; }
            set { this.err = value; }
        }
        public string Msg
        {
            get { return this.msg; }
            set { this.msg = value; }
        }
        public int Nro
        {
            get
            {
                DataSet oDataSet = new DataSet();
                SqlConnection oConexion = new SqlConnection(this.sql);
                SqlDataAdapter oAdaptador = new SqlDataAdapter("SELECT " +
               "COUNT(id) AS count " +
               "FROM " + this.tbl + ";", oConexion);
                oConexion.Open();
                oAdaptador.Fill(oDataSet, "usuarios");
                oConexion.Close();
                return (int)oDataSet.Tables["Usuarios"].Rows[0]["count"];
            }
        }
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public string Referencia
        {
            get { return this.referencia; }
            set { this.referencia = value; }
        }

        // Metodos Publicos

        public void Nuevo()

        {

            this.declaracion();

        }
        public void LeerTabal()
        {
            DataSet oDataSet = new DataSet();
            SqlConnection oConexion = new SqlConnection(this.sql);
            oConexion.Open();
            SqlDataAdapter oAdaptador = new SqlDataAdapter(this.selectTabla, oConexion);
            try
            {
                oAdaptador.Fill(oDataSet, tbl);
                oConexion.Close();
                this.campos(oDataSet, tbl);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Leer(int id)
        {
            DataSet oDataSet = new DataSet();
            SqlConnection oConexion = new SqlConnection(this.sql);
            oConexion.Open();
            SqlDataAdapter oAdaptador = new SqlDataAdapter(this.sel, oConexion);
            try
            {
                oAdaptador.Fill(oDataSet, "Usuarios");
                oConexion.Close();
                //this.campos(oDataSet);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Insertar()

        {

            SqlConnection oConexion = new SqlConnection(this.sql);

            SqlCommand oComando = new SqlCommand(this.ins, oConexion);

            // Parametros para insertar

            oComando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = this.nombre;

            oComando.Parameters.Add("@referencia", SqlDbType.NVarChar).Value = this.referencia;

            // parametro que devuelve el id

            oComando.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;

            // Ejecuta la insercion

            try

            {

                oConexion.Open();

                oComando.ExecuteScalar();

                this.id = (int)oComando.Parameters["@id"].Value;

                oConexion.Close();

            }

            catch // Si ocurre algun problema

            {

                this.err = true;

                this.msg = "Registro no pudo ser insertado.";

                return;

            }

            finally // Ejecuto la insersion

            {

                this.err = false;

                this.msg = "Registro insertado.";

            }

        }

        public void Actualizar()

        {

            SqlConnection oConexion = new SqlConnection(this.sql);

            SqlCommand oComando = new SqlCommand(this.upd, oConexion);

            // Parametros para actualizar

            oComando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = this.nombre;

            oComando.Parameters.Add("@referencia", SqlDbType.NVarChar).Value = this.referencia;

            try

            {

                oConexion.Open();

                oComando.ExecuteNonQuery();

                oConexion.Close();

            }

            catch

            {

                this.err = true;

                this.msg = "Registro no pudo ser actualizado.";

                return;

            }

            finally

            {

                this.err = false;

                this.msg = "Registro actualizado.";

            }

        }

        public void Eliminar()

        {

            SqlConnection oConexion = new SqlConnection(this.sql);

            SqlCommand oComando = new SqlCommand(this.ins, oConexion);

            oComando.Parameters.Add("@id", SqlDbType.Int).Value = this.id;

            try

            {

                oConexion.Open();

                oComando.ExecuteNonQuery();

                oConexion.Close();

                this.err = false;

                this.msg = "Registro eliminado.";

            }

            catch

            {

                this.err = true;

                this.msg = "Registro no pudo ser eliminado.";

            }

        }
       
        public DataTable Buscar(int cantidad, string campos, string filtro, string orden)
        {
            DataSet oDataSet = new DataSet();
            SqlConnection oConexion = new SqlConnection(this.sql);
            SqlDataAdapter oAdaptador = new SqlDataAdapter("SELECT " +
            (cantidad > 0 ? "TOP(" + cantidad.ToString("0") + ")" : "") + " " +
           (campos.Length > 0 ? campos : "*") + " " +
           "FROM " + this.tbl + " " +
           (filtro.Length > 0 ? "WHERE " + filtro : "") + " " +
           (orden.Length > 0 ? "ORDER BY " + orden : "") +
           ";", oConexion);
            oConexion.Open();
            oAdaptador.Fill(oDataSet, "Usuarios");
            oConexion.Close();
            return oDataSet.Tables["Usuarios"];
        }

        // Metodos Privados

        private void campos(DataSet oDataSet, string nomTabla)

        {

            if (oDataSet.Tables[nomTabla].Rows.Count != 0)
            {
                DataRow oRow = oDataSet.Tables[nomTabla].Rows[0];
                foreach (var item in oRow.Table.Select())
                {
                    CamposTabla.Add(item.ToString());
                }
              


                //this.id = (int)oRow["id"];

                //this.nombre = (string)oRow["nombre"];

                //this.referencia = (string)oRow["referencia"];

                //this.err = false;

                //this.msg = "Registro leido correctamente.";

            }

            else

            {

                this.err = true;

                this.msg = "No hay registro.";

            }

        }

        public void declaracion()
        {
            this.sql = ConfigurationManager.ConnectionStrings["Invt.Properties.Settings.Conexion"].ToString();
            this.selectTabla = "SELECT * FROM " + this.tbl;
            this.sel =
               "SELECT * " +
               "FROM " + this.tbl + " " +
               "WHERE(" +
               "id = @id);";
            this.ins =
               "INSERT INTO " + this.tbl + " (" +
               " nombre,  referencia) " +
               "VALUES(" +
               "@nombre, @referencia); " +
               "SELECT @id = SCOPE_IDENTITY() FROM " + this.tbl + ";";
            this.upd =
               "UPDATE " + this.tbl + " " +
               "SET " +
               "nombre = @nombre,     " +
               "referencia = @referencia " +
               "WHERE(" +
               "id = @id);";
            this.del =
               "DELETE FROM " + this.tbl + " " +
               "WHERE(" +
               "id = @id);";
            this.err = false;
            this.msg = "";
            this.id = 0;
            this.nombre = "";
            this.referencia = "";
            this.CamposTabla = new ArrayList();
        }
    }
}
