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
    public partial class Cambio_de_clave : Form
    {
        public Cambio_de_clave()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Los campos no deben estar vacios.", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                if (textBox2.Text == textBox3.Text)
                {
                    Negocios.Empleado consulta = new Negocios.Empleado();
                    consulta.cambio_clave(label_usuario.Text, textBox1.Text, textBox3.Text);

                }
                else
                {
                    MessageBox.Show("Las Contraseñas No Coinciden");
                }
            }

        }
        public string cargo;
        public string usuario;
        private void Cambio_de_clave_Load(object sender, EventArgs e)
        {
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (label_cargo.Text == "Administrador")
            {
                menu_administrador menu_admin = new menu_administrador();
                menu_admin.cargo = label_cargo.Text;
                menu_admin.usuario = label_usuario.Text;
                menu_admin.Show();
                this.Hide();
            }
            else
            {

                if (label_cargo.Text == "Jefe De Inventario")
                {
                    menu_jefe_inventario menu_ji = new menu_jefe_inventario();
                    menu_ji.cargo = label_cargo.Text;
                    menu_ji.usuario = label_usuario.Text;
                    menu_ji.Show();
                    this.Hide();
                }
                else
                {
                    if (label_cargo.Text == "Cajero")
                    {
                        menu_cajero menu_cajero = new menu_cajero();
                        menu_cajero.cargo = label_cargo.Text;
                        menu_cajero.usuario = label_usuario.Text;
                        menu_cajero.Show();
                        this.Hide();
                    }



                    else
                    {
                        MessageBox.Show("Se a presentado un error contacte con soporte tecnico");

                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label_cargo.Text == "Administrador")
            {
                menu_administrador menu_admin = new menu_administrador();
                menu_admin.cargo = label_cargo.Text;
                menu_admin.usuario = label_usuario.Text;
                menu_admin.Show();
                this.Hide();
            }
            else
            {

                if (label_cargo.Text == "Jefe De Inventario")
                {
                    menu_jefe_inventario menu_ji = new menu_jefe_inventario();
                    menu_ji.cargo = label_cargo.Text;
                    menu_ji.usuario = label_usuario.Text;
                    menu_ji.Show();
                    this.Hide();
                }
                else
                {
                    if (label_cargo.Text == "Cajero")
                    {
                        menu_cajero menu_cajero = new menu_cajero();
                        menu_cajero.cargo = label_cargo.Text;
                        menu_cajero.usuario = label_usuario.Text;
                        menu_cajero.Show();
                        this.Hide();
                    }



                    else
                    {
                        MessageBox.Show("Se a presentado un error contacte con soporte tecnico");

                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                textBox1.UseSystemPasswordChar = false;// si el checkbox esta chequeado se desactiva la propiedad UseSystemPasswordChar que es para que se use una viñeta como caracter


            }
            else
            {
                textBox1.UseSystemPasswordChar = true;// si el checkbox no esta chequeado se activa la propiedad UseSystemPasswordChar y el texto saldra todo en viñetas

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox2.Checked)
            {
                textBox2.UseSystemPasswordChar = false;// si el checkbox esta chequeado se desactiva la propiedad UseSystemPasswordChar que es para que se use una viñeta como caracter


            }
            else
            {
                textBox2.UseSystemPasswordChar = true;// si el checkbox no esta chequeado se activa la propiedad UseSystemPasswordChar y el texto saldra todo en viñetas

            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox3.Checked)
            {
                textBox3.UseSystemPasswordChar = false;// si el checkbox esta chequeado se desactiva la propiedad UseSystemPasswordChar que es para que se use una viñeta como caracter


            }
            else
            {
                textBox3.UseSystemPasswordChar = true;// si el checkbox no esta chequeado se activa la propiedad UseSystemPasswordChar y el texto saldra todo en viñetas

            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox4.Checked)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;


            }
            else
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;

            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Los campos no deben estar vacios.", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    if (textBox2.Text == textBox3.Text)
                    {
                        Negocios.Empleado consulta = new Negocios.Empleado();
                        consulta.cambio_clave(label_usuario.Text, textBox1.Text, textBox3.Text);

                    }
                    else
                    {
                        MessageBox.Show("Las Contraseñas No Coinciden");
                    }
                }
            }
        }

        private void Cambio_de_clave_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {
                Cambio_de_clave cambio_clave = new Cambio_de_clave();
                cambio_clave.Close();

            }
            else
            {
                if (dialog == DialogResult.Cancel)
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
            MessageBox.Show("Observar Manual de Usuario pagina 146-148");
        }
    }
}
    


