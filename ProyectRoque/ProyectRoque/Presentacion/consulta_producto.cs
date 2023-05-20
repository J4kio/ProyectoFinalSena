using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO; //Nueva libreria a adicionar para permitir crear objetos MemoryStream

namespace ProyectRoque.Negocios
{
    public partial class consulta_producto : Form
    {
        public consulta_producto()
        {
            InitializeComponent();
        }
        public string cargo;
        public string usuario;
        private void consulta_producto_Load(object sender, EventArgs e)
        {
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && radioButton1.Checked == true || textBox2.Text == "" && radioButton2.Checked == true)
            {
                MessageBox.Show("Digite el dato antes de continuar.");
            }
            else
            {

                if (radioButton1.Checked == true)
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
                            string x = "";//para mandar algo a la clase
                            Negocios.Producto consulta_producto_general = new Negocios.Producto();
                            dataGridView1.DataSource = consulta_producto_general.consulta_producto_general(x);

                        }
                        else
                        {
                            MessageBox.Show("Digite El Dato A Consultar.");
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Negocios.Producto consulta_imagen = new Negocios.Producto();
            byte[] imagen = consulta_imagen.imagen_producto(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            MemoryStream buffer = new MemoryStream(imagen);
            
            pictureBox1.Image = Image.FromStream(buffer);
            pictureBox1.Visible = true;
           
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox2.Clear();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox1.Clear();
            textBox2.Enabled = false;
            textBox2.Clear();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
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

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.producto producto = new Presentacion.producto();
            producto.cargo = label_cargo.Text;
            producto.usuario = label_usuario.Text;
            producto.Show();
            this.Hide();
        }

        private void consulta_producto_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (dialog == DialogResult.Yes)
            {

                consulta_producto cierre = new consulta_producto();
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
            Presentacion.Login log = new Presentacion.Login();
            log.Show();
            this.Hide();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 111-112");
        }
    }
}
