using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
//EQUIPO-24\\SQLEXPRESS


namespace ProyectRoque.Negocios
{
    public class Producto
    {
        public void agregar_producto(string cod_producto, string nombre, string cantidad, string precio_venta, string iva, string cod_proveedor, string forma_farmaceutica, byte[] imagen,string precio_unitario)
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
                    MessageBox.Show("El codigo del producto digitado ya existe digite un codigo del producto diferente.");
                    validacion_l.Close();

                }


                else
                {
                    validacion_l.Close();

                    SqlCommand validacion2 = new SqlCommand("validacion_campos_producto_pro", conexion);//consulta el PA el cual consultara el cod del proveedor 
                    validacion2.CommandType = CommandType.StoredProcedure;
                    validacion2.Parameters.Add("@Cod_proveedor", SqlDbType.BigInt).Value = cod_proveedor;
                    SqlDataReader validacion_2 = validacion2.ExecuteReader();
                    if (validacion_2.Read() == false)
                    {
                        MessageBox.Show("El codigo del proveedor no existe digite un codigo de proveedor existente");
                        validacion_2.Close();

                    }
                    else
                    {

                        validacion_2.Close();

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
                        MessageBox.Show("Producto Registrado Correctamente", "Registro Exitoso");

                       
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Se a Presentado un error" + e.Message);
            }


        }
        //CONSULTA DE LA IMAGEN CON PARAMETROS DE SALIDA
        public byte[] imagen_producto(string Cod_producto)
        {


            SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
            conexion.Open();
            SqlCommand consulta_imagen = new SqlCommand("Consultar_Imagen", conexion);
            consulta_imagen.CommandType = CommandType.StoredProcedure;//tipo de comando procedimiento almacenado
            consulta_imagen.Parameters.Add("@cod_Producto", SqlDbType.BigInt).Value = Cod_producto;
            consulta_imagen.Parameters.Add("@Imagen", SqlDbType.VarBinary, 1000000).Direction = ParameterDirection.Output;
            consulta_imagen.ExecuteNonQuery();

            byte[] imagen = (byte[])consulta_imagen.Parameters["@Imagen"].Value;

            conexion.Close();

            return imagen;

        }
        // CONSULTA DE PRODUCTOS POR EL CODIGO
        public DataTable consulta_productos_codigo(string codigo_producto)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();
                SqlDataAdapter consulta_producto_cod = new SqlDataAdapter("consulta_producto_codigo", conexion);
                consulta_producto_cod.SelectCommand.CommandType = CommandType.StoredProcedure;
                consulta_producto_cod.SelectCommand.Parameters.Add("@Cod_producto", SqlDbType.BigInt).Value = codigo_producto;
                consulta_producto_cod.Fill(dt);
                conexion.Close();
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
                return dt;
            }



        }
        // CONSULTA DEL PRODUCTO POR EL ESTADO 
        public DataTable consulta_producto_estado(string estado)
        {

            DataTable dt = new DataTable();

            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();
                SqlDataAdapter consulta_producto_activo = new SqlDataAdapter("consulta_producto_estado", conexion);
                consulta_producto_activo.SelectCommand.CommandType = CommandType.StoredProcedure;
                consulta_producto_activo.SelectCommand.Parameters.Add("@estado", SqlDbType.VarChar, 10).Value = estado;
                consulta_producto_activo.Fill(dt);
                conexion.Close();
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
                return dt;
            }
        }

              // CONSULTA AL PRODUCTO POR EL NOMBRE
        public DataTable consulta_producto_nombre(string nombre)
        {

            DataTable dt = new DataTable();

            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();
                SqlDataAdapter consulta_producto_nombre = new SqlDataAdapter("consulta_producto_nombre", conexion);
                consulta_producto_nombre.SelectCommand.CommandType = CommandType.StoredProcedure;
                consulta_producto_nombre.SelectCommand.Parameters.Add("@nombre_producto", SqlDbType.VarChar, 50).Value = nombre;
                consulta_producto_nombre.Fill(dt);
                conexion.Close();
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
                return dt;
            }
        }
        // CONSULTA GENERAL DEL PRODUCTO
        public DataTable consulta_producto_general(string x)
        {

            DataTable dt = new DataTable();//se define un objeto datatable con nombre dt (datatable)

            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();
                SqlDataAdapter consulta_producto_general = new SqlDataAdapter("consulta_producto_general", conexion);
                consulta_producto_general.SelectCommand.CommandType = CommandType.StoredProcedure;
                consulta_producto_general.Fill(dt);
                conexion.Close();
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
                return dt;
            }


        }
        //ACTUALIZACION DE PRODUCTOS

        public void Actualizar_producto(string cod_producto, string nombre, string cantidad, string precio_venta, string iva, string cod_proveedor, string forma_farmaceutica, byte[] imagen,string precio_unitario)
        {

            try
            {

                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();// abre la conexion 
                SqlCommand validacion = new SqlCommand("validacion_campos_producto_pro", conexion);//consulta el PA el cual consultara el cod del proveedor 
                validacion.CommandType = CommandType.StoredProcedure;
                validacion.Parameters.Add("@Cod_proveedor", SqlDbType.BigInt).Value = cod_proveedor;
                SqlDataReader validacion_1 = validacion.ExecuteReader();
                if (validacion_1.Read() == false)
                {
                    MessageBox.Show("El codigo del proveedor no existe digite un codigo de proveedor existente");
                    validacion_1.Close();

                }
                else
                {

                    validacion_1.Close();

                    SqlCommand actualizacion_producto = new SqlCommand("actualizar_producto", conexion);
                    actualizacion_producto.CommandType = CommandType.StoredProcedure;
                    actualizacion_producto.Parameters.Add("@codigo_producto", SqlDbType.BigInt).Value = cod_producto;
                    actualizacion_producto.Parameters.Add("@cantidad", SqlDbType.SmallInt).Value = cantidad;
                    actualizacion_producto.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                    actualizacion_producto.Parameters.Add("@precio_venta", SqlDbType.Int).Value = precio_venta;
                    actualizacion_producto.Parameters.Add("@iva", SqlDbType.TinyInt).Value = iva;
                    
                    actualizacion_producto.Parameters.Add("@codigo_proveedor", SqlDbType.BigInt).Value = cod_proveedor;
                    actualizacion_producto.Parameters.Add("@forma_farmaceutica", SqlDbType.VarChar, 20).Value = forma_farmaceutica;
                    actualizacion_producto.Parameters.Add("@imagen", SqlDbType.VarBinary).Value = imagen;
                    actualizacion_producto.Parameters.Add("@valor_unitario", SqlDbType.Int).Value = precio_unitario;
                    actualizacion_producto.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Producto Actualizado Correctamente", "Actualizacion Exitosa");
                }
            }


            catch (Exception e)
            {
                MessageBox.Show("Se a Presentado un error" + e.Message);
            }
        }
        public void eliminacion_producto(string estado, string codigo)
        {

            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();//abre la conexion.

                SqlCommand eliminacion = new SqlCommand("eliminar_producto", conexion);

                eliminacion.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                eliminacion.Parameters.Add("@estado", SqlDbType.VarChar, 10).Value = estado;
                eliminacion.Parameters.Add("@codigo_producto", SqlDbType.BigInt).Value = codigo;
                eliminacion.ExecuteNonQuery();
                MessageBox.Show("Producto Actualizado Correctamente");
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha Ocurrido Un Error" + e.Message);

            }

        }
        public DataTable consulta_proveedor()
        {

            DataTable dt = new DataTable();//se define un objeto datatable con nombre dt (datatable)

            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();
                SqlDataAdapter consulta = new SqlDataAdapter("consulta_proveedores", conexion);
                consulta.SelectCommand.CommandType = CommandType.StoredProcedure;
                consulta.Fill(dt);
                conexion.Close();
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
                return dt;
            }


        }
        public string consulta_cod_proveedor(string nombre)
        {

            

            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();
                SqlCommand cmd = new SqlCommand("consulta_cod", conexion);
                cmd.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;//envia el nombre del producto
                cmd.Parameters.Add("@cod", SqlDbType.BigInt).Direction = ParameterDirection.Output;// recibe el parametro de salida
                cmd.ExecuteNonQuery();

                string cod = cmd.Parameters["@cod"].Value.ToString();// asigna a la variable cantidad_productoconsultada en el procedimiento.
                return cod;
             
                
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
                return "";
            }


        }
    }
}
    
