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
    public partial class Eliminacion_producto : Form
    {
        public Eliminacion_producto()
        {
            InitializeComponent();
        }
        public string cargo;
        public string usuario;
        private void Eliminacion_producto_Load(object sender, EventArgs e)
        {
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            producto producto = new producto();
            producto.cargo = label_cargo.Text;
            producto.usuario = label_usuario.Text;
            producto.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            label5.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox1.Enabled == true || textBox2.Text == "" && textBox2.Enabled == true)
            {
                MessageBox.Show("Digite el dato a consultar antes de continuar.");
            }
            else if (radioButton1.Checked == true)
            {
                Negocios.Producto consulta_producto_cod = new Negocios.Producto();
                dataGridView1.DataSource = consulta_producto_cod.consulta_productos_codigo(textBox1.Text);

            }
            else
            {
                if (radioButton2.Checked == true)
                {
                    Negocios.Producto consulta_producto_nombre = new Negocios.Producto();
                    dataGridView1.DataSource = consulta_producto_nombre.consulta_producto_nombre(textBox2.Text);

                }
                else
                {
                    if (radioButton3.Checked == true)
                    {
                        string estado = "ACTIVO";
                        Negocios.Producto consulta_producto_estado = new Negocios.Producto();
                        dataGridView1.DataSource = consulta_producto_estado.consulta_producto_estado(estado);

                    }
                    else
                    {


                        if (radioButton4.Checked == true)
                        {
                            string estado = "INACTIVO";
                            Negocios.Producto consulta_producto_estado = new Negocios.Producto();
                            dataGridView1.DataSource = consulta_producto_estado.consulta_producto_estado(estado);

                        }
                        else
                        {
                            MessageBox.Show("Digite El Dato A Consultar");
                        }
                    }
                }
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton3.Checked == true){
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Enabled = true;
                textBox2.Enabled = false;

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Enabled = false;
                textBox2.Enabled = true;

            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Enabled = false;
                textBox2.Enabled = false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Seleccione Un Producto De La Tabla Antes De Continuar");

            }
            else {
                if (label4.Text == "" || label5.Text == "")
                {
                    MessageBox.Show("Seleccione Un Producto De La Tabla Antes De Continuar");

                }
                else
                {
                    
                    Negocios.Producto eliminacion = new Negocios.Producto();
                    eliminacion.eliminacion_producto(comboBox1.Text,label4.Text); 

                
                }
            }
        }

        private void Eliminacion_producto_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (dialog == DialogResult.Yes)
            {

                Eliminacion_producto cierre = new Eliminacion_producto();
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
            MessageBox.Show("Observar Manual de Usuario pagina 118-121");
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            //para no permitir que no se ingresen letras(solo numeros)
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
    }
}
