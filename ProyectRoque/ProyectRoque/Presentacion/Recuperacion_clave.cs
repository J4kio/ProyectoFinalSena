using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectRoque.Presentacion
{
    public partial class Recuperacion_clave : Form
    {
        public Recuperacion_clave()
        {
            InitializeComponent();
        }

        private void Recuperacion_clave_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {
                Recuperacion_clave recuperacion = new Recuperacion_clave();
                recuperacion.Close();

            }
            else
            {
                if (dialog == DialogResult.Cancel)
                {

                    e.Cancel = true;

                }
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Negocios.Empleado restauracion = new Negocios.Empleado();
            restauracion.restauracion_clave(textBox1.Text);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Negocios.Empleado restauracion = new Negocios.Empleado();
                restauracion.restauracion_clave(textBox1.Text);
            }
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 63-64");
        }
    }
}
