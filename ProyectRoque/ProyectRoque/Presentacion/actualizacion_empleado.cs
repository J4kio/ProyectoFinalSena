using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProyectRoque.Presentacion
{
    public partial class actualizacion_empleado : Form
    {
        public actualizacion_empleado()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_ni.Text == "")
            {
                MessageBox.Show("Digite El Numero De Cedula Del Empelado Antes De Continuar", "Digite La Cedula Del Empleado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Negocios.Empleado consulta_empleado = new Negocios.Empleado();

                consulta_empleado.consulta_empleado(textBox_ni.Text);
                dataGridView1.DataSource = consulta_empleado.consulta_empleado(textBox_ni.Text);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_usuario.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox_nombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox_cargo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox_direccion.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox_correo.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox_observaciones.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           if (textBox_usuario.Text == "" || textBox_nombre.Text == "" || textBox_direccion.Text == "" || textBox_correo.Text == "" || textBox_observaciones.Text == "" || comboBox_cargo.Text == "" )
           {
               MessageBox.Show("Diligencie todos los campos antes de continuar.");
            }
            else{
            DialogResult dialog = MessageBox.Show("¿Desea guardar los cambios realizados?", "Confirmacion actualizacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // el resultado del cuadro de dialogo para luego evaluarlo en el if

            if (dialog == DialogResult.Yes)//si el usuario da clic en SI se realizara la actualizacion
            {
                Negocios.Empleado actualizacion_empleado = new Negocios.Empleado();
                actualizacion_empleado.actualizacion_empleado(textBox_usuario.Text, textBox_ni.Text, textBox_nombre.Text, comboBox_cargo.Text, textBox_direccion.Text, textBox_correo.Text, textBox_observaciones.Text);
                
            }
            else
            { // no le da en NO no se realizara la actualizacion
            }
        }
        }
        

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empleados empleado = new Empleados();
            empleado.cargo = label_cargo.Text;
            empleado.usuario = label_usuario.Text;
            empleado.Show();
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void actualizacion_empleado_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {
                actualizacion_empleado act = new actualizacion_empleado();
                act.Close();
            }
            else if (dialog == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox_ni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (textBox_ni.Text == "")
                {
                    MessageBox.Show("Digite El Numero De Cedula Del Empelado Antes De Continuar", "Digite La Cedula Del Empleado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Negocios.Empleado consulta_empleado = new Negocios.Empleado();

                    consulta_empleado.consulta_empleado(textBox_ni.Text);
                    dataGridView1.DataSource = consulta_empleado.consulta_empleado(textBox_ni.Text);
                }
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
        }
        public string usuario;
        public string cargo;
        private void actualizacion_empleado_Load(object sender, EventArgs e)
        {
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Negocios.Empleado consulta_experiencia = new Negocios.Empleado();
            dataGridView2.DataSource = consulta_experiencia.consulta_experiencia(label10.Text);
            tabControl1.SelectedTab = tabPage2;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox_ni.Text == "")
            {
                MessageBox.Show("Digite El Numero De Cedula Del Empelado Antes De Continuar", "Digite La Cedula Del Empleado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Negocios.Empleado consulta_empleado = new Negocios.Empleado();

                consulta_empleado.consulta_empleado(textBox_ni.Text);
                dataGridView1.DataSource = consulta_empleado.consulta_empleado(textBox_ni.Text);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox_usuario.Text == "" || textBox_nombre.Text == "" || textBox_direccion.Text == "" || textBox_correo.Text == "" || textBox_observaciones.Text == "" || comboBox_cargo.Text == "")
            {
                MessageBox.Show("Diligencie todos los campos antes de continuar.");
            }
            else
            {
                DialogResult dialog = MessageBox.Show("¿Desea guardar los cambios realizados?", "Confirmacion actualizacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // el resultado del cuadro de dialogo para luego evaluarlo en el if

                if (dialog == DialogResult.Yes)//si el usuario da clic en SI se realizara la actualizacion
                {
                    Negocios.Empleado actualizacion_empleado = new Negocios.Empleado();
                    actualizacion_empleado.actualizacion_empleado(textBox_usuario.Text, textBox_ni.Text, textBox_nombre.Text, comboBox_cargo.Text, textBox_direccion.Text, textBox_correo.Text, textBox_observaciones.Text);

                }
                else
                { // no le da en NO no se realizara la actualizacion
                }
            }
        }

        private void atrasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Empleados empleado = new Empleados();
            empleado.cargo = label_cargo.Text;
            empleado.usuario = label_usuario.Text;
            empleado.Show();
            this.Hide();
        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            label10.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox_usuario.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox_nombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox_cargo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox_direccion.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox_correo.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox_observaciones.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void textBox_ni_KeyPress_1(object sender, KeyPressEventArgs e)
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

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (textBox_ni.Text == "")
                {
                    MessageBox.Show("Digite El Numero De Cedula Del Empelado Antes De Continuar", "Digite La Cedula Del Empleado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Negocios.Empleado consulta_empleado = new Negocios.Empleado();

                    consulta_empleado.consulta_empleado(textBox_ni.Text);
                    dataGridView1.DataSource = consulta_empleado.consulta_empleado(textBox_ni.Text);
                }
              
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           label19.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
             textBox_nombre_empresa.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            textBox_motivo_retiro.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            textBox_cargo_anterior.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            textBox_telefono_anterior.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            textBox_direccion_empresa.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            textBox_jefe.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            int year = Convert.ToInt32( dataGridView2.CurrentRow.Cells[2].Value.ToString());
            numericUpDown_years.Value = year;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Empleados empleado = new Empleados();
            empleado.cargo = label_cargo.Text;
            empleado.usuario = label_usuario.Text;
            empleado.Show();
            this.Hide();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

           
            
                if (textBox_nombre_empresa.Text=="" || textBox_motivo_retiro.Text == "" || textBox_cargo_anterior.Text == "" || textBox_telefono_anterior.Text==""){
                    MessageBox.Show("Los campos no deben estar vacios");
                }
                else if (textBox_jefe.Text == "") {

                    MessageBox.Show("Los campos no deben estar vacios");
                
                }
                else
                {
                    string year = Convert.ToString(numericUpDown_years.Value);
                    Negocios.Empleado actualizacion_experiencia = new Negocios.Empleado();

                    actualizacion_experiencia.actualizacion_empleado_experiencia(label19.Text, textBox_nombre_empresa.Text, textBox_motivo_retiro.Text, textBox_cargo_anterior.Text, textBox_telefono_anterior.Text, textBox_direccion_empresa.Text, textBox_jefe.Text, year);
                }
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

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 76-79");
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 79-81");
        }

        private void textBox_telefono_anterior_KeyPress(object sender, KeyPressEventArgs e)
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
