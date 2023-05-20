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
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            creacion_proveedor crear_proveedor = new creacion_proveedor();
            crear_proveedor.usuario = label_usuario.Text;
            crear_proveedor.cargo = label_cargo.Text;
            crear_proveedor.Show();
            this.Hide();
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                menu_administrador menu_admin = new menu_administrador();
                menu_admin.usuario = label_usuario.Text;
                menu_admin.cargo = label_cargo.Text;
                menu_admin.Show();
                this.Hide();
                                 
           
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            consulta_proveedores cp = new consulta_proveedores();
            cp.usuario = label_usuario.Text;
            cp.cargo = label_cargo.Text;
            cp.Show();
            this.Hide();
        }

        private void Proveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {
                Proveedores provee = new Proveedores();
                provee.Close();
            }
            else if (dialog == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        public string cargo;
        public string usuario;
        private void Proveedores_Load(object sender, EventArgs e)
        {
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Actualizar_proveedor actualizar = new Actualizar_proveedor();
            actualizar.usuario = label_usuario.Text;
            actualizar.cargo = label_cargo.Text;
            actualizar.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Eliminacion_proveedores eliminar = new Eliminacion_proveedores();
            eliminar.usuario = label_usuario.Text;
            eliminar.cargo = label_cargo.Text;
            eliminar.Show();
            this.Hide();
        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 84");
        }
    }
}
