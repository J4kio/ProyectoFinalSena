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
    public partial class Actualizar_producto : Form
    {
        public Actualizar_producto()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox_precio_unitario_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox_codigo_proveedor_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox_iva_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox_precio_venta_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

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
                        string x = "";//para mandar algo a la clase
                        Negocios.Producto consulta_producto_general = new Negocios.Producto();
                        dataGridView1.DataSource = consulta_producto_general.consulta_producto_general(x);

                    }
                    else
                    {
                        MessageBox.Show("Digite El Dato A Consultar");
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Negocios.Producto consulta_imagen = new Negocios.Producto();
            byte[] imagen = consulta_imagen.imagen_producto(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            MemoryStream buffer = new MemoryStream(imagen);

            pictureBox2.Image = Image.FromStream(buffer);
            pictureBox2.Visible = true;

            textBox_codigo_producto.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox_cantidad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox_nombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox_precio_venta.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox_iva.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            
            textBox_codigo_proveedor.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox_precio_unitario.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();


            tabControl1.SelectedTab = tabPage2;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox_codigo_producto.Text == "" || textBox_nombre.Text == "" || textBox_cantidad.Text == "" || textBox_precio_venta.Text == "" || textBox_iva.Text == "" || textBox_codigo_proveedor.Text == "" || comboBox1.Text == "" || textBox_precio_unitario.Text == "")
            {
                MessageBox.Show("Diligencie todos los campos antes de continuar.");
            }
            else
            {
                MemoryStream memoria = new MemoryStream();  //Crea un objeto Stream como Buffer (Datos en un espacio de memoria)
                pictureBox2.Image.Save(memoria, System.Drawing.Imaging.ImageFormat.Jpeg); //Almacena la imagen en el Buffer
                byte[] memoria_imagen = memoria.ToArray();  //Se extrae la cadena para almacenarla en una variable tipo binario

                Negocios.Producto actualizar_producto = new Negocios.Producto();
                actualizar_producto.Actualizar_producto(textBox_codigo_producto.Text, textBox_nombre.Text, textBox_cantidad.Text, textBox_precio_venta.Text, textBox_iva.Text, textBox_codigo_proveedor.Text, comboBox1.Text, memoria_imagen, textBox_precio_unitario.Text);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Desea Cancelar La Actualizacion De Productos?", "Cancelar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                textBox_codigo_producto.Clear();
                textBox_cantidad.Clear();
                textBox_nombre.Clear();
                textBox_precio_venta.Clear();
                textBox_iva.Clear();
                
                textBox_codigo_proveedor.Clear();
                // comboBox1.Items.Clear();//para limpiar el comboBox
                pictureBox2.Image = null;//para limpiar el picturebox
                DataTable dt = (DataTable)dataGridView1.DataSource;// para limpoiar el datagrid view
                dt.Clear();
                tabControl1.SelectedTab = tabPage1;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog(); //Se crea el nuevo objeto cuadro de dialogo
            DialogResult resultado = dialogo.ShowDialog(); //Se muestra esperando una acción del usuario
            if (resultado == DialogResult.OK) //Si selecciona un archivo, se muestra en el ptb1
            {
                pictureBox2.Image = Image.FromFile(dialogo.FileName);
            }
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
        public string cargo;
        public string usuario;
        private void Actualizar_producto_Load(object sender, EventArgs e)
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

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            producto producto = new producto();
            producto.cargo = label_cargo.Text;
            producto.usuario = label_usuario.Text;
            producto.Show();
            this.Hide();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
            }
        }

        private void Actualizar_producto_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {
                Actualizar_producto actualizar = new Actualizar_producto();
                actualizar.Close();


            }
            else
            {
                if (dialog == DialogResult.Cancel)
                {
                    menu_administrador menu_admi = new menu_administrador();
                    label_usuario.Text = usuario;
                    label_cargo.Text = cargo;
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

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 113-117");
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 113-117");
        }
    }
}
