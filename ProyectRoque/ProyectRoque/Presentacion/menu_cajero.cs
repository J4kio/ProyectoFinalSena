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
    public partial class menu_cajero : Form
    {
        public menu_cajero()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public string cargo;
        public string usuario;
        
        private void menu_cajero_Load(object sender, EventArgs e)
        {
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            cliente.usuario = label_usuario.Text;
            cliente.cargo = label_cargo.Text;
            cliente.Show();
            this.Hide();
        }

        private void menu_cajero_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {
                menu_cajero menu_caje = new menu_cajero();
                menu_caje.Close();
            }
            else if (dialog == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
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
            Factura_venta factura_venta = new Factura_venta();
            factura_venta.usuario = usuario;
            factura_venta.cargo = cargo;
            factura_venta.Show();
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
            MessageBox.Show("Observar Manual de Usuario pagina 65");
        }
    }
}
