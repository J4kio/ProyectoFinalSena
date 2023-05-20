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
    public partial class consulta_factura_compra : Form
    {
        public consulta_factura_compra()
        {
            InitializeComponent();
        }
        public string cargo;
        public string usuario;
        private void consulta_factura_compra_Load(object sender, EventArgs e)
        {
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Factura_Compra factura_compra = new Factura_Compra();
            factura_compra.usuario = usuario;
            factura_compra.cargo = cargo;
            factura_compra.Show();
            this.Hide();
        }

        private void consulta_factura_compra_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (dialog == DialogResult.Yes)
            {

                consulta_factura_compra cierre = new consulta_factura_compra();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked== true){
            Negocios.Factura_Compra consulta_factura_fecha = new Negocios.Factura_Compra();
            dataGridView1.DataSource = consulta_factura_fecha.consulta_factura_fecha(dateTimePicker1.Text);
            }
            else if (radioButton1.Checked == true && textBox1.Text != "")
            {

                Negocios.Factura_Compra consulta_cod_factura = new Negocios.Factura_Compra();
                dataGridView1.DataSource = consulta_cod_factura.consulta_factura_cod(textBox1.Text);
 
            
            
            
            }
            else if (radioButton3.Checked == true && textBox1.Text != "")
            {
                Negocios.Factura_Compra consulta_factura_cedula = new Negocios.Factura_Compra();
                dataGridView1.DataSource = consulta_factura_cedula.consulta_factura_cedula(textBox1.Text);




            }
            else if (radioButton4.Checked == true && textBox1.Text != "")
            {

                Negocios.Factura_Compra consulta_factura_cod_proveedor = new Negocios.Factura_Compra();
                dataGridView1.DataSource = consulta_factura_cod_proveedor.consulta_factura_por_cod_proveedor(textBox1.Text);



            }
            else if (radioButton5.Checked == true && textBox1.Text != "")
            {


                Negocios.Factura_Compra consulta_factura_cod_del_proveedor = new Negocios.Factura_Compra();
                dataGridView1.DataSource = consulta_factura_cod_del_proveedor.consulta_factura_codigo_proveedor(textBox1.Text);


            }
            else {

                MessageBox.Show("Digite el dato antes de continuar");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox1.Clear();
            dateTimePicker1.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox1.Clear();
            dateTimePicker1.Enabled = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox1.Clear();
            dateTimePicker1.Enabled = false;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox1.Clear();
            dateTimePicker1.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox1.Clear();
            dateTimePicker1.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Negocios.Factura_Compra consulta_detalles_factura = new Negocios.Factura_Compra();
            dataGridView2.DataSource = consulta_detalles_factura.consulta_detalles_factura(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 131-133");
        }
    }
}
