﻿using Invt.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invt
{
    public partial class IUD : Form
    {
        public IUD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregaInventario add = new AgregaInventario();
            add.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModificaInventario modifica = new ModificaInventario();
            modifica.Show();
            this.Close();
        }
    }
}
