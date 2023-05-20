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
    public partial class menu_jefe_inventario : Form
    {
        public menu_jefe_inventario()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void menu_jefe_inventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {
                menu_jefe_inventario menu_jefe_inven = new menu_jefe_inventario();
                menu_jefe_inven.Close();
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
        private void menu_jefe_inventario_Load(object sender, EventArgs e)
        {
            label_usuario.Text = usuario;
            label_cargo.Text = cargo;
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            producto menu_producto = new producto();
            menu_producto.usuario = usuario;
            menu_producto.cargo = cargo;
            menu_producto.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Factura_Compra factura_compra = new Factura_Compra();
            factura_compra.usuario = usuario;
            factura_compra.cargo = cargo;
            factura_compra.Show();
            this.Hide();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cambio_de_clave cambio_clave = new Cambio_de_clave();
            cambio_clave.usuario = usuario;
            cambio_clave.cargo = cargo;
            cambio_clave.Show();
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
            MessageBox.Show("Observar Manual de Usuario pagina 66");
        }


    }
}
