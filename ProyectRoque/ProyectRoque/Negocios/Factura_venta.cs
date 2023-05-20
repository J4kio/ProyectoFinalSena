using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ProyectRoque.Negocios
{
    class Factura_venta
    {

        DataSet2 datos = new DataSet2();

        public DataSet envio_datos(string cod, string nombre_cliente, string iva_total, string fecha, string valor_total, string cedula_cliente, string cantidad_productos, string subtotal, string codigo_producto, string nombre, string cantidad, string iva, string total,string precio_unitario)
        {
           // DataSet1.datatable_facturaRow filas = datos.datatable_factura.Newdatatable_facturaRow();
            DataSet2.FacturaRow filas = datos.Factura.NewFacturaRow();
            filas.Codigo_factura_venta = cod;
            filas.Nombre_cliente = nombre_cliente;
            filas.Iva_total = iva_total;
            filas.Fecha_hora = fecha;
            filas.Valor_total = valor_total;
            filas.Cedula_Cliente = cedula_cliente;
            filas.Cantidad_productos = cantidad_productos;
            filas.Subtotal = subtotal;
            filas.Cod_producto = codigo_producto;
            filas.Nombre = nombre;
            filas.Cantidad = cantidad;
            filas.Iva = iva;
            filas.Precio_unitario = precio_unitario;
            filas.Total = total;
            datos.Factura.Rows.Add(filas);

            return datos;

        }
         
        public DataTable Lista(string forma_farmaceutica)
        {
            SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
            conexion.Open();// abre la conexion 
            SqlCommand cmd = new SqlCommand("Consulta_Columna_Productos", conexion);//nombre del procedimiento almacenado para consultar la cantidad de productos
            cmd.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
            cmd.Parameters.Add("@forma_farmaceutica", SqlDbType.VarChar, 20).Value = forma_farmaceutica;//envia el nombre del producto
            cmd.ExecuteNonQuery();
            SqlDataAdapter consulta = new SqlDataAdapter(cmd);
            consulta.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable matriz = new DataTable();
            consulta.Fill(matriz);
            return matriz;
        }


        public string cantidad(string nombre)
        {
            SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
            conexion.Open();// abre la conexion 
            SqlCommand cmd = new SqlCommand("Consulta_Cantidad_Productos", conexion);//nombre del procedimiento almacenado para consultar la cantidad de productos
            cmd.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;//envia el nombre del producto
            cmd.Parameters.Add("@cantidad", SqlDbType.SmallInt).Direction = ParameterDirection.Output;// recibe el parametro de salida
            cmd.ExecuteNonQuery();

            string cantidad_producto = cmd.Parameters["@cantidad"].Value.ToString();// asigna a la variable cantidad_productoconsultada en el procedimiento.
            return cantidad_producto;
        }
        public string precio_unitario(string nombre)
        {
            SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
            conexion.Open();// abre la conexion 
            SqlCommand cmd = new SqlCommand("Consulta_precio_unitario_Productos", conexion);//nombre del procedimiento almacenado para consultar el precio unitario de productos
            cmd.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;//envia el nombre del producto
            cmd.Parameters.Add("@precio_unitario", SqlDbType.Int).Direction = ParameterDirection.Output;// recibe el parametro de salida
            cmd.ExecuteNonQuery();

            string precio_unitario = cmd.Parameters["@precio_unitario"].Value.ToString();// asigna a la variable cantidad_productoconsultada en el procedimiento.
            return precio_unitario;
        }
        public string iva(string nombre)
        {
            SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
            conexion.Open();// abre la conexion 
            SqlCommand cmd = new SqlCommand("Consulta_iva_Productos", conexion);//nombre del procedimiento almacenado para consultar el precio unitario de productos
            cmd.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;//envia el nombre del producto
            cmd.Parameters.Add("@iva", SqlDbType.TinyInt).Direction = ParameterDirection.Output;// recibe el parametro de salida
            cmd.ExecuteNonQuery();

            string iva = cmd.Parameters["@iva"].Value.ToString();// asigna a la variable cantidad_productoconsultada en el procedimiento.
            return iva;
        }
        public string cedula_cliente(string cedula_cliente)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();// abre la conexion 
                SqlCommand cmd = new SqlCommand("Consulta_cliente", conexion);
                cmd.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                cmd.Parameters.Add("@cedula", SqlDbType.BigInt).Value = cedula_cliente;//envia la cedula del cliente
                SqlDataReader dtr = cmd.ExecuteReader();
                if (dtr.Read() == true)
                {

                    return "true";

                }
                else
                {
                    if (dtr.Read() == false)
                    {

                        return "false";

                    }


                    else
                    {

                        MessageBox.Show("Error de digitacion");
                    }
                }
            }
            catch(Exception e ){
                MessageBox.Show("Se a presentado un error contacte con soporte tecnico." + e);
            
            }
            return cedula_cliente;
        }
        public string nombre_cliente(string cedula)
        {
            SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
            conexion.Open();// abre la conexion 
            SqlCommand cmd = new SqlCommand("Consulta_nombre_cliente", conexion);//nombre del procedimiento almacenado para consultar la cantidad de productos
            cmd.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
            cmd.Parameters.Add("@cedula", SqlDbType.BigInt).Value = cedula;//envia el nombre del producto
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;// recibe el parametro de salida
            cmd.ExecuteNonQuery();

            string nombre = cmd.Parameters["@nombre"].Value.ToString();// asigna a la variable cantidad_productoconsultada en el procedimiento.
            return nombre;
        }
        //PARA CONSULTAR LA CEDULA DEL EMPLEADO
        public string cedula_empleado(string usu)
        {
            SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
            conexion.Open();// abre la conexion 
            string cedula_empleado;
            SqlCommand cmd = new SqlCommand("regis_por", conexion);//nombre del procedimiento almacenado para consultar la cedula del usuario
            cmd.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usu;//envia el nombre de usuario del label
            cmd.Parameters.Add("@Cedula", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;// recibe el parametro de salida
            cmd.ExecuteNonQuery();
            cedula_empleado = cmd.Parameters["@Cedula"].Value.ToString();// asigna a la variable cedula_empleado el valor de la cedula consultada en el procedimiento.
            //Convert.ToInt64(cedula_empleado);// se combierte el valor a entero ya que viene en string.
            return cedula_empleado;
        }
        public string codigo_producto(string nombre, string forma_farmaceutica)
        {
            SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
            conexion.Open();// abre la conexion 
            SqlCommand cmd = new SqlCommand("Consulta_codigo_Producto", conexion);//nombre del procedimiento almacenado para consultar la cantidad de productos
            cmd.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
            cmd.Parameters.Add("@forma_farmaceutica", SqlDbType.VarChar, 20).Value = forma_farmaceutica;//envia la forma farmaceutica del producto
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;//envia el nombre del producto
            cmd.Parameters.Add("@codigo", SqlDbType.BigInt).Direction = ParameterDirection.Output;// recibe el parametro de salida
            cmd.ExecuteNonQuery();

            string codigo_producto = cmd.Parameters["@codigo"].Value.ToString();// asigna a la variable codigo_producto consultada en el procedimiento.
            return codigo_producto;
        }
        public void Insercion_factura_venta(string cedula_empleado, string iva_total, string fecha_hora,string fecha, string cantidad_total, string cedula_cliente, string total)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();// abre la conexion 
                SqlCommand cmd = new SqlCommand("insercion_factura_venta", conexion);//nombre del procedimiento almacenado para consultar la cantidad de productos
                cmd.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                cmd.Parameters.Add("@cedula_empleado", SqlDbType.VarChar, 20).Value = cedula_empleado;
                cmd.Parameters.Add("@iva_total", SqlDbType.Int).Value = iva_total;
                cmd.Parameters.Add("@fecha_hora", SqlDbType.SmallDateTime).Value = fecha_hora;
                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;
                cmd.Parameters.Add("@valor_total", SqlDbType.Int).Value = total;
                cmd.Parameters.Add("@cantidad_productos", SqlDbType.Int).Value = cantidad_total;
                cmd.Parameters.Add("@cedula_cliente", SqlDbType.BigInt).Value = cedula_cliente;
                cmd.ExecuteNonQuery();



            }
            catch (Exception e)
            {
                MessageBox.Show("Se presento un error,comuniquese con soporte tecnico" + e.Message);// imprime el error en un message box pero en forma corta por el "Message"
            }
        }
        public string Insercion_detalles_factura_venta(string codigo_producto, string cantidad_producto, string precio_total_producto, string iva)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();// abre la conexion 
                SqlCommand cod = new SqlCommand("consulta_codigo_factura_venta", conexion);//nombre del procedimiento almacenado para consultar el precio unitario de productos
                cod.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                cod.Parameters.Add("@codigo_factura", SqlDbType.BigInt).Direction = ParameterDirection.Output;// recibe el parametro de salida
                cod.ExecuteNonQuery();

                string codigo_factura = cod.Parameters["@codigo_factura"].Value.ToString();// asigna a la variable el procedimiento.


                

                SqlCommand cmd = new SqlCommand("insertar_detalles_factura_venta", conexion);//nombre del procedimiento almacenado para consultar la cantidad de productos
                cmd.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                cmd.Parameters.Add("@codigo_factura_venta", SqlDbType.BigInt).Value = codigo_factura;
                cmd.Parameters.Add("@codigo_producto", SqlDbType.BigInt).Value = codigo_producto;
                cmd.Parameters.Add("@cantidad_producto", SqlDbType.Int).Value = cantidad_producto;
                cmd.Parameters.Add("@precio_total", SqlDbType.Int).Value = precio_total_producto;
                cmd.Parameters.Add("@iva", SqlDbType.TinyInt).Value = iva;
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Factura registrada exitosamente");
                return codigo_factura;

            }
            catch (Exception e)
            {
                MessageBox.Show("Se presento un error,comuniquese con soporte tecnico" + e.Message);// imprime el error en un message box pero en forma corta por el "Message"
                return "";
            }
        }
        public string consulta_cod()
        {

            SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
            conexion.Open();// abre la conexion 
            SqlCommand cod = new SqlCommand("consulta_codigo_factura_venta", conexion);//nombre del procedimiento almacenado para consultar el precio unitario de productos
            cod.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
            cod.Parameters.Add("@codigo_factura", SqlDbType.BigInt).Direction = ParameterDirection.Output;// recibe el parametro de salida
            cod.ExecuteNonQuery();

            string codigo_factura = cod.Parameters["@codigo_factura"].Value.ToString();// asigna a la variable el procedimiento.
            return codigo_factura;

        }
        public void actualizacion_productos(string codigo_producto, string cantidad)
        {
            try
            {


                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();// abre la conexion 

                SqlCommand cmd = new SqlCommand("consulta_cantidad_cod", conexion);//nombre del procedimiento almacenado para consultar la cantidad de productos
                cmd.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                cmd.Parameters.Add("@cod", SqlDbType.BigInt).Value = codigo_producto;//envia el nombre del producto
                cmd.Parameters.Add("@cantidad", SqlDbType.SmallInt).Direction = ParameterDirection.Output;// recibe el parametro de salida
                cmd.ExecuteNonQuery();

              int  cantidad_producto = Convert.ToInt32( cmd.Parameters["@cantidad"].Value.ToString());// asigna a la variable cantidad_productoconsultada en el procedimiento.
                int total = 0;
                int Cantidad = Convert.ToInt32(cantidad);
                total = cantidad_producto - Cantidad;


                SqlCommand cmd2 = new SqlCommand("actualizar_cantidad", conexion);//nombre del procedimiento almacenado para consultar la cantidad de productos
                cmd2.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                cmd2.Parameters.Add("@cod_producto", SqlDbType.BigInt).Value = codigo_producto;
                cmd2.Parameters.Add("@cantidad_producto", SqlDbType.SmallInt).Value = total;

                cmd2.ExecuteNonQuery();



            }
            catch (Exception e)
            {
                MessageBox.Show("Se presento un error,comuniquese con soporte tecnico" + e.Message);// imprime el error en un message box pero en forma corta por el "Message"
            }
        }
        public DataTable consulta_factura(string codigo) {
            DataTable dt = new DataTable();
            try {

                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();//abre la conexion.
                SqlDataAdapter consulta_factura = new SqlDataAdapter("consulta_factura_venta", conexion);
                consulta_factura.SelectCommand.CommandType = CommandType.StoredProcedure;
                consulta_factura.SelectCommand.Parameters.Add("@codigo", SqlDbType.BigInt).Value = codigo;
                consulta_factura.Fill(dt);
                return dt;

            }
            catch (Exception e)
            {
                MessageBox.Show("Se ha presentado un error contante con soporte tecnico" + e.Message);
                return dt;
                
            }
        }
        public DataTable consulta_factura_fecha(string fecha)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();//abre la conexion.
                SqlDataAdapter consulta_factura = new SqlDataAdapter("consulta_factura_venta_fecha", conexion);
                consulta_factura.SelectCommand.CommandType = CommandType.StoredProcedure;
                consulta_factura.SelectCommand.Parameters.Add("@fecha", SqlDbType.Date).Value =fecha;
                consulta_factura.Fill(dt);
                return dt;

            }
            catch (Exception e)
            {
                MessageBox.Show("Se ha presentado un error contante con soporte tecnico" + e.Message);
                return dt;

            }
        }
        public DataTable consulta_factura_cedula_cliente(string cedula_cliente)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();//abre la conexion.
                SqlDataAdapter consulta_factura = new SqlDataAdapter("consulta_factura_venta_cedula_cliente", conexion);
                consulta_factura.SelectCommand.CommandType = CommandType.StoredProcedure;
                consulta_factura.SelectCommand.Parameters.Add("@cedula_cliente", SqlDbType.BigInt).Value = cedula_cliente;
                consulta_factura.Fill(dt);
                return dt;

            }
            catch (Exception e)
            {
                MessageBox.Show("Se ha presentado un error contante con soporte tecnico" + e.Message);
                return dt;

            }
        }
        public DataTable consulta_factura_cedula_empleado(string cedula_empleado)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();//abre la conexion.
                SqlDataAdapter consulta_factura = new SqlDataAdapter("consulta_factura_venta_cedula_empleado", conexion);
                consulta_factura.SelectCommand.CommandType = CommandType.StoredProcedure;
                consulta_factura.SelectCommand.Parameters.Add("@cedula_empleado", SqlDbType.VarChar,50).Value = cedula_empleado;
                consulta_factura.Fill(dt);
                return dt;

            }
            catch (Exception e)
            {
                MessageBox.Show("Se ha presentado un error contante con soporte tecnico" + e.Message);
                return dt;

            }
        }
        public DataTable consulta_detalles_factura(string codigo)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();//abre la conexion.
                SqlDataAdapter consulta_factura = new SqlDataAdapter("consulta_detalles_factura_venta", conexion);
                consulta_factura.SelectCommand.CommandType = CommandType.StoredProcedure;
                consulta_factura.SelectCommand.Parameters.Add("@codigo", SqlDbType.BigInt).Value = codigo;
                consulta_factura.Fill(dt);
                return dt;

            }
            catch (Exception e)
            {
                MessageBox.Show("Se ha presentado un error contante con soporte tecnico" + e.Message);
                return dt;

            }
        }
    }
}

