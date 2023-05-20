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
    public partial class creacion_factura_venta : Form
    {
        public creacion_factura_venta()
        {
            InitializeComponent();
        }
        public string cargo;
        public string usuario;

        private void creacion_factura_venta_Load(object sender, EventArgs e)
        {
            
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
            label27.Text = DateTime.Now.ToLongDateString();
            Negocios.Factura_venta cedula_empleado = new Negocios.Factura_venta();
            label8.Text = cedula_empleado.cedula_empleado(label_usuario.Text);



            string cod;

            int codigo;
            Negocios.Factura_venta codi = new Negocios.Factura_venta();
            cod = codi.consulta_cod();

            if (cod == "")
            {
                cod = "1";
                label25.Text = cod;
            }
            else
            {
                int numero = Convert.ToInt32(cod);
                codigo = numero + 1;
                label25.Text = Convert.ToString(codigo);
            }


        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Factura_venta factura_venta = new Factura_venta();
            factura_venta.usuario = usuario;
            factura_venta.cargo = cargo;
            factura_venta.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Negocios.Factura_venta factura = new Negocios.Factura_venta();
            textBox2.Text = factura.cantidad(comboBox1.Text);

            Negocios.Factura_venta precio_unitario = new Negocios.Factura_venta();
            textBox4.Text = precio_unitario.precio_unitario(comboBox1.Text);

            Negocios.Factura_venta iva = new Negocios.Factura_venta();
            textBox5.Text = iva.iva(comboBox1.Text);

            Negocios.Factura_venta codigo = new Negocios.Factura_venta();
            textBox9.Text = codigo.codigo_producto(comboBox1.Text, comboBox2.Text);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                MessageBox.Show("Los campos no deben estar vacios.");

            }
            else
            {
                int cantidad_disponible = Convert.ToInt32(textBox2.Text);
                int cantidad_a_comprar = Int32.Parse(textBox3.Text);
                string codigo = (textBox9.Text);

                if (textBox1.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("Diligencie todos los campos antes de continuar.");

                }

                else if (textBox6.Text == "")
                {
                    MessageBox.Show("seleccione la cantidad antes de continuar.");
                }
                else if (cantidad_a_comprar > cantidad_disponible)
                {

                    MessageBox.Show("La cantidad a comprar no puede ser mayor a la cantidad a comprar");
                }



                else
                {
                    if (dataGridView1.Rows.Count == 0)
                    {
                        dataGridView1.Rows.Add(textBox9.Text, comboBox1.Text, textBox3.Text, textBox5.Text, textBox7.Text, textBox4.Text, textBox6.Text);

                    }
                    else
                    {
                        int cantidad = Convert.ToInt32(textBox3.Value);
                        string cod = "";
                        for (int contador = 0; contador < dataGridView1.Rows.Count; contador++)
                        {
                            cantidad = cantidad + Convert.ToInt32(dataGridView1.Rows[contador].Cells[2].Value.ToString());
                            cod = dataGridView1.Rows[contador].Cells[0].Value.ToString();

                        }
                        if (cantidad > cantidad_disponible && cod == codigo)
                        {
                            MessageBox.Show("Cantidad excedida");
                        }
                        else
                        {

                            //operacion para agregar
                            int filas = dataGridView1.Rows.Count - 1;
                           // int total_iva = 0;
                            int cantidaaaaad = Convert.ToInt32(dataGridView1.Rows[filas].Cells[2].Value.ToString());
                            //int total;
                            //decimal cantidad = textBox3.Value;
                            //int subtotal;
                            //int total_iva;
                            //int valor_uni = Convert.ToInt32(textBox4.Text);
                            //int valor_iva = Convert.ToInt32(textBox5.Text);
                            //int ca = Convert.ToInt32(cantidad);
                            //total_iva = (valor_uni * valor_iva / 100) * ca;
                            //total = valor_uni * ca;
                        

                            dataGridView1.Rows.Add(textBox9.Text, comboBox1.Text, textBox3.Text, textBox5.Text, textBox7.Text, textBox4.Text, textBox6.Text);

                            for (int cont = 0; cont < dataGridView1.Rows.Count - 1; cont++)
                            {
                                if (codigo == dataGridView1.Rows[cont].Cells[0].Value.ToString())
                                {
                                    int valor = Convert.ToInt32(textBox3.Value);
                                    int totall = Convert.ToInt32(textBox6.Text);
                                    int total_de_iva = Convert.ToInt32(textBox7.Text);
                                   

                                    dataGridView1.Rows[cont].Cells[2].Value = Convert.ToInt32(dataGridView1.Rows[cont].Cells[2].Value.ToString()) + valor;
                                    dataGridView1.Rows[cont].Cells[6].Value = Convert.ToInt32(dataGridView1.Rows[cont].Cells[6].Value.ToString())+  totall;
                                    dataGridView1.Rows[cont].Cells[4].Value = Convert.ToInt32(dataGridView1.Rows[cont].Cells[4].Value.ToString()) + total_de_iva;
                                    cont = dataGridView1.Rows.Count + 1;  //Para terminar el FOR
                                    //Eliminar la ultima fila
                                    
                                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
                                    
                                }
                            }


                        }

                    }

                    int total = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        total += Convert.ToInt32(row.Cells["Total"].Value);
                    }
                    lbl5.Text = Convert.ToString(total);


                    int total_iva = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        total_iva += Convert.ToInt32(row.Cells["total_iva"].Value);
                    }
                    label20.Text = Convert.ToString(total_iva);

                    int total_productos = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        total_productos += Convert.ToInt32(row.Cells["Cantidad"].Value);
                    }
                    label1.Text = Convert.ToString(total_productos);

                    int subtotal_compra;
                    subtotal_compra = total - total_iva;
                    label22.Text = Convert.ToString(subtotal_compra);
                }
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            string resultado;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Digite el numero de identificacion del cliente antes de continuar.");
            }
            else
            {
                Negocios.Factura_venta cedula_cliente = new Negocios.Factura_venta();
                //cedula_cliente.cedula_cliente(textBox1.Text);
                resultado = cedula_cliente.cedula_cliente(textBox1.Text);

                if (resultado == "true")
                {
                    textBox1.Enabled = false;
                    MessageBox.Show("El Cliente existe y se puede realizar la fatura de venta");
                    Negocios.Factura_venta nn = new Negocios.Factura_venta();
                    label29.Text = nn.nombre_cliente(textBox1.Text);

                }
                else
                {

                    if (resultado == "false")
                    {

                        textBox1.Enabled = true;
                        MessageBox.Show("El Cliente no existe y no se puede realizar la fatura de venta");
                        MessageBox.Show("Si el cliente no esta registrado y no se quiere registrar digite '00'");

                    }
                }
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
            } 
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

            //para no permitir que no se ingresen letras(solo numeros)
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                if (textBox4.Text == "")
                {
                    MessageBox.Show("Seleccione la forma farmaceutica y el nombre del producto antes de continuar.");

                }
                else
                {

                    int subtotal;
                    int total;
                    int cantidad_comprar = Int32.Parse(textBox3.Text);
                    int valor_unitario = Int32.Parse(textBox4.Text);
                    int valor_iva = Int32.Parse(textBox5.Text);
                    int total_iva;


                    subtotal = cantidad_comprar * valor_unitario;
                    total_iva = subtotal * valor_iva / 100;
                    total = total_iva + subtotal;

                    string Total_iva = Convert.ToString(total_iva);
                    string Subtotal = Convert.ToString(subtotal);
                    string Total = Convert.ToString(total);


                    textBox7.Text = Total_iva;
                    textBox8.Text = Subtotal;
                    textBox6.Text = Total;
                }
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

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Seleccione la forma farmaceutica y el nombre del producto antes de continuar.");

            }
            else
            {

                int subtotal;
                int total;
                int cantidad_comprar = Int32.Parse(textBox3.Text);
                int valor_unitario = Int32.Parse(textBox4.Text);
                int valor_iva = Int32.Parse(textBox5.Text);
                int total_iva;


                subtotal = cantidad_comprar * valor_unitario;
                total_iva = subtotal * valor_iva / 100;
                total = total_iva + subtotal;

                string Total_iva = Convert.ToString(total_iva);
                string Subtotal = Convert.ToString(subtotal);
                string Total = Convert.ToString(total);


                textBox7.Text = Total_iva;
                textBox8.Text = Subtotal;
                textBox6.Text = Total;
            }
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Enabled == false)
            {
                //Llenado de un ComboBox
                comboBox1.ValueMember = "Nombre";  //Nombre de la columna de la tabla a consultar
                Negocios.Factura_venta datos = new Negocios.Factura_venta();
                comboBox1.DataSource = datos.Lista(comboBox2.Text);
            }
            else
            {
                if (textBox1.Enabled == true)
                {
                    MessageBox.Show("Digite un cliente valido antes de continuar.");
                    MessageBox.Show("Si el cliente no esta registrado y no se quiere registrar digite '00'");

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.RowCount == 0 || textBox1.Text==""|| textBox6.Text==""){

                MessageBox.Show("Campos en blanco");
            }
            else{

            textBox1.Enabled = true;
            textBox1.Clear();
            textBox9.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox3.Value = 1;
            textBox3.Text = "1";
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();

            dataGridView1.Rows.Clear();
            lbl5.Text = "Cargando...";
            label1.Text = "Cargando...";
            label20.Text = "Cargando...";
            label22.Text = "Cargando...";
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.RowCount == 0 || textBox6.Text == "" || textBox1.Text == "")
                {
                    MessageBox.Show("Campos vacios reintente");
                }
                else
                {
                    Negocios.Factura_venta tabla_factura = new Negocios.Factura_venta();
                    tabla_factura.Insercion_factura_venta(label8.Text, label20.Text, label15.Text, label27.Text, label1.Text, textBox1.Text, lbl5.Text);
                    string cod_factura = "";
                    for (int cont = 0; cont < dataGridView1.RowCount; cont++)
                    {
                        Negocios.Factura_venta detalles_factura = new Negocios.Factura_venta();
                        cod_factura = detalles_factura.Insercion_detalles_factura_venta(dataGridView1.Rows[cont].Cells[0].Value.ToString(), dataGridView1.Rows[cont].Cells[2].Value.ToString(), dataGridView1.Rows[cont].Cells[6].Value.ToString(), dataGridView1.Rows[cont].Cells[3].Value.ToString());
                    }
                    for (int cont = 0; cont < dataGridView1.RowCount; cont++)
                    {
                        Negocios.Factura_venta cantidad_producto = new Negocios.Factura_venta();
                        cantidad_producto.actualizacion_productos(dataGridView1.Rows[cont].Cells[0].Value.ToString(), dataGridView1.Rows[cont].Cells[2].Value.ToString());
                    }







                    DataSet DatosFormBase = new DataSet();





                    Negocios.Factura_venta enviar = new Negocios.Factura_venta();

                    for (int cont = 0; cont < dataGridView1.RowCount; cont++)
                    {
                        DatosFormBase = enviar.envio_datos(label25.Text, label29.Text, label20.Text, label15.Text, lbl5.Text, textBox1.Text, label1.Text, label22.Text, dataGridView1.Rows[cont].Cells[0].Value.ToString(), dataGridView1.Rows[cont].Cells[1].Value.ToString(), dataGridView1.Rows[cont].Cells[2].Value.ToString(), dataGridView1.Rows[cont].Cells[3].Value.ToString(), dataGridView1.Rows[cont].Cells[6].Value.ToString(), dataGridView1.Rows[cont].Cells[5].Value.ToString());
                    }


                    Presentacion.Informe_factura_venta reporte = new Presentacion.Informe_factura_venta();
                    reporte.nuevo = DatosFormBase;
                    reporte.Show();





                    textBox1.Enabled = true;
                    textBox1.Clear();
                    textBox9.Clear();
                    textBox2.Clear();
                    textBox4.Clear();
                    textBox3.Value = 1;
                    textBox3.Text = "1";
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();

                    dataGridView1.DataSource = "";
                    lbl5.Text = "Cargando...";
                    label1.Text = "Cargando...";
                    label20.Text = "Cargando...";
                    label22.Text = "Cargando...";

                    MessageBox.Show("Factura registrada exitosamente.");
                    // MessageBox.Show("Codigo de factura de venta: " + cod_factura);

                    int numero_factura = Int32.Parse(cod_factura);
                    int codigo_factura;
                    codigo_factura = numero_factura + 1;
                    label25.Text = Convert.ToString(codigo_factura);
                }
            }
            catch(Exception ) { 
            
            
            }
        }

        private void textBox3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress_1(object sender, KeyPressEventArgs e)
        {


        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (textBox3.Value >= 1)
                {
                    int total;
                    decimal cantidad = textBox3.Value;
                    int subtotal;
                    int total_iva;
                    int valor_uni = Convert.ToInt32(textBox4.Text);
                    int valor_iva = Convert.ToInt32(textBox5.Text);
                    int ca = Convert.ToInt32(cantidad);
                    total_iva = (valor_uni * valor_iva / 100) * ca;
                    total = valor_uni * ca;
                    subtotal = total - total_iva;

                    textBox7.Text = Convert.ToString(total_iva);
                    textBox8.Text = Convert.ToString(subtotal);
                    textBox6.Text = Convert.ToString(total);

                }
                else
                {
                    if (textBox3.Value == 0)
                    {

                        MessageBox.Show("Valor invalido");
                        textBox3.Value = 1;
                        
                    }
                }
            }
            catch (Exception )
            {
                

            }
            finally {

                //textBox3.Value = 1;


            
            }
        }

        private void creacion_factura_venta_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (dialog == DialogResult.Yes)
            {

                creacion_factura_venta cierre = new creacion_factura_venta();
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try {
                //dataGridView1.CurrentRow.Cells[0].Value.ToString();
                //dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                int total = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    total += Convert.ToInt32(row.Cells["Total"].Value);
                }
                lbl5.Text = Convert.ToString(total);


                int total_iva = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    total_iva += Convert.ToInt32(row.Cells["total_iva"].Value);
                }
                label20.Text = Convert.ToString(total_iva);

                int total_productos = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    total_productos += Convert.ToInt32(row.Cells["Cantidad"].Value);
                }
                label1.Text = Convert.ToString(total_productos);

                int subtotal_compra;
                subtotal_compra = total - total_iva;
                label22.Text = Convert.ToString(subtotal_compra);
            }
            catch (Exception)
            {
                MessageBox.Show("No hay productos a eliminar");


            }
            }
        

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label15.Text= DateTime.Now.ToString();
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            string resultado;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Digite el numero de identificacion del cliente antes de continuar.");
                this.textBox1.Focus();
            }
            else
            {
                Negocios.Factura_venta cedula_cliente = new Negocios.Factura_venta();
                resultado = cedula_cliente.cedula_cliente(textBox1.Text);

                if (resultado == "true")
                {
                    textBox1.Enabled = false;
                    //MessageBox.Show("El Cliente existe y se puede realizar la fatura de venta");
                    Negocios.Factura_venta nn = new Negocios.Factura_venta();
                    label29.Text = nn.nombre_cliente(textBox1.Text);

                }
                else
                {

                    if (resultado == "false")
                    {

                        textBox1.Enabled = true;
                        MessageBox.Show("El Cliente no existe y no se puede realizar la fatura de venta.");
                        MessageBox.Show("Si el cliente no esta registrado y no se quiere registrar digite '00'.");
                        this.textBox1.Focus();

                    }
                }
            }
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 135-142");
        }
    }
}



