using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO; //Nueva libreria a adicionar para permitir crear objetos MemoryStream
using System.Windows.Forms;



namespace ProyectRoque.Presentacion
{
    public partial class creacion_factura_compra : Form
    {
        public creacion_factura_compra()
        {
            InitializeComponent();
        }
         public string cargo;
        public string usuario;

        private void creacion_factura_compra_Load(object sender, EventArgs e)
        {
            //Llenado de un ComboBox
            comboBox2.ValueMember = "Nombre";
            Negocios.Producto nn = new Negocios.Producto();
            comboBox2.DataSource = nn.consulta_proveedor();
                 
            label_cargo.Text = cargo;
            label_usuario.Text = usuario;
            Negocios.Factura_venta cedula_empleado = new Negocios.Factura_venta();
            label8.Text = cedula_empleado.cedula_empleado(label_usuario.Text);

            label21.Text = DateTime.Now.ToLongDateString();

            string cod;

            int codigo;
            Negocios.Factura_Compra codi = new Negocios.Factura_Compra();
            cod = codi.consulta_cod();

            if (cod == "")
            {
                cod = "1";
                label9.Text = cod;
            }
            else
            {
                int numero = Convert.ToInt32(cod);
                codigo = numero + 1;
                label9.Text = Convert.ToString(codigo);
            }
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Factura_Compra factura_compra = new Factura_Compra();
            factura_compra.usuario = usuario;
            factura_compra.cargo = cargo;
            factura_compra.Show();
            this.Hide();
        }

        private void creacion_factura_compra_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro De Que Quieres Salir", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (dialog == DialogResult.Yes)
            {

                creacion_factura_compra cierre = new creacion_factura_compra();
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

        private void btn2_Click(object sender, EventArgs e)
        {
            if ( textBox_codigo_producto.Text =="" || textBox_nombre.Text =="" || textBox_cantidad.Text==""|| textBox_precio_venta.Text=="" || textBox_iva.Text=="" || textBox_precio_de_compra.Text ==""|| textBox_precio_unitario.Text=="" || comboBox1.Text ==""){

                MessageBox.Show("Diligencie todos los campos antes de continuar.");
            }
            else{

            try
            {


                for (int cont = 0; cont < dataGridView1.RowCount; cont++)
                {
                    string cod_data = dataGridView1.Rows[cont].Cells[0].Value.ToString();

                    if (textBox_codigo_producto.Text == cod_data)
                    {
                        MessageBox.Show("Ya hay un producto con este codigo insertado en la tabla.");
                        //dataGridView1.Rows.RemoveAt(Convert.ToInt32(dataGridView1.Rows.Count.ToString()));
                        dataGridView1.Rows.RemoveAt(Convert.ToInt32(dataGridView1.Rows[cont].Cells[0].Value.ToString()));

                    }

                }

                MemoryStream memoria = new MemoryStream();  //Crea un objeto Stream como Buffer (Datos en un espacio de memoria)
                pictureBox1.Image.Save(memoria, System.Drawing.Imaging.ImageFormat.Jpeg); //Almacena la imagen en el Buffer
                byte[] memoria_imagen = memoria.ToArray();

                object imagen = pictureBox1.Image;
                dataGridView1.Rows.Add(textBox_codigo_producto.Text, textBox_nombre.Text, textBox_cantidad.Text, textBox_precio_venta.Text, textBox_iva.Text, textBox_precio_de_compra.Text, textBox_precio_unitario.Text, comboBox1.Text);






                int total = 0;
                int precio_compra = Convert.ToInt32(textBox_precio_de_compra.Text);
                int iva = Convert.ToInt32(textBox_iva.Text);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    total += Convert.ToInt32(row.Cells["precio_compra"].Value);
                }
                lbl5.Text = Convert.ToString(total);


                int total_iva = (precio_compra * iva) / 100;


                int total_productos = dataGridView1.RowCount;
                label1.Text = Convert.ToString(total_productos);

                int subtotal_compra;
                subtotal_compra = total - total_iva;
                label22.Text = Convert.ToString(subtotal_compra);

            }
            catch (Exception){
            
            }
        }
        }
        
          
        

        private void btn1_Click(object sender, EventArgs e)
        {
           
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label15.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
               
                int total = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    total += Convert.ToInt32(row.Cells["precio_compra"].Value);
                }
                lbl5.Text = Convert.ToString(total);


                int total_iva = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    total_iva += Convert.ToInt32(row.Cells["iva"].Value);
                }
                //label20.Text = Convert.ToString(total_iva);

                int total_productos = dataGridView1.RowCount;
                label1.Text = Convert.ToString(total_productos);

                int subtotal_compra;
                subtotal_compra = total - total_iva;
                label22.Text = Convert.ToString(subtotal_compra);
            }
            catch (Exception ){
            MessageBox.Show("No hay productos a Eliminar");
            
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

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox_codigo_producto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialogo = new OpenFileDialog(); //Se crea el nuevo objeto cuadro de dialogo
            DialogResult resultado = dialogo.ShowDialog(); //Se muestra esperando una acción del usuario
            if (resultado == DialogResult.OK) //Si selecciona un archivo, se muestra en el ptb1
            {
                pictureBox1.Image = Image.FromFile(dialogo.FileName);
            }
                
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Negocios.Producto nn = new Negocios.Producto();
            label27.Text = nn.consulta_cod_proveedor(comboBox2.Text);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox10.Text==""){
                MessageBox.Show("Digite el codigo de la factura de compra entregada por el proveedor antes de continuar.");
            
            }

            else if (dataGridView1.Rows.Count==0){
                MessageBox.Show("La factura debe contener productos, agrege productos antes de continuar");
            }
            else{

            Negocios.Factura_Compra tabla_factura = new Negocios.Factura_Compra();
            tabla_factura.insercion_factura_compra(textBox10.Text,label8.Text,label27.Text,label1.Text,label22.Text,lbl5.Text,label21.Text,label15.Text);
            

            for (int cont = 0; cont < dataGridView1.RowCount; cont++)
            {





               // object imagens = dataGridView1.Rows[cont].Cells[8].Value.ToString();
                //pictureBox1.Image = dataGridView1.Rows[cont].Cells[8].Value.ToString;
                 
            //pictureBox1.Image = Image.FromFile(dataGridView1.Rows[cont].Cells[8].Value.ToString());


                MemoryStream memoria = new MemoryStream();  //Crea un objeto Stream como Buffer (Datos en un espacio de memoria)
                pictureBox1.Image.Save(memoria, System.Drawing.Imaging.ImageFormat.Jpeg); //Almacena la imagen en el Buffer
                byte[] memoria_imagen = memoria.ToArray();  //Se extrae la cadena para almacenarla en una variable tipo binario
                
                                
                

                Negocios.Factura_Compra insercion_producto = new Negocios.Factura_Compra();
                insercion_producto.agregar_producto(dataGridView1.Rows[cont].Cells[0].Value.ToString(), dataGridView1.Rows[cont].Cells[1].Value.ToString(), dataGridView1.Rows[cont].Cells[2].Value.ToString(), dataGridView1.Rows[cont].Cells[3].Value.ToString(), dataGridView1.Rows[cont].Cells[4].Value.ToString(), label27.Text, dataGridView1.Rows[cont].Cells[7].Value.ToString(),memoria_imagen,dataGridView1.Rows[cont].Cells[6].Value.ToString());
                
            }

            string cod_factura = "";
            for (int cont = 0; cont < dataGridView1.RowCount; cont++)
            {
                Negocios.Factura_Compra detalles_factura = new Negocios.Factura_Compra();
                cod_factura = detalles_factura.Insercion_detalles_factura_compra(dataGridView1.Rows[cont].Cells[0].Value.ToString(), dataGridView1.Rows[cont].Cells[5].Value.ToString());
            }

            
            MessageBox.Show("Factura registrada exitosamente");
            MessageBox.Show("Codigo de factura de venta: " + cod_factura);

            int numero_factura = Int32.Parse(cod_factura);
            int codigo_factura;
            codigo_factura = numero_factura + 1;
            label9.Text = Convert.ToString(codigo_factura);
            }
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

        private void textBox_codigo_producto_Leave(object sender, EventArgs e)
        {
            try
            {
                Negocios.Factura_Compra nn = new Negocios.Factura_Compra();
                string resultado = nn.validacion_producto(textBox_codigo_producto.Text);

                if (resultado == "false")
                {
                    MessageBox.Show("el producto ya existe digite otro codigo de producto antes de continuar");
                    this.textBox_codigo_producto.Focus();

                }
                else if (resultado == "true")
                {
                    //no existe y se puede agregar uno nuevo


                }
            }
            catch(Exception){
            
            }
            
            
            
            
            }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                textBox10.Clear();
                textBox_codigo_producto.Clear();
                textBox_nombre.Clear();
                textBox_cantidad.Clear();
                textBox_precio_venta.Clear();
                textBox_iva.Clear();
                textBox_precio_de_compra.Clear();
                textBox_precio_unitario.Clear();
                dataGridView1.Rows.Clear();

                   }
            catch(Exception){
            
            }
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Observar Manual de Usuario pagina 123-130");
        }
        }
        }
    

