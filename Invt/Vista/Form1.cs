using Invt.Model;
using Invt.Vista;
using System;
using System.Collections;
using System.Windows.Forms;


namespace Invt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        IUD iUD = new IUD();

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = this.textBox1.Text.ToString();
            string password = this.textBox2.Text.ToString();
            Hashtable ht = new Hashtable();
            Conexion conexion = new Conexion();
            //conexion.declaracion();
            //conexion.LeerTabal();
            //conexion.Leer(1);

            ht.Add("usuarios", "usuarios");
            ArrayList recupera = Control.UsuariosControl.UsuariosRecuperar(ht);
            foreach (UsuariosBO item in recupera)
            {
                if(item.Nombre == usuario && item.password == password)
                {
                    iUD.Show();
                    this.Hide();
                    break;
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña no valido");
                    break;
                }

            }

            //UsuariosBO Usuarios = conexion.Usuarios;
        }
    }
}
