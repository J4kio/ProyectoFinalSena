using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO; //Nueva libreria a adicionar para permitir crear objetos MemoryStream

namespace ProyectRoque.Presentacion
{
    public partial class creacion_producto : Form
    {
        public creacion_producto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            OpenFileDialog dialogo = new OpenFileDialog(); //Se crea el nuevo objeto cuadro de dialogo
            DialogResult resultado = dialogo.ShowDialog(); //Se muestra esperando una acción del usuario
            if (resultado == DialogResult.OK) //Si selecciona un archivo, se muestra en el ptb1
            {
               pictureBox1.Image = Image.FromFile(dialogo.FileName);
            }
                

          
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            MemoryStream memoria = new MemoryStream();  //Crea un objeto Stream como Buffer (Datos en un espacio de memoria)
            pictureBox1.Image.Save(memoria, System.Drawing.Imaging.ImageFormat.Jpeg); //Almacena la imagen en el Buffer
            byte[] memoria_imagen = memoria.ToArray();  //Se extrae la cadena para almacenarla en una variable tipo binario


            if (textBox_codigo_producto.Text == "" || textBox_nombre.Text == "" || textBox_cantidad.Text == "" || textBox_precio_venta.Text == "" || textBox_iva.Text == "" ||textBox_codigo_proveedor.Text == "" || comboBox1.Text == "" || textBox_precio_unitario.Text =="")
            {
                MessageBox.Show("Diligencie todos los campos antes de continuar.");
            }

            else
            {

                Negocios.Producto crear_producto = new Negocios.Producto();
                crear_producto.agregar_producto(textBox_codigo_producto.Text, textBox_nombre.Text, textBox_cantidad.Text, textBox_precio_venta.Text, textBox_iva.Text, textBox_codigo_proveedor.Text, comboBox1.Text, memoria_imagen,textBox_precio_unitario.Text);
                //textBox_codigo_producto.Clear();
                //textBox_cantidad.Clear();
                //textBox_nombre.Clear();
                //textBox_precio_venta.Clear();
                //textBox_precio_unitario.Clear();
                //textBox_iva.Clear();
                producto producto = new producto();
                producto.cargo = label_cargo.Text;
                producto.usuario = label_usuario.Text;
                producto.Show();
                this.Hide();
            }
        }

        private void textBox_iva_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox_precio_de_compra_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox_codigo_proveedor_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox_precio_venta_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox_cantidad_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox_codigo_producto_KeyPress(object sender, KeyPressEventArgs e)
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
        public string cargo;
        public string usuario;
        private void creacion_producto_Load(object sender, EventArgs e)
        {
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
            //Llenado de un ComboBox
            comboBox2.ValueMember = "Nombre";  //Nombre de la columna de la tabla a consultar
           
            Negocios.Producto nn = new Negocios.Producto();
             comboBox2.DataSource= nn.consulta_proveedor();
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            producto producto = new producto();
            producto.cargo = label_cargo.Text;
            producto.usuario = label_usuario.Text;
            producto.Show();
            this.Hide();
        }

        private void textBox_precio_unitario_KeyPress(object sender, KeyPressEventArgs e)
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

        private void creacion_producto_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (dialog == DialogResult.Yes)
            {

                creacion_producto cierre = new creacion_producto();
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Negocios.Producto nn = new Negocios.Producto();
            textBox_codigo_proveedor.Text= nn.consulta_cod_proveedor(comboBox2.Text);
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 107-110");
        }

    }
}
