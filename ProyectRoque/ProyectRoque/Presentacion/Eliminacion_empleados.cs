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
    public partial class Eliminacion_empleados : Form
    {
        public Eliminacion_empleados()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ACTIVO" || comboBox1.Text == "INACTIVO") {
                Negocios.Empleado consulta_empleado_estado = new Negocios.Empleado();
                dataGridView1.DataSource = consulta_empleado_estado.consulta_empleado_estado(comboBox1.Text);
            
            }
            else{
                if (comboBox1.Text == "Todos Los Empleados")
                {
                    Negocios.Empleado consulta_general = new Negocios.Empleado();
                    dataGridView1.DataSource= consulta_general.consulta_general_empleado(comboBox1.Text);
                }
            }
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empleados empleado = new Empleados();
            empleado.cargo = label_cargo.Text;
            empleado.usuario = label_usuario.Text;
            empleado.Show();
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void Eliminacion_empleados_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {
                Eliminacion_empleados eliminacion = new Eliminacion_empleados();
                eliminacion.Close();
            }
            else if (dialog == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_usuario.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox_cedula.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox_nombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox_cargo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox_direccion.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox_correo.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox_observaciones.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            comboBox_estado.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Desea guardar los cambios realizados?", "Confirmacion actualizacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // el resultado del cuadro de dialogo para luego evaluarlo en el if

            if (dialog == DialogResult.Yes)//si el usuario da clic en SI se realizara la actualizacion
            {
                Negocios.Empleado eliminacion_empleado = new Negocios.Empleado();
                eliminacion_empleado.eliminacion_empleado(comboBox_estado.Text,textBox_cedula.Text);
                MessageBox.Show("Actualizacion Concluida");
            }
            else
            { // no le da en NO no se realizara la actualizacion
            }
        }

        private void comboBox_estado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public string usuario;
        public string cargo;
        private void Eliminacion_empleados_Load(object sender, EventArgs e)
        {
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 82-83");
        }
    }
}
