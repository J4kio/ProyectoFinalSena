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
    class Proveedor
    {

        public void creacion_proveedor(string cod_proveedor, string nombre, string direccion, string correo, string telefono,string usuario)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();// abre la conexion 

                // Validacion del codigo del proveedor
                SqlCommand validacion = new SqlCommand("validacion_campos_producto_pro", conexion);
                validacion.CommandType = CommandType.StoredProcedure;
                validacion.Parameters.Add("@Cod_proveedor", SqlDbType.BigInt).Value = cod_proveedor;
                SqlDataReader validacion_l = validacion.ExecuteReader();

                if (validacion_l.Read() == true)
                {
                    MessageBox.Show("El codigo del proveedor digitado ya existe digite uno diferente");
                    validacion_l.Close();

                }
                else
                {
                    validacion_l.Close();

                    //Validacion del nombre
                    SqlCommand validacion_n = new SqlCommand("validacion_nombre", conexion);
                validacion_n.CommandType = CommandType.StoredProcedure;
                validacion_n.Parameters.Add("@nombre", SqlDbType.VarChar,50).Value = nombre;
                SqlDataReader validacion_2 = validacion_n.ExecuteReader();

                if (validacion_2.Read() == true)
                {
                    MessageBox.Show("El Nombre del proveedor digitado ya existe digite uno diferente");
                    validacion_2.Close();

                }
                else
                {
                    validacion_2.Close();


                    string cedula_empleado;
                    SqlCommand cmd = new SqlCommand("regis_por", conexion);//nombre del procedimiento almacenado para consultar la cedula del empleado
                    cmd.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;//envia el nombre de usuario del label
                    cmd.Parameters.Add("@Cedula", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;// recibe el parametro de salida
                    cmd.ExecuteNonQuery();
                    cedula_empleado = cmd.Parameters["@Cedula"].Value.ToString();// asigna a la variable cedula_empleado el valor de la cedula consultada en el procedimiento.
                    Convert.ToInt64(cedula_empleado);
                    string estado_registro = "ACTIVO";

                    SqlCommand creacion_proveedor = new SqlCommand("creacion_proveedor", conexion);
                    creacion_proveedor.CommandType = CommandType.StoredProcedure;
                    creacion_proveedor.Parameters.Add("@cod_proveedor", SqlDbType.BigInt).Value = cod_proveedor;
                    creacion_proveedor.Parameters.Add("@cedula_empleado ", SqlDbType.VarChar, 20).Value = cedula_empleado;
                    creacion_proveedor.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                    creacion_proveedor.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = direccion;
                    creacion_proveedor.Parameters.Add("@correo", SqlDbType.VarChar, 50).Value = correo;
                    creacion_proveedor.Parameters.Add("@estado_registro", SqlDbType.VarChar, 10).Value = estado_registro;
                    creacion_proveedor.Parameters.Add("@telefono", SqlDbType.BigInt).Value = telefono;
                    creacion_proveedor.ExecuteNonQuery();

                    conexion.Close();
                    MessageBox.Show("Proveedor Registrado Correctamente", "Registro Exitoso");
                }
            }
            }
            catch (Exception e)
            {
                MessageBox.Show("Se presento un error,comuniquese con soporte tecnico" + e.Message);

            }
        
        }
        
    



        public DataTable consulta_proveedor(string Nombre_proveedor)
        {
            DataTable np = new DataTable();// crea un objeto tipo datatable llamado nn.
            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();
                SqlDataAdapter consulta_proveedor = new SqlDataAdapter("consulta_proveedor", conexion);//para consultar los datos
                consulta_proveedor.SelectCommand.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado
                consulta_proveedor.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = Nombre_proveedor;//envia a la varible del procedimiento de sql "@cedula" el valor de la variable"cedula"

                consulta_proveedor.Fill(np);//llena con los datos de consulta empleado el datatable nn.
                conexion.Close();
                return np;

            }
            catch(Exception) {
                MessageBox.Show("Diligencie el dato antes de continuar.");
            
            }

            return np;
        }


        public DataTable consulta_proveedor_codigo(string Codigo_proveedor)
        {
            DataTable cp = new DataTable();// crea un objeto tipo datatable llamado nn.
            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();
                SqlDataAdapter consulta_proveedor = new SqlDataAdapter("consulta_proveedor_codigo", conexion);//para consultar los datos
                consulta_proveedor.SelectCommand.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado
                consulta_proveedor.SelectCommand.Parameters.Add("@Codigo", SqlDbType.BigInt).Value = Codigo_proveedor;//envia a la varible del procedimiento de sql "@codigo" el valor de la variable"cedula"
                
                consulta_proveedor.Fill(cp);//llena con los datos de consulta empleado el datatable nn.
                conexion.Close();
                return cp;

            }
            catch(Exception) {
                MessageBox.Show("Diligencie el dato antes de continuar.");
            
            }
            return cp;

        }
        public DataTable consulta_proveedor_general(string x)
        {

            SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
            conexion.Open();

            SqlDataAdapter consulta_proveedor = new SqlDataAdapter("consulta_proveedor_general", conexion);//para consultar los datos
            DataTable xx = new DataTable();// crea un objeto tipo datatable llamado xx.
            consulta_proveedor.Fill(xx);//llena con los datos de consulta empleado el datatable xx.
            conexion.Close();
            return xx;



        }


        public void actualizacion_proveedor(string codigo_proveedor, string nombre, string direccion, string correo)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();//abre la conexion.

                SqlCommand actualizacion = new SqlCommand("actualizar_proveedor", conexion);

                actualizacion.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                actualizacion.Parameters.Add("@codigo_proveedor", SqlDbType.BigInt).Value = codigo_proveedor;
                actualizacion.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                actualizacion.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = direccion;
                actualizacion.Parameters.Add("@correo", SqlDbType.VarChar, 50).Value = correo;
                
                actualizacion.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha Ocurrido Un Error" + e.Message);

            }

        }
        public void eliminacion_proveedor(string estado, string codigo_proveedor)
        {

            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();//abre la conexion.

                SqlCommand eliminacion = new SqlCommand("eliminar_proveedor", conexion);

                eliminacion.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                eliminacion.Parameters.Add("@estado", SqlDbType.VarChar, 10).Value = estado;
                eliminacion.Parameters.Add("@codigo_proveedor", SqlDbType.BigInt).Value = codigo_proveedor;
                eliminacion.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha Ocurrido Un Error" + e.Message);

            }

        }
    }
}