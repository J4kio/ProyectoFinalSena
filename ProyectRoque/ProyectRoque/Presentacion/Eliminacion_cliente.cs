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
    public partial class Eliminacion_cliente : Form
    {
        public Eliminacion_cliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

                Negocios.clientes consulta_general = new Negocios.clientes();
                dataGridView1.DataSource = consulta_general.consulta_cliente_general(textBox1.Text);
            }
            else
            {
                Negocios.clientes consulta = new Negocios.clientes();
                dataGridView1.DataSource = consulta.consulta_cliente_nombre(textBox1.Text);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_cedula.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox_nombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox_direccion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox_estado.Text= dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Desea guardar los cambios realizados?", "Confirmacion actualizacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // el resultado del cuadro de dialogo para luego evaluarlo en el if

            if (dialog == DialogResult.Yes)//si el usuario da clic en SI se realizara la actualizacion
            {
                Negocios.clientes eliminacion = new Negocios.clientes();
                eliminacion.eliminacion_cliente(comboBox_estado.Text, textBox_cedula.Text);
                MessageBox.Show("Actualizacion Concluida");
            }
            else
            { // no le da en NO no se realizara la actualizacion
            }
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            cliente.usuario = label_usuario.Text;
            cliente.cargo = label_cargo.Text;
            cliente.Show();
            this.Hide();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
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
            
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {

                    if (textBox1.Text == "")
                    {

                        Negocios.clientes consulta_general = new Negocios.clientes();
                        dataGridView1.DataSource = consulta_general.consulta_cliente_general(textBox1.Text);
                    }
                    else
                    {
                        Negocios.clientes consulta = new Negocios.clientes();
                        dataGridView1.DataSource = consulta.consulta_cliente_nombre(textBox1.Text);
                    }
                }
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Eliminacion_cliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {
                consulta_empleados Consulta_E = new consulta_empleados();
                Consulta_E.Close();
            }
            else
            {

                if (dialog == DialogResult.Cancel)
                {
                    e.Cancel = true;


                }
            }
        }
        public string usuario;
        public string cargo;
        private void Eliminacion_cliente_Load(object sender, EventArgs e)
        {
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 91-93");
        }
    }
}
