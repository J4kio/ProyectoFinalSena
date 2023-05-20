using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
//System.Diagnostics.Process.Start("Shutdown","-s -t 10");
namespace ProyectRoque.Negocios
{
    class Clase_login
    {

        public void Login(string usuario, string clave, string cargo)
        {
            try
            {

                SqlConnection conexion = new SqlConnection(Negocios.conection.x());
                conexion.Open();
                SqlCommand consulta = new SqlCommand("Acceso", conexion);
                consulta.CommandType = CommandType.StoredProcedure;
                consulta.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;
                consulta.Parameters.Add("@Clave", SqlDbType.VarChar, 50).Value = clave;
                consulta.Parameters.Add("@Tipo_Empleado", SqlDbType.VarChar, 30).Value = cargo;
                SqlDataReader ingreso = consulta.ExecuteReader();
                if (ingreso.Read() == true)
                {
                    if (cargo == "Administrador")
                    {
                        Presentacion.menu_administrador administrador = new Presentacion.menu_administrador();
                        administrador.usuario = usuario;
                        administrador.cargo = cargo;
                        Presentacion.Empleados emple = new Presentacion.Empleados();                        
                        administrador.Show();
                        

                    }
                    else
                    {
                        if (cargo == "Cajero")
                        {
                            Presentacion.menu_cajero cajero = new Presentacion.menu_cajero();
                            cajero.usuario = usuario;
                            cajero.cargo = cargo;
                            cajero.Show();

                        }


                        else
                        {
                            if (cargo == "Jefe De Inventario")
                            {
                                Presentacion.menu_jefe_inventario jefe_inventario = new Presentacion.menu_jefe_inventario();
                                jefe_inventario.usuario = usuario;
                                jefe_inventario.cargo = cargo;
                                jefe_inventario.Show();
                            }



                        }

                    }

                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña incorrecto", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Presentacion.Login login = new Presentacion.Login();
                    login.Show();

                }
                conexion.Close();
            }

                
               catch(Exception e)
            {
                MessageBox.Show("Se A Presentado Un Error Contacte Con Soporte Tecnico"+e.Message);
            }
        }
    }
}

    