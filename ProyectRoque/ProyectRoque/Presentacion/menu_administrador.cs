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
    public partial class menu_administrador : Form
    {
        public menu_administrador()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Empleados empleados = new Empleados();
            empleados.usuario = label_usuario.Text;
            empleados.cargo = label_cargo.Text;
            empleados.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Proveedores proveedor = new Proveedores();
            proveedor.usuario = usuario;
            proveedor.cargo = cargo;
            proveedor.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            cliente.usuario=usuario;
            cliente.cargo = cargo;
            cliente.Show();
            this.Hide();
        }
        public string cargo;
        public string usuario;
            
    
        private void menu_administrador_Load(object sender, EventArgs e)
        {
           
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
          
        }
       
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
       
        private void menu_administrador_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {
                menu_administrador menu_admi = new menu_administrador();
                menu_admi.Close();
                
            }
            else {
                if (dialog == DialogResult.Cancel)
                {
                    menu_administrador menu_admi = new menu_administrador();
                    label_cargo.Text = cargo;
                    label_usuario.Text = usuario;
                    e.Cancel = true;
                    
                }
                }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 65");
        }

        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            producto menu_producto = new producto();
            menu_producto.usuario = usuario;
            menu_producto.cargo = cargo;
            menu_producto.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Factura_venta factura_venta = new Factura_venta();
            factura_venta.usuario = usuario;
            factura_venta.cargo = cargo;
            factura_venta.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
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
    }
}
