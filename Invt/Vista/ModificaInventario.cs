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
    public partial class ModificaInventario : Form
    {
        public ModificaInventario()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            ArticulosBO articulo = new ArticulosBO();
            Control.ArticulosControl.ArticulosLeer();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
