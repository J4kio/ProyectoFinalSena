using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Net.Mail;
//EQUIPO-24\\SQLEXPRESS

namespace ProyectRoque.Negocios
{
    class Empleado
    {
        string PARA;
        string MENSAJE;
        MailMessage mail;
        string CONTRASENA;
        string DE;


        public void creacion_empleado(string usuario, string cedula, string nombre, string cargo, string direccion, string correo, string observaciones, string fecha, string usu, string telefono)//metodo
        {

            try
            {

                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();// abre la conexion 
             
                   
                    string estado_registro = "ACTIVO";

                    Random aleatorio = new Random();// se crea un objeto tipo aleatorio
                    string clave = "";
                    string[] vals = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };//caracteres que seran usados en la contraseña aleatoria
                    for (int i = 1; i <= 5; i++)// se crea una sentencia repetitiva hasta que la contraseña contenga 5 caracteres
                    {
                        clave = clave + vals[aleatorio.Next(vals.GetUpperBound(0) + 1)];
                    }
                    Convert.ToInt64(cedula);

                    //para consultar la cedula ya que para la creacion de un empleado hay un campo llamado "registrado por" en el cual ira la cedula.
                    string regis_por;
                    SqlCommand cmd = new SqlCommand("regis_por", conexion);//nombre del procedimiento almacenado para consultar la cedula del usuario
                    cmd.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usu;//envia el nombre de usuario del label
                    cmd.Parameters.Add("@Cedula", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;// recibe el parametro de salida
                    cmd.ExecuteNonQuery();
                    regis_por = cmd.Parameters["@Cedula"].Value.ToString();// asigna a la variable regis_por el valor de la cedula consultada en el procedimiento.
                    Convert.ToInt64(regis_por);// se combierte el valor a entero ya que viene en string.

                    //para enviar los datos a la tabla Empleado






                    //ENVÍO DE CORREO ELECTRÓNICO
                    PARA = correo; //Los mensajes llegarán a este correo
                    MENSAJE = "Bienvenido a proyectroque tu nombre de usuario es: " + usuario + " Y tu contraseña es: " +clave +" No olvides cambiarla al ingresar al sistema.";
                    mail = new MailMessage();
                    mail.To.Add(new MailAddress(this.PARA));
                    mail.From = new MailAddress("sanroquedrogueria@gmail.com"); //Debe ingresarse el E-mail remitente
                    mail.Subject = "Contraseña Del Sistema"; //Asunto del mensaje, en este caso el objeto Label lbl1
                    mail.Body = MENSAJE; //El cuerpo del mensaje Mail es el contenido de la variable MENSAJE
                    mail.IsBodyHtml = false;
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //PROTOCOLO DE TRANSFERENCIA DE DATOS MAIL
                    //SMTP: smtp.live.com HOTMAIL Si el mensaje es emitido desde hotmail, es empleado el smtp live
                    //SMTP: smtp.mail.yahoo.com YAHOO Si el mensaje es emitido desde yahoo, es empleado el smtp mail.yahoo
                    //SMTP: smtp.gmail.com GMAIL Si el mensaje es emitido desde gmail, es empleado el smtp gmail
                    DE = "sanroquedrogueria@gmail.com"; //Cuenta de correo desde donde es emitido el mensaje
                    CONTRASENA = "metallica123"; //Contraseña del correo electrónico desde donde es emitido el mensaje
                    using (client) //Se brindan permisos para acceder a la cuenta de correo electrónico y enviar el mensaje
                    {
                        client.Credentials = new System.Net.NetworkCredential(this.DE, this.CONTRASENA);
                        client.EnableSsl = true;
                        client.Send(mail);
                        //Mensaje de notificación de envio del mensaje
                        MessageBox.Show("Mensaje de confirmación enviado", "Envio de notificaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Empleado Registrado Existosamente, Revise su correo para visualizar su clave de acceso al sitema ", "Registro");

                    }



                    SqlCommand datos_empleado = new SqlCommand("datos_empleado", conexion);// objeto tipo sqlcommand para la actualizacion,insercion o actualizacion.
                    datos_empleado.CommandType = CommandType.StoredProcedure;
                    datos_empleado.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = usuario;
                    datos_empleado.Parameters.Add("@cedula", SqlDbType.VarChar, 20).Value = cedula;
                    datos_empleado.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                    datos_empleado.Parameters.Add("@tipo_empleado", SqlDbType.VarChar, 30).Value = cargo;
                    datos_empleado.Parameters.Add("@registrado_por", SqlDbType.VarChar, 20).Value = regis_por;
                    datos_empleado.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = direccion;
                    datos_empleado.Parameters.Add("@correo", SqlDbType.VarChar, 50).Value = correo;
                    datos_empleado.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = clave;
                    datos_empleado.Parameters.Add("@observaciones", SqlDbType.VarChar, 8000).Value = observaciones;
                    datos_empleado.Parameters.Add("@fecha_registro", SqlDbType.SmallDateTime).Value = fecha;
                    datos_empleado.Parameters.Add("@telefono", SqlDbType.BigInt).Value = telefono;
                    datos_empleado.Parameters.Add("@estado_registro", SqlDbType.VarChar, 10).Value = estado_registro;
                    datos_empleado.ExecuteNonQuery();

                
            }

            catch (Exception e)//para guardar el error en la variable "e"
            {
                //controla errores y evita la detencion de la ejecucion del programa
                MessageBox.Show("Se presento un error,comuniquese con soporte tecnico" + e.Message);// imprime el error en un message box pero en forma corta por el "Message"
            }
            
        }

                    //para enviar los datos a la tabla experiencia laboral.




        public void creacion_empleado_experiencia(string cedula, string nombre_empresa, string motivo_retiro, string cargo_ejercido, string telefono_empresa, string direccion_empresa, string nombre_jefe, string years)//metodo
        {

            try
            {
                
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();// abre la conexion 
                SqlCommand experiencia_empleado = new SqlCommand("experiencia_empleado", conexion);
                    experiencia_empleado.CommandType = CommandType.StoredProcedure;
                    experiencia_empleado.Parameters.Add("@cedula_empleado", SqlDbType.VarChar, 20).Value = cedula;
                    experiencia_empleado.Parameters.Add("@anios_experiencia_laboral", SqlDbType.TinyInt).Value = years;
                    experiencia_empleado.Parameters.Add("@motivo_retiro", SqlDbType.VarChar, 20).Value = motivo_retiro;
                    experiencia_empleado.Parameters.Add("@cargo_anterior", SqlDbType.VarChar, 20).Value = cargo_ejercido;
                    experiencia_empleado.Parameters.Add("@nombre_empresa", SqlDbType.VarChar, 20).Value = nombre_empresa;
                    experiencia_empleado.Parameters.Add("@telefono_empresa", SqlDbType.Int).Value = telefono_empresa;
                    experiencia_empleado.Parameters.Add("@direccion_empresa", SqlDbType.VarChar, 50).Value = direccion_empresa;
                    experiencia_empleado.Parameters.Add("@jefe", SqlDbType.VarChar, 50).Value = nombre_jefe;
                    experiencia_empleado.ExecuteNonQuery();
                    
                   
                    conexion.Close();// se cierra la conexion.
                }
            

            catch (Exception e)//para guardar el error en la variable "e"
            {
                //controla errores y evita la detencion de la ejecucion del programa
                MessageBox.Show("Se presento un error,comuniquese con soporte tecnico" + e.Message);// imprime el error en un message box pero en forma corta por el "Message"
            }
        }




        //se realizara la consulta del empleado digitando la cedula.
        public DataTable consulta_empleado(string cedula)
        {


            SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
            conexion.Open();//abre la conexion.
            SqlDataAdapter consulta_empleado = new SqlDataAdapter("consulta_empleado", conexion);//para consultar los datos
            consulta_empleado.SelectCommand.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado
            consulta_empleado.SelectCommand.Parameters.Add("@Cedula", SqlDbType.VarChar, 20).Value = cedula;//envia a la varible del procedimiento de sql "@cedula" el valor de la variable"cedula"
            DataTable nn = new DataTable();// crea un objeto tipo datatable llamado nn.
            consulta_empleado.Fill(nn);//llena con los datos de consulta empleado el datatable nn.
            return nn;


        }

        public DataTable conuslta_empleado_nombre(string nombre)
        {



            SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
            conexion.Open();//abre la conexion.
            SqlDataAdapter consulta_empleado_nombre = new SqlDataAdapter("consulta_empleado_nombre", conexion);//para consultar los datos
            consulta_empleado_nombre.SelectCommand.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado
            consulta_empleado_nombre.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = nombre;//envia a la varible del procedimiento de sql "@Nombre" el valor de la variable"nombra"
            DataTable nn = new DataTable();// crea un objeto tipo datatable llamado nn.
            consulta_empleado_nombre.Fill(nn);//llena con los datos de consulta empleado el datatable nn.
            return nn;




        }

        public DataTable consulta_empleado_estado(string estado)
        {
            DataTable nn = new DataTable();// crea un objeto tipo datatable llamado nn.
            try
            {

                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();//abre la conexion.
                SqlDataAdapter consulta_empleado_estado = new SqlDataAdapter("consulta_empleado_estado", conexion);//para consultar los datos
                consulta_empleado_estado.SelectCommand.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado
                consulta_empleado_estado.SelectCommand.Parameters.Add("@Estado", SqlDbType.VarChar, 10).Value = estado;//envia a la varible del procedimiento de sql "@Estado" el valor de la variable"estado_registro"

                consulta_empleado_estado.Fill(nn);//llena con los datos de consulta empleado el datatable nn.
                return nn;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha Ocurrido Un Error" + e.Message);
                return nn;


            }


        }

        public DataTable consulta_empleado_us(string usuario)
        {

            SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
            conexion.Open();//abre la conexion
            SqlDataAdapter consulta_empleado_us = new SqlDataAdapter("consulta_empleado_us", conexion);//para consultar los datos
            consulta_empleado_us.SelectCommand.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado
            consulta_empleado_us.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;//envia a la varible del procedimiento de sql "@Usuario" el valor de la variable"usuario"
            DataTable nn = new DataTable();// crea un objeto tipo datatable llamado nn.
            consulta_empleado_us.Fill(nn);//llena con los datos de consulta empleado el datatable nn.
            conexion.Close();
            return nn;
        }


        public DataTable consulta_empleado_correo(string correo)
        {

            SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
            conexion.Open();//abre la conexion.
            SqlDataAdapter consulta_empleado_correo = new SqlDataAdapter("consulta_empleado_correo", conexion);//para consultar los datos
            consulta_empleado_correo.SelectCommand.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado
            consulta_empleado_correo.SelectCommand.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = correo;//envia a la varible del procedimiento de sql "@Correo" el valor de la variable"cedula"
            DataTable nn = new DataTable();// crea un objeto tipo datatable llamado nn.
            consulta_empleado_correo.Fill(nn);//llena con los datos de consulta empleado el datatable nn.
            conexion.Close();
            return nn;

        }
        public DataTable consulta_general_empleado(string x)
        {

            SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
            conexion.Open();//abre la conexion.
            SqlDataAdapter consulta_general_empleado = new SqlDataAdapter("consulta_general_empleado", conexion);//para consultar los datos
            DataTable nn = new DataTable();
            consulta_general_empleado.Fill(nn);
            conexion.Close();
            return nn;

        }


        public void actualizacion_empleado(string usuario, string cedula, string nombre, string cargo, string direccion, string correo, string observaciones)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();//abre la conexion.

                SqlCommand consulta_usuario = new SqlCommand("validacion_campos_usuario", conexion);
                consulta_usuario.CommandType = CommandType.StoredProcedure;
                consulta_usuario.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                SqlDataReader reader = consulta_usuario.ExecuteReader();
                if (reader.Read() == true)
                {
                    MessageBox.Show("El nombre de usuario del empleado ya existe digite uno diferente.");
                    reader.Close();
                }
                else
                {
                    if (reader.Read() == false)
                    {
                        reader.Close();
                        SqlCommand actualizacion = new SqlCommand("actualizar_empleado", conexion);

                        actualizacion.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                        actualizacion.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = usuario;
                        actualizacion.Parameters.Add("@cedula", SqlDbType.VarChar, 20).Value = cedula;
                        actualizacion.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                        actualizacion.Parameters.Add("@tipo_empleado", SqlDbType.VarChar, 30).Value = cargo;
                        actualizacion.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = direccion;
                        actualizacion.Parameters.Add("@correo", SqlDbType.VarChar, 50).Value = correo;
                        actualizacion.Parameters.Add("@observaciones", SqlDbType.VarChar, 8000).Value = observaciones;
                        actualizacion.ExecuteNonQuery();
                        MessageBox.Show("Actualizacion Concluida");
                        conexion.Close();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha Ocurrido Un Error" + e.Message);

            }
        }


        public void eliminacion_empleado(string estado, string cedula)
        {

            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();//abre la conexion.


                SqlCommand eliminacion = new SqlCommand("eliminar_empleado", conexion);

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
        public void cambio_clave(string usuario, string clave,string clave_nueva)
        {

            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();//abre la conexion.


                SqlCommand consulta_clave = new SqlCommand("consulta_clave", conexion);

                consulta_clave.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                consulta_clave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = clave;
                consulta_clave.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = usuario;
               
                SqlDataReader reader2 = consulta_clave.ExecuteReader();
                if (reader2.Read() == true)
                {
                    reader2.Close();
                    SqlCommand cambio_clave = new SqlCommand("cambio_clave", conexion);
                    cambio_clave.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                    cambio_clave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = clave_nueva;
                    cambio_clave.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = usuario;
                    cambio_clave.ExecuteNonQuery();
                    
                    conexion.Close();
                    MessageBox.Show("Contraseña actualizada con exito.");
                }
                else {
                    if (reader2.Read() == false)
                    {
                    reader2.Close();
                    conexion.Close();
                    MessageBox.Show("La clave digitada no es correcta");
                    }
                }
            }
            catch (Exception e)
           {
                
               MessageBox.Show("Ha Ocurrido Un Error" + e.Message);
            }
        }
        public void restauracion_clave(string usuario)
        {

            //try
            //{
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();//abre la conexion.


                SqlCommand consulta_usuario = new SqlCommand("consulta_usuario", conexion);

                consulta_usuario.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                consulta_usuario.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = usuario;

                SqlDataReader reader = consulta_usuario.ExecuteReader();
                if (reader.Read() == true)
                {
                    reader.Close();
                    SqlCommand consulta_clave_correo = new SqlCommand("consulta_clave_correo", conexion);
                    consulta_clave_correo.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado.
                    consulta_clave_correo.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = usuario;
                    consulta_clave_correo.Parameters.Add("@clave", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                    consulta_clave_correo.Parameters.Add("@correo", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                    consulta_clave_correo.ExecuteNonQuery();
                    string correo = consulta_clave_correo.Parameters["@correo"].Value.ToString();
                    string clave = consulta_clave_correo.Parameters["@clave"].Value.ToString();

                    //ENVÍO DE CORREO ELECTRÓNICO
                    PARA = correo; //Los mensajes llegarán a este correo
                    MENSAJE = "Tu contraseña es: " + clave;
                    mail = new MailMessage();
                    mail.To.Add(new MailAddress(this.PARA));
                    mail.From = new MailAddress("sanroquedrogueria@gmail.com"); //Debe ingresarse el E-mail remitente
                    mail.Subject = "Contraseña Del Sistema"; //Asunto del mensaje, en este caso el objeto Label lbl1
                    mail.Body = MENSAJE; //El cuerpo del mensaje Mail es el contenido de la variable MENSAJE
                    mail.IsBodyHtml = false;
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //PROTOCOLO DE TRANSFERENCIA DE DATOS MAIL
                    //SMTP: smtp.live.com HOTMAIL Si el mensaje es emitido desde hotmail, es empleado el smtp live
                    //SMTP: smtp.mail.yahoo.com YAHOO Si el mensaje es emitido desde yahoo, es empleado el smtp mail.yahoo
                    //SMTP: smtp.gmail.com GMAIL Si el mensaje es emitido desde gmail, es empleado el smtp gmail
                    DE = "sanroquedrogueria@gmail.com"; //Cuenta de correo desde donde es emitido el mensaje
                    CONTRASENA = "metallica123"; //Contraseña del correo electrónico desde donde es emitido el mensaje
                    using (client) //Se brindan permisos para acceder a la cuenta de correo electrónico y enviar el mensaje
                    {
                        client.Credentials = new System.Net.NetworkCredential(this.DE, this.CONTRASENA);
                        client.EnableSsl = true;
                        client.Send(mail);
                        //Mensaje de notificación de envio del mensaje
                        MessageBox.Show("Mensaje de restauracion enviado", "Envio de notificaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                   
                    conexion.Close();
                   
                }
                else
                {
                    if (reader.Read() == false)
                    {
                        reader.Close();
                        conexion.Close();
                        MessageBox.Show("El nombre de usuario es incorrecto o el usuario se encuentra 'inactivo'");
                    }
                }
            //}
            //catch (Exception e)
            //{

            //    MessageBox.Show("Ha Ocurrido Un Error" + e.Message);
            //}
        }

        public DataTable consulta_experiencia(string cedula)
        {
            DataTable nn = new DataTable();
            try {

                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();//abre la conexion.
                SqlDataAdapter consulta_experiencia_empleado = new SqlDataAdapter("consulta_experiencia", conexion);//para consultar los datos
                consulta_experiencia_empleado.SelectCommand.CommandType = CommandType.StoredProcedure;// tipo de comando procedimiento almacenado
                consulta_experiencia_empleado.SelectCommand.Parameters.Add("@Cedula", SqlDbType.VarChar, 50).Value = cedula;
                consulta_experiencia_empleado.Fill(nn);
                conexion.Close();
                return nn;





            }


            catch (Exception e )
            {
                MessageBox.Show("Se a presentado un error contacte con servicio tecnico"+ e);
            }

             return nn;

            

        }

        public void actualizacion_empleado_experiencia(string cod,string nombre_empresa, string motivo_retiro, string cargo_ejercido, string telefono_empresa, string direccion_empresa, string nombre_jefe, string years)//metodo
        {

            try
            {

                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();// abre la conexion 
                SqlCommand experiencia_empleado = new SqlCommand("actualizacion_experiencia", conexion);
                experiencia_empleado.CommandType = CommandType.StoredProcedure;
                experiencia_empleado.Parameters.Add("@cod", SqlDbType.BigInt).Value = cod;
                experiencia_empleado.Parameters.Add("@years", SqlDbType.TinyInt).Value = years;
                experiencia_empleado.Parameters.Add("@motivo_retiro", SqlDbType.VarChar, 20).Value = motivo_retiro;
                experiencia_empleado.Parameters.Add("@cargo_anterior", SqlDbType.VarChar, 20).Value = cargo_ejercido;
                experiencia_empleado.Parameters.Add("@nombre_empresa", SqlDbType.VarChar, 20).Value = nombre_empresa;
                experiencia_empleado.Parameters.Add("@telefono_empresa", SqlDbType.Int).Value = telefono_empresa;
                experiencia_empleado.Parameters.Add("@direccion_empresa", SqlDbType.VarChar, 50).Value = direccion_empresa;
                experiencia_empleado.Parameters.Add("@nombre_jefe", SqlDbType.VarChar, 50).Value = nombre_jefe;
                experiencia_empleado.ExecuteNonQuery();


                conexion.Close();// se cierra la conexion.
                MessageBox.Show("Actualizacion Concluida Con Exito");
            }


            catch (Exception e)//para guardar el error en la variable "e"
            {
                //controla errores y evita la detencion de la ejecucion del programa
                MessageBox.Show("Se presento un error,comuniquese con soporte tecnico" + e.Message);// imprime el error en un message box pero en forma corta por el "Message"
            }
        }
        public string validacion_nombre_usuario(string usuario)
        {
            try {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();// abre la conexion 
                SqlCommand validacion = new SqlCommand("validacion_campos_nombre_usuario", conexion);
                validacion.CommandType = CommandType.StoredProcedure;
                validacion.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                SqlDataReader validacion_l = validacion.ExecuteReader();

                if (validacion_l.Read() == true)
                {
                    

                    validacion_l.Close();
                    return "false";

                }
                else if (validacion_l.Read() == false)
                {
                    validacion_l.Close();
                    return "true";
                }
            }
            catch (Exception e) {

                MessageBox.Show("Se a presentado un error " + e.Message);
            }
            return "";
            }
        public string validacion_cedula(string cedula)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Negocios.conection.x());//establece la conexion con la base de datos
                conexion.Open();// abre la conexion 
                SqlCommand validacion = new SqlCommand("validacion_campos_cedula_empleado", conexion);
                validacion.CommandType = CommandType.StoredProcedure;
                validacion.Parameters.Add("@cedula", SqlDbType.VarChar, 20).Value = cedula;
                SqlDataReader validacion_l = validacion.ExecuteReader();

                if (validacion_l.Read() == true)
                {
                    

                    validacion_l.Close();
                    return "false";

                }
                else
                {
                    validacion_l.Close();
                    return "true";
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Se a presentado un error " + e.Message);
            }
            return "";
        }
    }
}
        
    

