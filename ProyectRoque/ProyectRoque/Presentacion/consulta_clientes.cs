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
    public partial class consulta_clientes : Form
    {
        public consulta_clientes()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            cliente.usuario = label_usuario.Text;
            cliente.cargo = label_cargo.Text;
            cliente.Show();
            this.Hide();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox1.Visible == true || textBox2.Visible== true && textBox2.Text=="")
            {
                MessageBox.Show("Digite El Dato Del Cliente A Consultar");
            }
            else
            {
                if (radioButton1.Checked == true)
                {
                    Negocios.clientes consulta_cliente_cedula = new Negocios.clientes();
                    dataGridView1.DataSource = consulta_cliente_cedula.consulta_cliente_cedula(textBox1.Text);
                }

                else
                {
                    if (radioButton3.Checked == true)
                    {
                        Negocios.clientes consulta_cliente_nombre = new Negocios.clientes();
                        dataGridView1.DataSource = consulta_cliente_nombre.consulta_cliente_nombre(textBox2.Text);

                    }
                    else
                    {
                        if (radioButton2.Checked == true)
                        {
                            Negocios.clientes consulta_general_cliente = new Negocios.clientes();
                            dataGridView1.DataSource = consulta_general_cliente.consulta_cliente_general(textBox1.Text);

                        }
                    }
                }
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox1.Clear();
            textBox2.Clear();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox1.Clear();
            textBox2.Clear();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox2.Visible = true;
            textBox1.Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (radioButton1.Checked == true)
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

                        if (textBox1.Text == "" && textBox1.Visible == true)
                        {
                            MessageBox.Show("Digite El Dato Del Cliente A Consultar");
                        }
                        else
                        {
                            if (radioButton1.Checked == true)
                            {

                                Negocios.clientes consulta_cliente_cedula = new Negocios.clientes();
                                dataGridView1.DataSource = consulta_cliente_cedula.consulta_cliente_cedula(textBox1.Text);
                            }


                        }

                    }

                }
            }
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
               
                if (radioButton2.Checked == true)
                {
                    Negocios.clientes consulta_general_cliente = new Negocios.clientes();
                    dataGridView1.DataSource = consulta_general_cliente.consulta_cliente_general(textBox1.Text);

                }
            }
        }
        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {




        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
        public string usuario;
        public string cargo;
        private void consulta_clientes_Load(object sender, EventArgs e)
        {
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
        }

        private void consulta_clientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (dialog == DialogResult.Yes)
            {

               consulta_clientes clie = new consulta_clientes();
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

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 87-88");
        }
    }
}