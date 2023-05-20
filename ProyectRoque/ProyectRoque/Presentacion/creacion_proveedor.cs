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
    public partial class creacion_proveedor : Form
    {
        public creacion_proveedor()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (textBox_cod.Text == "" || textBox_nombre.Text == "" || textBox_direccion.Text == "" ||textBox_correo.Text == "" || textBox_telefono.Text=="")
            {
                MessageBox.Show("Los Campos No Deben Estar Vacios, reintente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
            else
            {
                Negocios.Proveedor creacion_proveedor = new Negocios.Proveedor();
                
                creacion_proveedor.creacion_proveedor(textBox_cod.Text,textBox_nombre.Text, textBox_direccion.Text,textBox_correo.Text,textBox_telefono.Text,label_usuario.Text);
               
            }
            }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Proveedores proveedor = new Proveedores();
            proveedor.usuario = label_usuario.Text;
            proveedor.cargo = label_cargo.Text;
            proveedor.Show();
            this.Hide();
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proveedores proveedor = new Proveedores();
            proveedor.usuario = label_usuario.Text;
            proveedor.cargo = label_cargo.Text;
            proveedor.Show();
            this.Hide();
        }

        private void textBox_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            //para no permitir que se ingresen letras(solo numeros)
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            } 

            else {
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

        private void creacion_proveedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {
                creacion_proveedor Creacion_P = new creacion_proveedor();
                Creacion_P.Close();
            }
            else if (dialog == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
        public string usuario;
        public string cargo;

        private void creacion_proveedor_Load(object sender, EventArgs e)
        {
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
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

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 95-97");
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
        
      
