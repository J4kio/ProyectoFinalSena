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
    public partial class Eliminacion_proveedores : Form
    {
        public Eliminacion_proveedores()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

                MessageBox.Show("Digite el nombre del proveedor a consultar");
            }
            else
            {
                Negocios.Proveedor consulta_proveedor = new Negocios.Proveedor();
                dataGridView1.DataSource = consulta_proveedor.consulta_proveedor(textBox1.Text);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            
            textBox_nombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox_direccion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox_correo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
        public string usuario;
        public string cargo;
        private void Eliminacion_proveedores_Load(object sender, EventArgs e)
        {
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Proveedores proveedor = new Proveedores();
            proveedor.usuario = label_usuario.Text;
            proveedor.cargo = label_cargo.Text;
            proveedor.Show();
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void Eliminacion_proveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {
                Eliminacion_proveedores eliminar = new Eliminacion_proveedores();
                eliminar.Close();

            }
            else if (dialog == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
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
                Negocios.Proveedor eliminacion = new Negocios.Proveedor();
                eliminacion.eliminacion_proveedor(comboBox1.Text,textBox2.Text);
                MessageBox.Show("Actualizacion Concluida");
            }
            else
            { // no le da en NO no se realizara la actualizacion
            }
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 103-105");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //para no permitir que se ingresen numeros(solo letras)
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }

            else
            {
                if (Char.IsControl(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                }
            }
        }
    }
}

