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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu_administrador admin = new menu_administrador();
            admin.Show();
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
        public string cargo;
        public string usuario;

        private void Clientes_Load(object sender, EventArgs e)
        {
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            creacion_cliente crear_cliente = new creacion_cliente();
            crear_cliente.usuario = label_usuario.Text;
            crear_cliente.cargo = label_cargo.Text;
            crear_cliente.Show();
            this.Hide();
        }
      
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
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

        private void Clientes_FormClosing(object sender, FormClosingEventArgs e)
        {

            
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            
                if (dialog == DialogResult.Yes)
                {

                    Clientes clie = new Clientes();
                    clie.Close();                    
                }
                else
                {

                    if (dialog == DialogResult.No)
                    {

                        e.Cancel = true;

            
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            consulta_clientes consulta = new consulta_clientes();
            consulta.usuario = label_usuario.Text;
            consulta.cargo = label_cargo.Text;
            consulta.Show();
            this.Hide();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            actualizacion_cliente actualizar_cliente = new actualizacion_cliente();
            actualizar_cliente.usuario = label_usuario.Text;
            actualizar_cliente.cargo = label_cargo.Text;
            actualizar_cliente.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Eliminacion_cliente eliminar = new Eliminacion_cliente();
            eliminar.usuario = label_usuario.Text;
            eliminar.cargo = label_cargo.Text;
            eliminar.Show();
            this.Hide();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 84");
        }
    }
}
            
        
    