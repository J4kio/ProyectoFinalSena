using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//EQUIPO-24\\SQLEXPRESS
namespace ProyectRoque.Presentacion
{
    public partial class consulta_empleados : Form
    {
        public consulta_empleados()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {

                Negocios.Empleado consulta_empleado = new Negocios.Empleado();

                consulta_empleado.consulta_empleado(textBox1.Text);
                dataGridView1.DataSource = consulta_empleado.consulta_empleado(textBox1.Text);

            }
            else
            {
                if (radioButton2.Checked == true)
                {

                    Negocios.Empleado consulta_empleado_nombre = new Negocios.Empleado();
                     dataGridView1.DataSource = consulta_empleado_nombre.conuslta_empleado_nombre(textBox1.Text);


                }



                else
                {

                    if (radioButton3.Checked == true)
                    {
                        Negocios.Empleado consulta_empleado_estado = new Negocios.Empleado();
                        dataGridView1.DataSource = consulta_empleado_estado.consulta_empleado_estado(comboBox_Estado.Text);
                        
                    }
                    else
                    {
                        if (radioButton4.Checked == true)
                        {
                            Negocios.Empleado consulta_empleado_us = new Negocios.Empleado();
              
                            dataGridView1.DataSource = consulta_empleado_us.consulta_empleado_us(textBox1.Text);
                        }
                        else
                        {
                            if (radioButton5.Checked == true)
                            {

                                Negocios.Empleado consulta_empleado_correo = new Negocios.Empleado();
                          
                                dataGridView1.DataSource = consulta_empleado_correo.consulta_empleado_correo(textBox1.Text);

                            }
                            else
                            {
                                if (radioButton6.Checked==true)
                                {

                                    Negocios.Empleado consulta_general_empleado = new Negocios.Empleado();
                                    dataGridView1.DataSource =consulta_general_empleado.consulta_general_empleado(textBox1.Text);
                                   

                                }
                              
                            }
                        }
                    }

                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {


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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void consulta_empleados_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {
                consulta_empleados Consulta_E = new consulta_empleados();
                Consulta_E.Close();
            }
            else
            {

                if (dialog == DialogResult.Cancel)
                {

                    e.Cancel = true;


                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();// para limpiar la caja de texto al darle clic
            label3.Visible = false;
            label1.Visible = true;
            textBox1.Visible = true;
            comboBox_Estado.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label3.Visible = false;
            comboBox_Estado.Visible = false;
            label1.Visible = true;
            textBox1.Visible = true;
            textBox1.Clear();// para limpiar la caja de texto al darle clic
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBox1.Visible = false;
            label3.Visible = true;
            comboBox_Estado.Visible = true;
            textBox1.Clear();// para limpiar la caja de texto al darle clic
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBox1.Visible = true;
            label3.Visible = false;
            comboBox_Estado.Visible = false;
            textBox1.Clear();// para limpiar la caja de texto al darle clic
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBox1.Visible = true;
            label3.Visible = false;
            comboBox_Estado.Visible = false;
            textBox1.Clear();// para limpiar la caja de texto al darle clic
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (radioButton1.Checked == true)
                {

                    Negocios.Empleado consulta_empleado = new Negocios.Empleado();

                    consulta_empleado.consulta_empleado(textBox1.Text);
                    dataGridView1.DataSource = consulta_empleado.consulta_empleado(textBox1.Text);

                }
                else
                {
                    if (radioButton2.Checked == true)
                    {

                        Negocios.Empleado consulta_empleado_nombre = new Negocios.Empleado();
                        consulta_empleado_nombre.conuslta_empleado_nombre(textBox1.Text);
                        dataGridView1.DataSource = consulta_empleado_nombre.conuslta_empleado_nombre(textBox1.Text);


                    }



                    else
                    {

                        if (radioButton3.Checked == true)
                        {
                            Negocios.Empleado consulta_empleado_estado = new Negocios.Empleado();
                            consulta_empleado_estado.consulta_empleado_estado(textBox1.Text);
                            dataGridView1.DataSource = consulta_empleado_estado.consulta_empleado_estado(textBox1.Text);
                        }
                        else
                        {
                            if (radioButton4.Checked == true)
                            {
                                Negocios.Empleado consulta_empleado_us = new Negocios.Empleado();
                                consulta_empleado_us.consulta_empleado_us(textBox1.Text);
                                dataGridView1.DataSource = consulta_empleado_us.consulta_empleado_us(textBox1.Text);
                            }
                            else
                            {
                                if (radioButton5.Checked == true)
                                {

                                    Negocios.Empleado consulta_empleado_correo = new Negocios.Empleado();
                                    consulta_empleado_correo.consulta_empleado_correo(textBox1.Text);
                                    dataGridView1.DataSource = consulta_empleado_correo.consulta_empleado_correo(textBox1.Text);

                                }
                                else
                                {
                                    if (textBox1.Text == "")
                                    {

                                        Negocios.Empleado consulta_general_empleado = new Negocios.Empleado();
                                        consulta_general_empleado.consulta_general_empleado(textBox1.Text);
                                        dataGridView1.DataSource = consulta_general_empleado.consulta_general_empleado(textBox1.Text);

                                    }

                                }
                            }
                        }

                    }


                }
            }


        }
        public string usuario;
        public string cargo;

        private void consulta_empleados_Load(object sender, EventArgs e)
        {
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Negocios.Empleado consulta_experiencia = new Negocios.Empleado();
            dataGridView3.DataSource = consulta_experiencia.consulta_experiencia(dataGridView1.CurrentRow.Cells[1].Value.ToString()); 
                       
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 73-75");
        }
    }
}
