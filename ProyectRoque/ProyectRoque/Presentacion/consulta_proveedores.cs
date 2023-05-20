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
    public partial class consulta_proveedores : Form
    {
        public consulta_proveedores()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            if(radioButton1.Checked==true){
            Negocios.Proveedor consulta_proveedor = new Negocios.Proveedor();

            
            dataGridView1.DataSource = consulta_proveedor.consulta_proveedor(textBox_np.Text);
            }
            else{
                if(radioButton2.Checked==true){
                    Negocios.Proveedor consulta_proveedor_codigo = new Negocios.Proveedor();
                    dataGridView1.DataSource = consulta_proveedor_codigo.consulta_proveedor_codigo(textBox_cp.Text);
            }
                else
                {
                    if (radioButton3.Checked == true)
                    {
                        string x = "x";//para enviar "algo"
                        Negocios.Proveedor consulta_proveedor_general = new Negocios.Proveedor();
                        dataGridView1.DataSource = consulta_proveedor_general.consulta_proveedor_general(x);//para enviar "algo"
                    }
                    else
                    {
                        MessageBox.Show("Seleccione un filtro para buscar al proveedor");
                    }
                }
        }
        
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Proveedores proveedor = new Proveedores();
            proveedor.usuario = label_usuario.Text;
            proveedor.cargo = label_cargo.Text;

            proveedor.Show();
            this.Hide();
        }

        private void consulta_proveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {
                consulta_proveedores Consulta_P = new consulta_proveedores();
                Consulta_P.Close();
            }
            else if (dialog == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
        public string usuario;
        public string cargo;
        private void consulta_proveedores_Load(object sender, EventArgs e)
        {

            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
        }

        private void textBox_np_KeyPress(object sender, KeyPressEventArgs e)
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

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true) {
                textBox_cp.Enabled = false;
                textBox_np.Enabled = false;
              
            
            
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked== true){
                textBox_cp.Enabled = true;
                textBox_cp.Visible = true;
                textBox_np.Enabled = false;
                           
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true){
                textBox_np.Enabled = true;
                textBox_np.Visible = true;
                label1.Visible = true;

                textBox_cp.Enabled = false;
               
            }
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 97-99");
        }

    }
}
