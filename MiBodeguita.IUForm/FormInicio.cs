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
            frm.Text = "Registrar Producto";
            AbrirFormulario(frm);
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMosProducto frm = new FormMosProducto();
            frm.Text = "Mostrar Producto";
            AbrirFormulario(frm);
        }

        private void toolStripMenuItemRegistras_Click(object sender, EventArgs e)
        {
            FormCompra frm = new FormCompra();
            AbrirFormulario(frm);
        }

        private void toolStripMenuItemMostrar_Click(object sender, EventArgs e)
        {
            FormMosCompras frm = new FormMosCompras();
            AbrirFormulario(frm);
        }

        private void AbrirFormulario(Form frm)
        {
            var Formulario = this.MdiChildren.Where(x => x.Name == frm.Name &&
                                                    x.Text == frm.Text).FirstOrDefault();
            if (Formulario == null)
            {
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                Formulario.BringToFront();
            }
        }
    }
}
