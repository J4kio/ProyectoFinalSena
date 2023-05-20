using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ProyectRoque.Negocios
{
    class Factura_Compra
    {

        public string consulta_cod()
        {

            SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
            conexion.Open();// abre la conexion 
            SqlCommand cod = new SqlCommand("consulta_codigo_factura_compra", conexion);//nombre del procedimiento almacenado para consultar el precio unitario de productos
            cod.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
            cod.Parameters.Add("@codigo_factura", SqlDbType.BigInt).Direction = ParameterDirection.Output;// recibe el parametro de salida
            cod.ExecuteNonQuery();

            string codigo_factura = cod.Parameters["@codigo_factura"].Value.ToString();// asigna a la variable el procedimiento.
            return codigo_factura;

        }

        public void insercion_factura_compra(string cod_factura, string cedula, string cod_proveedor, string cantidad_productos, string subtotal, string valor_total, string fecha, string fecha_hora)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();// abre la conexion 

                SqlCommand cmd = new SqlCommand("insercion_factura_compra", conexion);//nombre del procedimiento almacenado para consultar la cantidad de productos
                cmd.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                cmd.Parameters.Add("@cod_factura_compra", SqlDbType.VarChar, 100).Value = cod_factura;
                cmd.Parameters.Add("@cedula_empleado", SqlDbType.VarChar, 20).Value = cedula;
                cmd.Parameters.Add("@cod_proveedor", SqlDbType.BigInt).Value = cod_proveedor;
                cmd.Parameters.Add("@cantidad_productos", SqlDbType.SmallInt).Value = cantidad_productos;
                cmd.Parameters.Add("@subtotal", SqlDbType.Int).Value = subtotal;
                cmd.Parameters.Add("@valor_total", SqlDbType.Int).Value = valor_total;
                cmd.Parameters.Add("@fecha_hora", SqlDbType.SmallDateTime).Value = fecha_hora;
                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Se a presentado un error contacte con su programador" + e);

            }
        }

        public string Insercion_detalles_factura_compra(string codigo_producto, string precio_compra)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();// abre la conexion 
                SqlCommand cod = new SqlCommand("consulta_codigo_factura_compra", conexion);//nombre del procedimiento almacenado para consultar el precio unitario de productos
                cod.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                cod.Parameters.Add("@codigo_factura", SqlDbType.BigInt).Direction = ParameterDirection.Output;// recibe el parametro de salida
                cod.ExecuteNonQuery();

                string codigo_factura = cod.Parameters["@codigo_factura"].Value.ToString();// asigna a la variable el procedimiento.




                SqlCommand cmd = new SqlCommand("insercion_detalles_factura_compra", conexion);//nombre del procedimiento almacenado para consultar la cantidad de productos
                cmd.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                cmd.Parameters.Add("@Cod_factura_compra", SqlDbType.BigInt).Value = codigo_factura;
                cmd.Parameters.Add("@Cod_producto", SqlDbType.BigInt).Value = codigo_producto;
                cmd.Parameters.Add("@precio_compra", SqlDbType.Int).Value = precio_compra;
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
        public void agregar_producto(string cod_producto, string nombre, string cantidad, string precio_venta, string iva, string cod_proveedor, string forma_farmaceutica, byte[] imagen, string precio_unitario)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();// abre la conexion 

                string estado_registro = "ACTIVO";

                SqlCommand creacion_producto = new SqlCommand("insertar_producto", conexion);
                creacion_producto.CommandType = CommandType.StoredProcedure;
                creacion_producto.Parameters.Add("@codigo_producto", SqlDbType.BigInt).Value = cod_producto;
                creacion_producto.Parameters.Add("@cantidad", SqlDbType.SmallInt).Value = cantidad;
                creacion_producto.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                creacion_producto.Parameters.Add("@precio_venta", SqlDbType.Int).Value = precio_venta;
                creacion_producto.Parameters.Add("@iva", SqlDbType.TinyInt).Value = iva;
                creacion_producto.Parameters.Add("@codigo_proveedor", SqlDbType.BigInt).Value = cod_proveedor;
                creacion_producto.Parameters.Add("@estado_registro", SqlDbType.VarChar, 10).Value = estado_registro;
                creacion_producto.Parameters.Add("@forma_farmaceutica", SqlDbType.VarChar, 20).Value = forma_farmaceutica;
                creacion_producto.Parameters.Add("@imagen", SqlDbType.VarBinary).Value = imagen;
                creacion_producto.Parameters.Add("@valor_unitario", SqlDbType.Int).Value = precio_unitario;
                creacion_producto.ExecuteNonQuery();
                conexion.Close();
                //  MessageBox.Show("Producto Registrado Correctamente", "Registro Exitoso");
            }
            catch(Exception e) {
                MessageBox.Show("Se a presentado un error "+e.Message);
            
            }


        }
        public string validacion_producto(string cod_producto)
        {
            // METODO PARA LA VALIDACION DE CAMPOS
            try
            {

                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();// abre la conexion 
                SqlCommand validacion = new SqlCommand("validacion_campos_producto_cod", conexion);
                validacion.CommandType = CommandType.StoredProcedure;
                validacion.Parameters.Add("@Cod_producto", SqlDbType.BigInt).Value = cod_producto;
                //validacion.Parameters.Add("@Cod_proveedor", SqlDbType.BigInt).Value = cod_proveedor;
                SqlDataReader validacion_l = validacion.ExecuteReader();

                if (validacion_l.Read() == true)
                {

                    validacion_l.Close();
                    return "false";


                }


                else
                {
                    
                    if (validacion_l.Read() == false)
                    {
                        validacion_l.Close();
                        return "true";
                       
                        
                    }
                   
                }

            }
            catch (Exception )
            {
                //MessageBox.Show("Se a Presentado un error" + e.Message);
                return "";
            }
            return "";
        }

        public DataTable consulta_factura_fecha(string fecha)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();//abre la conexion.
                SqlDataAdapter consulta_factura = new SqlDataAdapter("consulta_factura_compra_fecha", conexion);
                consulta_factura.SelectCommand.CommandType = CommandType.StoredProcedure;
                consulta_factura.SelectCommand.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;
                consulta_factura.Fill(dt);
                return dt;

            }
            catch (Exception e)
            {
                MessageBox.Show("Se ha presentado un error contante con soporte tecnico" + e.Message);
                return dt;

            }
        }

        public DataTable consulta_factura_cod(string cod)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();//abre la conexion.
                SqlDataAdapter consulta_factura = new SqlDataAdapter("consulta_factura_compra_cod", conexion);
                consulta_factura.SelectCommand.CommandType = CommandType.StoredProcedure;
                consulta_factura.SelectCommand.Parameters.Add("@cod_factura", SqlDbType.BigInt).Value = cod;
                consulta_factura.Fill(dt);
                return dt;

            }
            catch (Exception e)
            {
                MessageBox.Show("Se ha presentado un error contante con soporte tecnico" + e.Message);
                return dt;

            }
        }


        public DataTable consulta_factura_codigo_proveedor(string cod_proveedor)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();//abre la conexion.
                SqlDataAdapter consulta_factura = new SqlDataAdapter("consulta_factura_compra_cod_proveedor", conexion);
                consulta_factura.SelectCommand.CommandType = CommandType.StoredProcedure;
                consulta_factura.SelectCommand.Parameters.Add("@cod_factura", SqlDbType.VarChar,100).Value = cod_proveedor;
                consulta_factura.Fill(dt);
                return dt;

            }
            catch (Exception e)
            {
                MessageBox.Show("Se ha presentado un error contante con soporte tecnico" + e.Message);
                return dt;

            }
        }

        public DataTable consulta_factura_cedula(string cedula)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();//abre la conexion.
                SqlDataAdapter consulta_factura = new SqlDataAdapter("consulta_factura_compra_cedula", conexion);
                consulta_factura.SelectCommand.CommandType = CommandType.StoredProcedure;
                consulta_factura.SelectCommand.Parameters.Add("@cedula", SqlDbType.VarChar, 20).Value = cedula;
                consulta_factura.Fill(dt);
                return dt;

            }
            catch (Exception e)
            {
                MessageBox.Show("Se ha presentado un error contante con soporte tecnico" + e.Message);
                return dt;

            }
        }


        public DataTable consulta_factura_por_cod_proveedor(string cod_proveedor)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();//abre la conexion.
                SqlDataAdapter consulta_factura = new SqlDataAdapter("consulta_factura_compra_codigo_del_proveedor", conexion);
                consulta_factura.SelectCommand.CommandType = CommandType.StoredProcedure;
                consulta_factura.SelectCommand.Parameters.Add("@cod", SqlDbType.BigInt).Value = cod_proveedor;
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
                SqlDataAdapter consulta_factura = new SqlDataAdapter("consulta_detalles_factura_compra", conexion);
                consulta_factura.SelectCommand.CommandType = CommandType.StoredProcedure;
                consulta_factura.SelectCommand.Parameters.Add("@cod", SqlDbType.BigInt).Value = codigo;
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

