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
    public partial class creacion_empleado : Form
    {
        public creacion_empleado()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            if (textBox_usuario.Text == "" || textBox_cedula.Text == "" || textBox_nombre.Text == "" || textBox_direccion.Text == "" || textBox_correo.Text == "" || textBox_observaciones.Text == "" || comboBox_cargo.Text == "")
            {
                MessageBox.Show("Los Campos No Deben Estar Vacios, reintente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridView1.RowCount == 0)
            {

                MessageBox.Show("Agrege los datos de experincia laboral a la tabla dando clic en le boton 'Agregar Experiencia' antes de continuar");
            }
            else
            {
                Negocios.Empleado creacion_empleado = new Negocios.Empleado();

                 creacion_empleado.creacion_empleado(textBox_usuario.Text, textBox_cedula.Text, textBox_nombre.Text, comboBox_cargo.Text, textBox_direccion.Text, textBox_correo.Text, textBox_observaciones.Text, Fecha.Text,label_usuario.Text, textBox_telefono.Text);
               
                

                    for (int cont = 0; cont < dataGridView1.RowCount; cont++)
                    {
                        Negocios.Empleado creacion_empleado_experiencia = new Negocios.Empleado();
                        creacion_empleado_experiencia.creacion_empleado_experiencia(dataGridView1.Rows[cont].Cells[0].Value.ToString(), dataGridView1.Rows[cont].Cells[1].Value.ToString(), dataGridView1.Rows[cont].Cells[2].Value.ToString(), dataGridView1.Rows[cont].Cells[3].Value.ToString(), dataGridView1.Rows[cont].Cells[4].Value.ToString(), dataGridView1.Rows[cont].Cells[5].Value.ToString(), dataGridView1.Rows[cont].Cells[6].Value.ToString(), dataGridView1.Rows[cont].Cells[7].Value.ToString());
                    }

                Empleados emple = new Empleados();
                emple.usuario = label_usuario.Text;
                emple.cargo = label_cargo.Text;
                emple.Show();
                this.Hide();

            }



        }

        private void Fecha_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Fecha.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabPage2.Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Empleados emple = new Empleados();
            emple.usuario = label_usuario.Text;
            emple.cargo = label_cargo.Text;
            emple.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Empleados emple = new Empleados();
            emple.usuario = label_usuario.Text;
            emple.cargo = label_cargo.Text;
            emple.Show();
            this.Hide();

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void textBox_cedula_KeyPress(object sender, KeyPressEventArgs e)
        {

            //para no permitir que no se ingresen letras(solo numeros)
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

        private void textBox_telefono_anterior_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_telefono_anterior_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox_cedula_TextChanged(object sender, EventArgs e)
        {

        }
        public string cargo;
        public string usuario;
        
        private void creacion_empleado_Load(object sender, EventArgs e)
        {
            label_usuario.Text = usuario;
            label_cargo.Text= cargo;
        }

        private void creacion_empleado_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {
                creacion_empleado Creacion_E = new creacion_empleado();
                Creacion_E.Close();
            }
            else if (dialog == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empleados emple = new Empleados();
            emple.usuario = label_usuario.Text;
            emple.cargo = label_cargo.Text;
            emple.Show();
            this.Hide();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Empleados emple = new Empleados();
            emple.usuario = label_usuario.Text;
            emple.cargo = label_cargo.Text;
            emple.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
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

        private void textBox_observaciones_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox_observaciones_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox_nombre_empresa_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox_motivo_retiro_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox_cargo_anterior_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox_jefe_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tabPage2_Click(object sender, EventArgs e)
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
            } 
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string anios = Convert.ToString(numericUpDown_years.Value);
            dataGridView1.Rows.Add(textBox_cedula.Text,textBox_nombre_empresa.Text,textBox_motivo_retiro.Text,textBox_cargo_anterior.Text,textBox_telefono_anterior.Text,textBox_direccion_empresa.Text,textBox_jefe.Text,anios);
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

        private void textBox_usuario_Leave(object sender, EventArgs e)
        {
            try
            {
                Negocios.Empleado nn = new Negocios.Empleado();
                string resultado = nn.validacion_nombre_usuario(textBox_usuario.Text);

                if (resultado == "false")
                {
                    MessageBox.Show("El nombre de usuario ya existe digite uno diferente");
                    this.textBox_usuario.Focus();

                }
                else if (resultado == "true")
                {
                    //no existe y se puede agregar uno nuevo


                }
            }
            catch (Exception)
            {

            }
        }

        private void textBox_cedula_Leave(object sender, EventArgs e)
        {
            try
            {
                Negocios.Empleado nn = new Negocios.Empleado();
                string resultado = nn.validacion_cedula(textBox_cedula.Text);

                if (resultado == "false")
                {
                    MessageBox.Show("la cedula digitada ya existe digite una diferente.");
                    this.textBox_cedula.Focus();

                }
                else if (resultado == "true")
                {
                    //no existe y se puede agregar uno nuevo


                }
            }
            catch (Exception)
            {

            }
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 68-72");
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 68-72");
        }
    }
    }


