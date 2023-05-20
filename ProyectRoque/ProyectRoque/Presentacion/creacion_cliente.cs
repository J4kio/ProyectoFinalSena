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
    public partial class creacion_cliente : Form
    {
        public creacion_cliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_nombre.Text == "" || textBox_cedula.Text == "" || textBox_direccion.Text == "" || textBox_telefono.Text == "")
            {

                MessageBox.Show("Los Campos No Deben Estar Vacios, reintente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Negocios.clientes cliente = new Negocios.clientes();
                cliente.creacion_cliente(textBox_nombre.Text, textBox_cedula.Text, textBox_direccion.Text, textBox_telefono.Text, label_usuario.Text);


                textBox_nombre.Clear();
                textBox_cedula.Clear();
                textBox_direccion.Clear();
                textBox_telefono.Clear();
            }
        }
        public string cargo;
        public string usuario;
        private void creacion_cliente_Load(object sender, EventArgs e)
        {
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;


        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            cliente.usuario = label_usuario.Text;
            cliente.cargo = label_cargo.Text;
            cliente.Show();
            this.Hide();
        }

        private void creacion_cliente_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {
                creacion_cliente Creacion_C = new creacion_cliente();
                Creacion_C.Close();
            }
            else if (dialog == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void textBox_telefono_TextChanged(object sender, EventArgs e)
        {

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
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        if (textBox_nombre.Text == "" || textBox_cedula.Text == "" || textBox_direccion.Text == "" || textBox_telefono.Text == "")
                        {

                            MessageBox.Show("Los Campos No Deben Estar Vacios, reintente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {
                            Negocios.clientes cliente = new Negocios.clientes();
                            cliente.creacion_cliente(textBox_nombre.Text, textBox_cedula.Text, textBox_direccion.Text, textBox_telefono.Text,label_usuario.Text);


                        }

                    }
                }
        }

        private void textBox_nombre_TextChanged(object sender, EventArgs e)
        {

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

        private void textBox_cedula_KeyPress(object sender, KeyPressEventArgs e)
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

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void textBox_cedula_Leave(object sender, EventArgs e)
        {
            try
            {
                Negocios.clientes validar = new Negocios.clientes();
                string resultado = validar.validacion_cedula_cliente(textBox_cedula.Text);
                if (resultado == "false")
                {
                    MessageBox.Show("La cedula del cliete ya existe digite una diferente antes de continuar.");
                    this.textBox_cedula.Focus();

                }
                else if (resultado == "true")
                {
                    //no existe y se puede agregar una cedula nueva


                }
            }
            catch(Exception){
            
            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            cliente.usuario = label_usuario.Text;
            cliente.cargo = label_cargo.Text;
            cliente.Show();
            this.Hide();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 85-86");
        }

    }
}

