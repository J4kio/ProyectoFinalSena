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
    public partial class Empleados : Form
    {
        public Empleados()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            creacion_empleado Empleado = new creacion_empleado();
            Empleado.usuario = usuario;
            Empleado.cargo = cargo;
            Empleado.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            consulta_empleados consulta_empleado = new consulta_empleados();
           
            consulta_empleado.usuario = label_usuario.Text;
            consulta_empleado.cargo = label_cargo.Text;
            consulta_empleado.Show();
            this.Hide();
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu_administrador admin = new menu_administrador();
            admin.cargo = label_cargo.Text;
            admin.usuario = label_usuario.Text;
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

        public void Empleados_Load(object sender, EventArgs e)
        {
            label_usuario.Text = usuario;
            label_cargo.Text = cargo;
        }

        private void Empleados_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {
                Empleados Emple = new Empleados();
                Emple.Close();
            }
            else if (dialog == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            actualizacion_empleado actualizacion = new actualizacion_empleado();
            actualizacion.usuario = label_usuario.Text;
            actualizacion.cargo = label_cargo.Text;
            actualizacion.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Eliminacion_empleados eliminacion_empleados = new Eliminacion_empleados();
            eliminacion_empleados.usuario = label_usuario.Text;
            eliminacion_empleados.cargo = label_cargo.Text;
            eliminacion_empleados.Show();
            this.Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 67");
        }
    }
}
