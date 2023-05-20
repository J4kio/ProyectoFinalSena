using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ProyectRoque.Presentacion
{
    public partial class Actualizar_proveedor : Form
    {
        public Actualizar_proveedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_np_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox_nombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox_direccion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox_correo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {

            Proveedores proveedor = new Proveedores();
            proveedor.usuario = label_usuario.Text;
            proveedor.cargo = label_cargo.Text;

            proveedor.Show();
            this.Hide();
        }
        public string usuario;
        public string cargo;
        private void Actualizar_proveedor_Load(object sender, EventArgs e)
        {

            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void Actualizar_proveedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {
                Actualizar_proveedor actualizar = new Actualizar_proveedor();
                actualizar.Close();
            }
            else if (dialog == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox_np.Text == "")
            {
                MessageBox.Show("Digite El Nombre Del Proveedor A Actualizar Antes De Continuar");


            }
            else
            {
                Negocios.Proveedor consulta_previa = new Negocios.Proveedor();
                dataGridView1.DataSource = consulta_previa.consulta_proveedor(textBox_np.Text);


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox_nombre.Text==""|| textBox_direccion.Text==""|| textBox_correo.Text==""){
                MessageBox.Show("Diligencie todos los campos antes de continuar.");
            }
            else{
            DialogResult dialog = MessageBox.Show("¿Desea guardar los cambios realizados?", "Confirmacion actualizacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // el resultado del cuadro de dialogo para luego evaluarlo en el if

            if (dialog == DialogResult.Yes)//si el usuario da clic en SI se realizara la actualizacion
            {
                Negocios.Proveedor actualizar = new Negocios.Proveedor();
                actualizar.actualizacion_proveedor(textBox1.Text, textBox_nombre.Text, textBox_direccion.Text, textBox_correo.Text);
                MessageBox.Show("Actualizacion Concluida");
            }
            else
            { // no le da en NO no se realizara la actualizacion
            }
        }
        }

        private void textBox_np_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //para no permitir que se ingresen numeros(solo letras)
            if (Char.IsLetter(e.KeyChar))
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
                    if (textBox_np.Text == "")
                    {
                        MessageBox.Show("Digite El Nombre Del Proveedor A Actualizar Antes De Continuar");


                    }
                    else
                    {
                        Negocios.Proveedor consulta_previa = new Negocios.Proveedor();
                        dataGridView1.DataSource = consulta_previa.consulta_proveedor(textBox_np.Text);


                    }
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

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 100-102");
        }

        private void textBox_correo_Leave(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(textBox_correo.Text);
            if (match.Success)
            {
                //No realiza acción por comparación
            }
            else
            {
                MessageBox.Show("No es una cuenta válida de correo electrónico", "Validación de cuentas Mail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.textBox_correo.Focus();
            }
        }
    }
}