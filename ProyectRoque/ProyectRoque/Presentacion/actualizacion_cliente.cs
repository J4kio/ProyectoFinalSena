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
    public partial class actualizacion_cliente : Form
    {
        public actualizacion_cliente()
        {
            InitializeComponent();
        }

        private void textBox_nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_cargo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_nc.Text == "")
            {
                MessageBox.Show("Digite El Nombre Del Cliente A Actualizar Antes De Continuar");


            }
            else
            {

                Negocios.clientes consulta_cliente_nombre = new Negocios.clientes();
                dataGridView1.DataSource = consulta_cliente_nombre.consulta_cliente_nombre(textBox_nc.Text);

            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            cliente.usuario = label_usuario.Text;
            cliente.cargo = label_cargo.Text;
            cliente.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox_nombre.Text == "" || textBox_telefono.Text == "" || textBox_direccion.Text == "")
            {
                MessageBox.Show("Los campos no deben estar vacios");
            }
            else
            {
                DialogResult dialog = MessageBox.Show("¿Desea guardar los cambios realizados?", "Confirmacion actualizacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // el resultado del cuadro de dialogo para luego evaluarlo en el if

                if (dialog == DialogResult.Yes)//si el usuario da clic en SI se realizara la actualizacion
                {
                    Negocios.clientes actualizacion = new Negocios.clientes();
                    actualizacion.actualizar_cliente(textBox_nombre.Text, textBox_cedula.Text, textBox_direccion.Text, textBox_telefono.Text);

                }
                else
                { // no le da en NO no se realizara la actualizacion
                }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_cedula.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox_nombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox_direccion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox_telefono.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

        }

        private void textBox_nombre_KeyPress(object sender, KeyPressEventArgs e)
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
        private void textBox_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {

            //para no permitir que se ingresen letras(solo numeros)
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            else
            {
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
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

        private void textBox_nc_KeyPress(object sender, KeyPressEventArgs e)
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
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void actualizacion_cliente_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {
                actualizacion_cliente actualizacion_cliente = new actualizacion_cliente();
                actualizacion_cliente.Close();
            }
            else if (dialog == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
        public string usuario;
        public string cargo;
        private void actualizacion_cliente_Load(object sender, EventArgs e)
        {
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
        }

        private void textBox_nombre_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 89-91");
        }
    }
}