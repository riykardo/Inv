using Invt.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invt.Vista
{
    public partial class AgregaInventario : Form
    {
        private IUD IUD = new IUD();
        public AgregaInventario()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArticulosBO articulo = new ArticulosBO();
            articulo.Codigo = this.textBox1.Text;
            articulo.Nombre = this.textBox2.Text;
            articulo.Descripcion = this.textBox3.Text;
            try
            {
                Control.ArticulosControl.ArticuloInsertar(articulo);
                MessageBox.Show("Se agrego el articulo correctamente");
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            IUD.Show();
        }
    }
}
