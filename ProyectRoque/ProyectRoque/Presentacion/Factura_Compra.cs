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
    public partial class Factura_Compra : Form
    {
        public Factura_Compra()
        {
            InitializeComponent();
        }
        public string cargo;
        public string usuario;
        private void Factura_Compra_Load(object sender, EventArgs e)
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
                if (label_cargo.Text == "Jefe De Inventario")
                {
                    menu_jefe_inventario menu_ji = new menu_jefe_inventario();
                    menu_ji.cargo = label_cargo.Text;
                    menu_ji.usuario = label_usuario.Text;
                    menu_ji.Show();
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
            creacion_factura_compra factura_compra = new creacion_factura_compra();
            factura_compra.usuario = usuario;
            factura_compra.cargo = cargo;
            factura_compra.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            consulta_factura_compra factura_compra = new consulta_factura_compra();
            factura_compra.usuario = usuario;
            factura_compra.cargo = cargo;
            factura_compra.Show();
            this.Hide();
        }

        private void Factura_Compra_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (dialog == DialogResult.Yes)
            {

                Factura_Compra cierre = new Factura_Compra();
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
            MessageBox.Show("Observar Manual de Usuario pagina 122");
        }
    }
}
