using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectRoque.Negocios
{
    class clientes
    {
        public void creacion_cliente(string nombre, string cedula, string direccion, string telefono, string usu)
        {
            try
            {
                string estado_registro = "ACTIVO";
                string cedula_empleado;


                SqlConnection conexion = new SqlConnection(Negocios.conection.x());
                conexion.Open();
                SqlCommand cmd = new SqlCommand("regis_por", conexion);
                cmd.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usu;//envia el nombre de usuario del label
                cmd.Parameters.Add("@Cedula", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;// recibe el parametro de salida
                cmd.ExecuteNonQuery();
                cedula_empleado = cmd.Parameters["@Cedula"].Value.ToString();// asigna a la variable cedula_empleado el valor de la cedula consultada en el procedimiento.

                Convert.ToInt64(cedula_empleado);
                SqlCommand datos_cliente = new SqlCommand("creacion_cliente", conexion);
                datos_cliente.CommandType = CommandType.StoredProcedure;
                datos_cliente.Parameters.Add("@Cedula_empleado", SqlDbType.VarChar, 20).Value = cedula_empleado;
                datos_cliente.Parameters.Add("@Cedula_cliente", SqlDbType.BigInt).Value = cedula;
                datos_cliente.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                datos_cliente.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = direccion;
                datos_cliente.Parameters.Add("@estado_registro", SqlDbType.VarChar, 10).Value = estado_registro;
                datos_cliente.Parameters.Add("@telefono_cliente", SqlDbType.BigInt).Value = telefono;

                datos_cliente.ExecuteNonQuery();
                MessageBox.Show("Cliente Registrado Exitosamente ", "Registro");// se muestra un mensaje en la pantalla informando el correcto registro del nuevo cliente

                conexion.Close();

            }

            catch (Exception e)
            {
                MessageBox.Show("Se A Presentado Un Error Contacte Con Soporte Tecnico " + e.Message);



            }


        }

        public DataTable consulta_cliente_nombre(string nombre)
        {// se define el metodo tipo data table 
            DataTable consulta = new DataTable();// se define un objeti tipo data table
            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();
                SqlDataAdapter consulta_cliente_nombre = new SqlDataAdapter("consulta_cliente_nombre", conexion);
                consulta_cliente_nombre.SelectCommand.CommandType = CommandType.StoredProcedure;
                consulta_cliente_nombre.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = nombre;
                consulta_cliente_nombre.Fill(consulta);// llena los daos con la consulta en el datatable llamado consulta

                return consulta;// retorna los datos conultados
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha Ocurrido Un Error" + e.Message);
                return consulta;

            }
        }

        public DataTable consulta_cliente_cedula(string cedula)
        {// se define el metodo tipo data table 
            DataTable consulta = new DataTable();// se define un objeti tipo data table
            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();
                SqlDataAdapter consulta_cliente_cedula = new SqlDataAdapter("consulta_cliente_cedula", conexion);
                consulta_cliente_cedula.SelectCommand.CommandType = CommandType.StoredProcedure;
                consulta_cliente_cedula.SelectCommand.Parameters.Add("@Cedula", SqlDbType.BigInt).Value = cedula;
                consulta_cliente_cedula.Fill(consulta);// llena los daos con la consulta en el datatable llamado consulta

                return consulta;// retorna los datos conultados
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha Ocurrido Un Error" + e.Message);
                return consulta;

            }
        }

        public DataTable consulta_cliente_general(string x)
        {// se define el metodo tipo data table 
            DataTable consulta = new DataTable();// se define un objeti tipo data table
            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();
                SqlDataAdapter consulta_cliente_general = new SqlDataAdapter("consulta_general_cliente", conexion);

                consulta_cliente_general.Fill(consulta);// llena los daos con la consulta en el datatable llamado consulta

                return consulta;// retorna los datos conultados
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha Ocurrido Un Error" + e.Message);
                return consulta;

            }



        }

        public void actualizar_cliente(string nombre, string cedula, string direccion, string telefono)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();
                SqlCommand actualizacion = new SqlCommand("actualizar_cliente", conexion);
                actualizacion.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                actualizacion.Parameters.Add("@cedula", SqlDbType.BigInt).Value = cedula;
                actualizacion.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                actualizacion.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = direccion;
                actualizacion.Parameters.Add("@telefono", SqlDbType.BigInt).Value = telefono;
                actualizacion.ExecuteNonQuery();
                MessageBox.Show("Actualizacion Concluida");
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha Ocurrido Un Error" + e.Message);


            }
        }

        public void eliminacion_cliente(string estado, string cedula)
        {

            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();//abre la conexion.

                SqlCommand eliminacion = new SqlCommand("eliminar_cliente", conexion);

                eliminacion.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                eliminacion.Parameters.Add("@estado", SqlDbType.VarChar, 10).Value = estado;
                eliminacion.Parameters.Add("@cedula", SqlDbType.VarChar, 20).Value = cedula;
                eliminacion.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha Ocurrido Un Error" + e.Message);

            }

        }
        public string validacion_cedula_cliente(string cedula)//metodo
        {

            try
            {

                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();// abre la conexion 
                SqlCommand validacion = new SqlCommand("validacion_cedula_cliente", conexion);
                validacion.CommandType = CommandType.StoredProcedure;
                validacion.Parameters.Add("@cedula", SqlDbType.BigInt).Value = cedula;
                SqlDataReader reader = validacion.ExecuteReader();

                if (reader.Read() == true)
                {
                    reader.Close();
                    conexion.Close();
                    return "false";
                   

                }
                else if (reader.Read() == false)
                {
                    reader.Close();
                    conexion.Close();
                    return "true";
                }
            }
            catch (Exception)
            {
                return "";

            }
            return "";
        }
    }
}
