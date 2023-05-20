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
    public partial class producto : Form
    {
        public producto()
        {
            InitializeComponent();
        }
        public string cargo;
        public string usuario;
        private void producto_Load(object sender, EventArgs e)
        {
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            creacion_producto creacion_productos = new creacion_producto();
            creacion_productos.cargo = label_cargo.Text;
            creacion_productos.usuario = label_usuario.Text;
            creacion_productos.Show();
            this.Hide();
        
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

        private void button2_Click(object sender, EventArgs e)
        {
            Negocios.consulta_producto consulta_productos = new Negocios.consulta_producto();
            consulta_productos.cargo = label_cargo.Text;
            consulta_productos.usuario = label_usuario.Text;
            consulta_productos.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Actualizar_producto actualizar = new Actualizar_producto();
            actualizar.cargo = label_cargo.Text;
            actualizar.usuario = label_usuario.Text;
            actualizar.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Eliminacion_producto eliminar = new Eliminacion_producto();
            eliminar.cargo = label_cargo.Text;
            eliminar.usuario = label_usuario.Text;
            eliminar.Show();
            this.Hide();
        }

        private void producto_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (dialog == DialogResult.Yes)
            {

               producto cierre = new producto();
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
            MessageBox.Show("Observar Manual de Usuario pagina 106");
        }
       
    }
}
