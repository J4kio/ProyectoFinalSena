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
    public partial class consulta_facturas_venta : Form
    {
        public consulta_facturas_venta()
        {
            InitializeComponent();
        }
        public string cargo;
        public string usuario;
        private void consulta_facturas_venta_Load(object sender, EventArgs e)
        {
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
           
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Factura_venta factura_venta = new Factura_venta();
            factura_venta.usuario = usuario;
            factura_venta.cargo = cargo;
            factura_venta.Show();
            this.Hide();
        }

        private void consulta_facturas_venta_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (dialog == DialogResult.Yes)
            {

                consulta_facturas_venta cierre = new consulta_facturas_venta();
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


            if (radioButton2.Checked == true)
            {


                Negocios.Factura_venta consulta_factura_fecha = new Negocios.Factura_venta();
                dataGridView1.DataSource = consulta_factura_fecha.consulta_factura_fecha(dateTimePicker1.Text);
            }
            else
            {
                if (radioButton1.Checked == true && textBox1.Text !="")
                {
                    Negocios.Factura_venta consulta_factura = new Negocios.Factura_venta();
                    dataGridView1.DataSource = consulta_factura.consulta_factura(textBox1.Text);

                }
                else
                {

                    if (radioButton3.Checked == true && textBox1.Text != "")
                    {
                        Negocios.Factura_venta consulta_factura_cedula_empleado = new Negocios.Factura_venta();
                        dataGridView1.DataSource = consulta_factura_cedula_empleado.consulta_factura_cedula_empleado(textBox1.Text);
                    }

                    else
                    {

                        if (radioButton4.Checked == true && textBox1.Text != "")
                        {
                            Negocios.Factura_venta consulta_factura_cedula_cliente = new Negocios.Factura_venta();
                            dataGridView1.DataSource = consulta_factura_cedula_cliente.consulta_factura_cedula_cliente(textBox1.Text);
                        }
                        else {
                            MessageBox.Show("Digite el dato antes de continuar");
                        
                        }
                    }
                    
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Negocios.Factura_venta consulta_detalles_factura = new Negocios.Factura_venta();
            dataGridView2.DataSource = consulta_detalles_factura.consulta_detalles_factura(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                textBox1.Enabled = false;
                dateTimePicker1.Enabled = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox1.Enabled = true;
                dateTimePicker1.Enabled = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                textBox1.Enabled = true;
                dateTimePicker1.Enabled = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                textBox1.Enabled = true;
                dateTimePicker1.Enabled = false;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {

                    if (radioButton2.Checked == true)
                    {


                        Negocios.Factura_venta consulta_factura_fecha = new Negocios.Factura_venta();
                        dataGridView1.DataSource = consulta_factura_fecha.consulta_factura_fecha(dateTimePicker1.Text);
                    }
                    else
                    {
                        if (radioButton1.Checked == true)
                        {
                            Negocios.Factura_venta consulta_factura = new Negocios.Factura_venta();
                            dataGridView1.DataSource = consulta_factura.consulta_factura(textBox1.Text);

                        }
                        else
                        {

                            if (radioButton3.Checked == true)
                            {
                                Negocios.Factura_venta consulta_factura_cedula_empleado = new Negocios.Factura_venta();
                                dataGridView1.DataSource = consulta_factura_cedula_empleado.consulta_factura_cedula_empleado(textBox1.Text);
                            }

                            else
                            {

                                if (radioButton4.Checked == true)
                                {
                                    Negocios.Factura_venta consulta_factura_cedula_cliente = new Negocios.Factura_venta();
                                    dataGridView1.DataSource = consulta_factura_cedula_cliente.consulta_factura_cedula_cliente(textBox1.Text);
                                }

                            }
                        }
                    }
                }
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            DataSet DatosFormBase = new DataSet();


            if (dataGridView1.RowCount == 0 || dataGridView2.RowCount == 0)
            {

                MessageBox.Show("Las tablas no pueden estar vacias.");


            }
            else
            {

                int total = Convert.ToInt32(dataGridView1.CurrentRow.Cells[6].Value.ToString());
                int total_iva = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                int subtotal;
                subtotal = total - total_iva;

                string Subtotal = Convert.ToString(subtotal);

                Negocios.Factura_venta envio = new Negocios.Factura_venta();

                for (int cont = 0; cont < dataGridView2.RowCount; cont++)
                {
                    DatosFormBase = envio.envio_datos(dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString(), dataGridView1.CurrentRow.Cells[4].Value.ToString(), dataGridView1.CurrentRow.Cells[5].Value.ToString(), dataGridView1.CurrentRow.Cells[6].Value.ToString(), dataGridView1.CurrentRow.Cells[3].Value.ToString(), dataGridView1.CurrentRow.Cells[7].Value.ToString(), Subtotal, dataGridView2.Rows[cont].Cells[1].Value.ToString(), dataGridView2.Rows[cont].Cells[2].Value.ToString(), dataGridView2.Rows[cont].Cells[3].Value.ToString(), dataGridView2.Rows[cont].Cells[5].Value.ToString(), dataGridView2.Rows[cont].Cells[4].Value.ToString(), dataGridView2.Rows[cont].Cells[6].Value.ToString());
                }


                Presentacion.Informe_factura_venta reporte = new Presentacion.Informe_factura_venta();
                reporte.nuevo = DatosFormBase;
                reporte.Show();
            }

        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 143-145");
        }
    }
}
