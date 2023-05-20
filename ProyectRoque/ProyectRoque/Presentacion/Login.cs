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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Los Campos No Deben Estar Vacios, reintente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Negocios.Clase_login datos = new Negocios.Clase_login();
                datos.Login(textBox1.Text, textBox2.Text, comboBox1.Text);
                this.Hide();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("Los Campos No Deben Estar Vacios, reintente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Negocios.Clase_login datos = new Negocios.Clase_login();
                    datos.Login(textBox1.Text, textBox2.Text, comboBox1.Text);
                    this.Hide();
                }

            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {
                Login Log = new Login();
                Log.Close();
                
            }
            else if (dialog == DialogResult.Cancel)
            {
                
                e.Cancel = true;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;// si el checkbox esta chequeado se desactiva la propiedad UseSystemPasswordChar que es para que se use una viñeta como caracter
              

            }
            else
            {
                textBox2.UseSystemPasswordChar = true;// si el checkbox no esta chequeado se activa la propiedad UseSystemPasswordChar y el texto saldra todo en viñetas
                
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Recuperacion_clave recuperacion = new Recuperacion_clave();
            recuperacion.Show();
            this.Hide();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 62-64");
        }
    }
}
