using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiBodeguita.IUForm
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void registrartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRegProducto frm = new FormRegProducto(null);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMosProducto frm = new FormMosProducto();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
