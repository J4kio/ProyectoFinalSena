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
    public partial class Factura_venta : Form
    {
        public Factura_venta()
        {
            InitializeComponent();
        }
        public string cargo;
        public string usuario;
        private void Factura_venta_Load(object sender, EventArgs e)
        {
           
        
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (label_cargo.Text == "Administrador")
            {
                menu_administrador menu_admin = new menu_administrador();
                menu_admin.cargo = label_cargo.Text;
                menu_admin.usuario = label_usuario.Text;
                menu_admin.Show();
                this.Hide();
            }
            else
            {
                if (label_cargo.Text == "Cajero")
                {
                    menu_cajero menu_cajero = new menu_cajero();
                    menu_cajero.cargo = label_cargo.Text;
                    menu_cajero.usuario = label_usuario.Text;
                    menu_cajero.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Se a presentado un error contacte con soporte tecnico");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            creacion_factura_venta factura_venta = new creacion_factura_venta();
            factura_venta.usuario = usuario;
            factura_venta.cargo = cargo;
            factura_venta.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            consulta_facturas_venta factura_venta = new consulta_facturas_venta();
            factura_venta.usuario = usuario;
            factura_venta.cargo = cargo;
            factura_venta.Show();
            this.Hide();
        }

        private void Factura_venta_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (dialog == DialogResult.Yes)
            {

               Factura_venta cierre = new Factura_venta();
                cierre.Close();
            }
            else
            {

                if (dialog == DialogResult.No)
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

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 134");
        }
    }
}
